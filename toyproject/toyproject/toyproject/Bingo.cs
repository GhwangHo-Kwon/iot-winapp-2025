﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Org.BouncyCastle.Tls;
using StackExchange.Redis;

namespace toyproject
{
    public partial class Bingo : Form
    {
        static User user = Program.user;
        string user_name = user.User_Name();
        string Ch_name = "";
        List<string> Start_users = new List<string>();

        bool MyTurn = false;
        bool isRunning = true;
        int curr_turn = 0;

        ConcurrentQueue<string> SysCmd = new ConcurrentQueue<string>();

        List<string> Result = new List<string>();

        long user_num = 0;

        public Bingo(string BtnName)
        {
            Ch_name = BtnName;
            InitializeComponent();
        }

        private void Bingo_Load(object sender, EventArgs e)
        {
            Task.Run(() => Chat_room());

            Task.Run(() =>
            {
                while (isRunning)
                {
                    try
                    {
                        Sys_Cmd();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Sys_Cmd 에러 : {ex.Message}");
                    }
                }
            });

            Room_Into();
            First_Into();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (ChkBoss.Checked == true)
            {
                try
                {
                    var db = RedisConn.RedisDB;

                    string sys_name = "Sys" + Ch_name;
                    string sys_into = "Sys:Start " + "게임시작";

                    db.Publish(sys_name, sys_into);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("시작하지 못했습니다!\r\n다시 눌러주세요!", "시작실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"Redis Connection test failed: {ex.Message}");
                }
            }
        }

        private void First_Into()
        {
            try
            {
                long subcnt = RedisConn.Sub_Count(Ch_name);

                if (subcnt <= 1)
                {
                    ChkBoss.Checked = true;
                    BtnStart.Enabled = true;
                    Console.WriteLine("방장입니다.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Redis pubsub err : {ex}");
            }
        }

        private void Chat_room()
        {
            try
            {
                var db = RedisConn.RedisDB;
                Sys_Conn();

                db.Multiplexer.GetSubscriber().Subscribe(Ch_name, (channel, message) =>
                {
                    Add_message(message);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Redis Connection test failed: {ex.Message}");
            }
        }

        private void Room_Into()
        {
            try
            {
                var db = RedisConn.RedisDB;

                string sys_name = "Sys" + Ch_name;
                string sys_into = "Sys:Into " + user_name;

                string txt_parse = user_name + "님이 들어오셨습니다!" + Time_Table();

                db.Publish(sys_name, sys_into);

                db.Publish(Ch_name, txt_parse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Redis Connection test failed: {ex.Message}");
            }
        }

        private void Add_message(string message)
        {
            if (TxtChannel.InvokeRequired)
            {
                TxtChannel.Invoke((MethodInvoker)(() => Add_message(message)));
                return;
            }

            TxtChannel.SelectionStart = TxtChannel.TextLength;
            TxtChannel.SelectionLength = 0;

            string[] txt_parse = message.Split(' ');

            if (message.Split('|')[0] == "/결과")
            {
                message = "Result\r\n" + message.Split('|')[1];
                TxtChannel.SelectionAlignment = HorizontalAlignment.Center;
            }
            else if (message.Split('|')[0] == "/차례")
            {
                message = message.Split('|')[1];
                TxtChannel.SelectionAlignment = HorizontalAlignment.Center;
            }
            else if (txt_parse[1] == "/방장")
            {
                if (txt_parse[3] == "O")
                {
                    if (ChkBoss.Name == txt_parse[2])
                    {
                        ChkBoss.Checked = true;
                        BtnStart.Enabled = true;
                    }

                    message = $"{txt_parse[2]}님에게 방장을 넘겼습니다.";
                    TxtChannel.SelectionAlignment = HorizontalAlignment.Center;
                }
                else
                {
                    message = $"{txt_parse[2]}님은 없습니다. 다시 입력해 주세요.";
                    TxtChannel.SelectionAlignment = HorizontalAlignment.Center;
                }
            }
            else if (txt_parse[1] == "들어오셨습니다!")
            {
                TxtChannel.SelectionAlignment = HorizontalAlignment.Center;
            }
            else if (txt_parse[0] == user_name)
            {
                TxtChannel.SelectionAlignment = HorizontalAlignment.Right;
            }
            else
            {
                TxtChannel.SelectionAlignment = HorizontalAlignment.Left;
            }

            TxtChannel.AppendText(message + Environment.NewLine);

            TxtChannel.ScrollToCaret();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            try
            {
                var db = RedisConn.RedisDB;

                if (TxtSend.Text.Split(' ')[0] == "/방장")
                {
                    if (ChkBoss.Checked)
                    {
                        if (TxtSend.Text.Split(' ')[1] != user_name) Boss_Auth();
                        else MessageBox.Show("당신은 이미 방장입니다.", "방장", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("방장이 아닙니다!", "방장", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    TxtSend.Text = "";
                    return;
                }

                string txt_parse = user_name + " " + TxtSend.Text + Time_Table();
                db.Publish(Ch_name, txt_parse);
                TxtSend.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Redis Connection test failed: {ex.Message}");
            }
        }

        private void Boss_Auth()
        {
            try
            {
                var db = RedisConn.RedisDB;
                string txt_parse = "";

                bool Conn_Name = false;

                var Into_Names = FlpParticipant.Controls
                        .OfType<Label>()
                        .Select(lbl => lbl.Text)
                        .ToList();

                foreach (var names in Into_Names)
                {
                    if (names == TxtSend.Text.Split(' ')[1])
                    {
                        Conn_Name = true;
                    }
                }

                if (!Conn_Name)
                {
                    txt_parse = user_name + " " + TxtSend.Text + " X";
                }
                else
                {
                    ChkBoss.Checked = false;
                    BtnStart.Enabled = false;
                    txt_parse = user_name + " " + TxtSend.Text + " O";
                }

                db.Publish(Ch_name, txt_parse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Redis Connection test failed: {ex.Message}");
            }
        }

        private void TxtSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSend_Click(sender, e);
            }
        }

        private string Time_Table()
        {
            DateTime time = DateTime.Now;
            string timetable = time.ToString(" tt h:mm");

            return timetable;
        }

        private void Bingo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Channel_Exit();
            isRunning = false;

            Thread.Sleep(100);

            WallPaper main = new WallPaper();
            main.Show();
        }

        private async Task Channel_Exit()
        {
            try
            {
                var db = RedisConn.RedisDB;

                string sys_name = "Sys" + Ch_name;
                string sys_exit = "Sys:Exit " + user_name;
                db.Publish(sys_name, sys_exit);

                if (ChkBoss.Checked)
                {
                    var Into_Names = FlpParticipant.Controls
                                .OfType<Label>()
                                .Select(lbl => lbl.Text)
                                .ToList()[1];

                    string txt_parse = user_name + " /방장 " + Into_Names + " O";
                    db.Publish(Ch_name, txt_parse);
                }

                var sub = db.Multiplexer.GetSubscriber();
                await sub.UnsubscribeAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 : {ex.Message}");
            }
        }

        private void Set_Table_Layout(int rows, int cols)
        {
            TlpBingo.Controls.Clear();
            TlpBingo.RowStyles.Clear();
            TlpBingo.ColumnStyles.Clear();

            TlpBingo.RowCount = rows;
            TlpBingo.ColumnCount = cols;

            for (int i = 0; i < rows; i++)
            {
                TlpBingo.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));
            }

            for (int i = 0; i < cols; i++)
            {
                TlpBingo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / cols));
            }

            int tw = TlpBingo.Size.Width / cols;
            int th = TlpBingo.Size.Height / rows;
            int Btn_idx = 0;

            int[] bingo_idx = new int[rows*cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    bingo_idx[Btn_idx] = Btn_idx;
                    Btn_idx++;
                }
            }

            bingo_idx = Random_Shuffle(bingo_idx);

            Btn_idx = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button BtnBingos = new Button();

                    BtnBingos.Tag = Btn_idx;
                    BtnBingos.Font = new Font(Font.FontFamily, 20, FontStyle.Bold);
                    BtnBingos.Name = $"{bingo_idx[Btn_idx]}";
                    BtnBingos.Text = $"{bingo_idx[Btn_idx]}";
                    BtnBingos.Dock = DockStyle.Fill;
                    BtnBingos.Click += Bingo_Click;

                    TlpBingo.Controls.Add(BtnBingos, j, i);

                    Btn_idx++;
                }
            }
        }

        private void Bingo_Click(object sender, EventArgs e)
        {
            if (!MyTurn)
            {
                MessageBox.Show("아직 차례가 아닙니다!", "차례", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Button btn = sender as Button;

            string btn_name = btn.Name;

            try
            {
                var db = RedisConn.RedisDB;

                string sys_name = "Sys" + Ch_name;
                string sys_click = "Sys:Click " + btn.Name;

                db.Publish(sys_name, sys_click);

                MyTurn = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 : {ex}");
            }
        }

        private void Bingo_Select(string btn_name)
        {
            Button btn = TlpBingo.Controls[btn_name] as Button;

            if (btn != null && btn.Tag != null)
            {
                btn.Enabled = false;

                if (Bingo_Check(5, 5, btn_name))
                {
                    try
                    {
                        var db = RedisConn.RedisDB;

                        string sys_name = "Sys" + Ch_name;
                        string sys_result = "Sys:Result " + user_name;
                        string sys_finish = "Sys:Finish " + user_name;

                        db.Publish(sys_name, sys_result);

                        Thread.Sleep(200);

                        db.Publish(sys_name, sys_finish);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"오류 : {ex}");
                    }
                }
            }
        }

        private bool Bingo_Check(int rows, int cols, string btn_name)
        {
            if ((Row_Bingo(rows, cols, btn_name))) return true;
            else if ((Col_Bingo(rows, cols, btn_name))) return true;
            else if ((Left_Bingo(rows, cols))) return true;
            else if ((Right_Bingo(rows, cols))) { return true; }
            else return false;
        }

        private bool Row_Bingo(int rows, int cols, string btn_name)
        {
            Button btn = TlpBingo.Controls[btn_name] as Button;

            int row_ck = 1;
            int btn_idx = ((int)btn.Tag / rows) * rows;

            for (int i = btn_idx; i < (btn_idx + rows); i++)
            {
                if (Find_Btn(i).Enabled == true) return false;
            }

            return true;
        }

        private bool Col_Bingo(int rows, int cols, string btn_name)
        {
            Button btn = TlpBingo.Controls[btn_name] as Button;

            int col_ck = 1;
            int btn_idx = ((int)btn.Tag % cols);

            for (int i = 0; i < cols; i++)
            {
                if (Find_Btn(btn_idx).Enabled == true) return false;
                btn_idx += cols;
            }

            return true;
        }

        private bool Left_Bingo(int rows, int cols)
        {
            int left_cross = 0;

            for (int i = 0; i < cols; i++)
            {
                if (Find_Btn(left_cross).Enabled == true) return false;
                left_cross += (cols + 1);
            }
            return true;
        }

        private bool Right_Bingo(int rows, int cols)
        {
            int right_cross = rows - 1;

            for (int i = 0; i < rows; i++)
            {
                if (Find_Btn(right_cross).Enabled == true) return false;
                right_cross += (rows - 1);
            }

            return true;
        }

        private Button Find_Btn(object tag)
        {
            foreach (Control control in TlpBingo.Controls)
            {
                if (control is Button btn && btn.Tag != null && btn.Tag.Equals(tag))
                {
                    return btn;
                }
            }
            return null;
        }

        public static T[] Random_Shuffle<T>(T[] array)
        {
            Random rand = new Random();

            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);

                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }

            return array;
        }

        private void Sys_Conn()
        {
            try
            {
                var db = RedisConn.RedisDB;
                string sys_name = "Sys" + Ch_name;

                db.Multiplexer.GetSubscriber().Subscribe(sys_name, (channel, message) =>
                {
                    SysCmd.Enqueue(message);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Redis Connection test failed: {ex.Message}");
            }
        }

        private void Sys_Cmd()
        {
            Thread.Sleep(100);

            try
            {
                if (SysCmd.TryDequeue(out string cmd))
                {
                    string[] parse_cmd = cmd.Split(' ');

                    if (parse_cmd.Length > 0 && parse_cmd[0] == "Sys:Into")
                    {
                        if (this.IsDisposed || !this.IsHandleCreated) return;

                        this.Invoke(new Action(() =>
                        {
                            if (ChkBoss.Checked)
                            {
                                Sys_Into(parse_cmd[1]);
                                Sys_Into_Boss();
                            }
                        }));
                    }
                    else if (parse_cmd.Length > 0 && parse_cmd[0] == "Sys:IntoList" && !ChkBoss.Checked)
                    {
                        if (this.IsDisposed || !this.IsHandleCreated) return;

                        this.Invoke(new Action(() =>
                        {
                            string[] participants = cmd.Substring("Sys:IntoList ".Length).Split(',');

                            foreach (var names in participants)
                            {
                                if (!FlpParticipant.Controls.OfType<Label>().Any(l => l.Tag?.ToString() == names))
                                {
                                    Sys_Into(names);
                                }
                            }
                        }));
                    }
                    else if (parse_cmd.Length > 0 && parse_cmd[0] == "Sys:Exit")
                    {
                        if (this.IsDisposed || !this.IsHandleCreated) return;

                        this.Invoke(new Action(() =>
                        {
                            Sys_Exit(parse_cmd[1]);
                        }));
                    }
                    else if (parse_cmd.Length > 0 && parse_cmd[0] == "Sys:Start")
                    {
                        if (this.IsDisposed || !this.IsHandleCreated) return;

                        if (ChkBoss.Checked)
                        {
                            Start_Game();
                        }

                        this.Invoke(new Action(() =>
                        {
                            Set_Table_Layout(5, 5);

                            if (ChkBoss.Checked)
                            {
                                BtnStart.Enabled = false;
                            }
                        }));

                        Result.Clear();
                    }
                    else if (parse_cmd.Length > 0 && parse_cmd[0] == "Sys:Result")
                    {
                        if (this.IsDisposed || !this.IsHandleCreated) return;

                        Result.Add(parse_cmd[1]);

                        this.Invoke(new Action(() =>
                        {
                            TlpBingo.Controls.Clear();

                            if (ChkBoss.Checked)
                            {
                                BtnStart.Enabled = true;
                            }
                        }));

                    }
                    else if (parse_cmd.Length > 0 && parse_cmd[0] == "Sys:Finish")
                    {
                        if (this.IsDisposed || !this.IsHandleCreated) return;

                        if (SysCmd.Count <= 1)
                        {
                            MessageBox.Show("누군가의 빙고!\r\n빙고 결과는 채팅창에 출력됩니다!", "빙고", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (ChkBoss.Checked)
                            {
                                Total_Score();
                            }
                        }
                    }
                    else if (parse_cmd.Length > 0 && parse_cmd[0] == "Sys:Turn")
                    {
                        if (this.IsDisposed || !this.IsHandleCreated) return;

                        if (user_name == parse_cmd[1])
                        {
                            MyTurn = true;
                        }
                    }
                    else if (parse_cmd.Length > 0 && parse_cmd[0] == "Sys:Click")
                    {
                        if (this.IsDisposed || !this.IsHandleCreated) return;

                        this.Invoke(new Action(() =>
                        {
                            Bingo_Select(parse_cmd[1]);
                        }));

                        if (ChkBoss.Checked)
                        {
                            Next_Turn();
                        }
                    }
                    else { }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"에러 : {ex.Message}");
            }
        }

        private void Total_Score()
        {
            try
            {
                var db = RedisConn.RedisDB;

                string result = string.Join(", ", Result);

                db.Publish(Ch_name, "/결과|" + result + "님이 빙고하셨습니다!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 : {ex.Message}");
            }
        }

        private void Start_Game()
        {
            try
            {
                Start_users = FlpParticipant.Controls
                            .OfType<Label>()
                            .Select(lbl => lbl.Text)
                            .ToList();
                user_num = RedisConn.Sub_Count(Ch_name);

                var db = RedisConn.RedisDB;

                string sys_name = "Sys" + Ch_name;
                string sys_turn = "Sys:Turn " + Start_users[0];

                string turns = "/차례|차례는 " + string.Join(" → ", Start_users) + " 순으로 진행됩니다!";

                db.Publish(sys_name, sys_turn);

                db.Publish(Ch_name, turns);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"에러 : {ex.Message}");
            }
        }

        private void Next_Turn()
        {
            try
            {
                var db = RedisConn.RedisDB;

                curr_turn = (curr_turn + 1) % (int)user_num;
                string next_turn = "Sys:Turn " + Start_users[curr_turn];
                string sys_name = "Sys" + Ch_name;

                db.Publish(sys_name, next_turn);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"에러 : {ex.Message}");
            }
        }

        private void Sys_Into(string name)
        {
            Label lbl = new Label();
            Font font = new Font("NanumGothic", 16);

            lbl.Text = name;
            lbl.Tag = name;
            lbl.Font = font;
            lbl.AutoSize = true;

            FlpParticipant.Controls.Add(lbl);
        }

        private void Sys_Into_Boss()
        {
            var Into_Names = FlpParticipant.Controls
                            .OfType<Label>()
                            .Select(lbl => lbl.Text)
                            .ToList();

            string ParticipantList = string.Join(",", Into_Names);

            try
            {
                var db = RedisConn.RedisDB;

                string sys_name = "Sys" + Ch_name;
                string sys_into = "Sys:IntoList " + ParticipantList;

                db.Publish(sys_name, sys_into);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Redis Connection test failed: {ex.Message}");
            }
        }

        private void Sys_Exit(string exit_name)
        {
            foreach (Control ctrl in FlpParticipant.Controls)
            {
                if (ctrl is Label name && name.Tag?.ToString() == exit_name)
                {
                    FlpParticipant.Controls.Remove(name);
                    break;
                }
            }
        }
    }
}
