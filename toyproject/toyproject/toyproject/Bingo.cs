using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Tls;
using StackExchange.Redis;

namespace toyproject
{
    public partial class Bingo : Form
    {
        static User user = Program.user;
        string user_name = user.User_Name();
        string Ch_name = "";

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
                while (true)
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

            if (txt_parse[0] == user_name)
            {
                TxtChannel.SelectionAlignment = HorizontalAlignment.Right;
            }
            else if (txt_parse[1] == "들어오셨습니다!")
            {
                TxtChannel.SelectionAlignment = HorizontalAlignment.Center;
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

                string txt_parse = user_name + " " + TxtSend.Text + Time_Table();
                db.Publish(Ch_name, txt_parse);
                TxtSend.Text = "";
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
            var db = RedisConn.RedisDB;

            string sys_name = "Sys" + Ch_name;
            string sys_exit = "Sys:Exit " + user_name;
            db.Publish(sys_name, sys_exit);

            Thread.Sleep(100);

            WallPaper main = new WallPaper();
            main.Show();
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
            Button btn = sender as Button;

            string btn_name = btn.Name;

            try
            {
                var db = RedisConn.RedisDB;

                string sys_name = "Sys" + Ch_name;
                string sys_into = "Sys:Click " + btn.Name;

                db.Publish(sys_name, sys_into);
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
                        string sys_into = "Sys:Finish " + user_name;

                        db.Publish(sys_name, sys_into);
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
            TxtCmd.Text = "";
            try
            {
                var db = RedisConn.RedisDB;
                string sys_name = "Sys" + Ch_name;

                db.Multiplexer.GetSubscriber().Subscribe(sys_name, (channel, message) =>
                {
                    TxtCmd.Text = message;
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
            if (TxtCmd.InvokeRequired)
            {
                TxtCmd.Invoke(new MethodInvoker(Sys_Cmd));
                return;
            }

            string cmd = TxtCmd.Text;
            TxtCmd.Text = "";

            if (!string.IsNullOrEmpty(cmd))
            {
                string[] parse_cmd = cmd.Split(' ');

                if (parse_cmd.Length > 0 && parse_cmd[0] == "Sys:Into")
                {
                    Sys_Into(parse_cmd[1]);
                }
                else if (parse_cmd.Length > 0 && parse_cmd[0] == "Sys:Exit")
                {
                    Sys_Exit(parse_cmd[1]);
                }
                else if (parse_cmd.Length > 0 && parse_cmd[0] == "Sys:Start")
                {
                    Set_Table_Layout(5, 5);
                    user_num = RedisConn.Sub_Count(Ch_name);
                }
                else if (parse_cmd.Length > 0 && parse_cmd[0] == "Sys:Finish")
                {
                    MessageBox.Show($"{parse_cmd[1]}님의 빙고!\r\n게임을 종료합니다.", "빙고여부", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TlpBingo.Controls.Clear();
                }
                else if (parse_cmd.Length > 0 && parse_cmd[0] == "Sys:Click")
                {
                    Bingo_Select(parse_cmd[1]);
                }
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
