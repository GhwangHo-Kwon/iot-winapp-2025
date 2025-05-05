using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toyproject
{
    public partial class SamePicture : Form
    {
        private List<List<Button>> imgButtons = new List<List<Button>>();
        private List<List<int>> imgIndex = new List<List<int>>();
        Button BtnFirst = null;
        Button BtnSecond = null;

        static User user = Program.user;
        string user_name = user.User_Name();
        string Ch_name = "";

        long user_num = 0;

        public SamePicture(string BtnName)
        {
            Ch_name = BtnName;
            InitializeComponent();
        }

        private void SamePicture_Load(object sender, EventArgs e)
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

        private void SamePicture_FormClosing(object sender, FormClosingEventArgs e)
        {
            var db = RedisConn.RedisDB;

            string sys_name = "Sys" + Ch_name;
            string sys_exit = "Sys:Exit " + user_name;
            db.Publish(sys_name, sys_exit);

            Thread.Sleep(100);

            WallPaper main = new WallPaper();
            main.Show();
        }

        private async Task Set_Table_Layout(int rows, int cols)
        {
            TlpSamePic.Controls.Clear();
            TlpSamePic.RowStyles.Clear();
            TlpSamePic.ColumnStyles.Clear();
            ImlCatchImg.Images.Clear();

            TlpSamePic.RowCount = rows;
            TlpSamePic.ColumnCount = cols;

            for (int i = 0; i < rows; i++)
            {
                TlpSamePic.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));
            }

            for (int i = 0; i < cols; i++)
            {
                TlpSamePic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / cols));
            }

            int tw = TlpSamePic.Size.Width / cols;
            int th = TlpSamePic.Size.Height / rows;
            int cnt = (rows * cols) / 2;
            List<int> imgLst = new List<int>();
            var imgLstCheck = new Dictionary<int, (int, int)>();

            Set_ImgList(cnt, tw, th);
            Random rand = new Random();

            for (int i = 0; i < cnt; i++) for (int j = 0; j < 2; j++)
                {
                    imgLst.Add(i);
                }

            for (int i = 0; i < rows; i++)
            {
                imgButtons.Add(new List<Button>());
                imgIndex.Add(new List<int>());
                for (int j = 0; j < cols; j++)
                {
                    imgButtons[i].Add(new Button());
                    int idxCheck = rand.Next(0, cnt);
                    int idx = imgLst.FindIndex(n => n == idxCheck);

                    while (true)
                    {
                        if (idx != -1)
                        {
                            imgButtons[i][j].ImageIndex = idxCheck;
                            imgIndex[i].Add(idxCheck);
                            imgLst.RemoveAt(idx);
                            break;
                        }
                        idxCheck = rand.Next(0, cnt);
                        idx = imgLst.FindIndex(n => n == idxCheck);
                    }

                    imgButtons[i][j].ImageList = ImlCatchImg;
                    imgButtons[i][j].Name = $"{i} {j}";
                    imgButtons[i][j].Dock = DockStyle.Fill;
                    imgButtons[i][j].Click += Img_Click;

                    TlpSamePic.Controls.Add(imgButtons[i][j], j, i);
                }
            }

            await Task.Delay(5000);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    imgButtons[i][j].ImageIndex = -1;
                }
            }
        }

        private void Set_ImgList(int cnt, int tw, int th)
        {
            Random rand = new Random();
            List<int> imgLst = new List<int>();

            string pathImg = "C:\\Source\\iot-winapp-2025\\toyproject\\toyproject\\samePicture\\";

            for (int i = 0; i < cnt; i++)
            {
                int name = 0;
                while (true)
                {
                    name = rand.Next(1, 12501);
                    if (imgLst.FindIndex(n => n == name) == -1) break;
                }

                imgLst.Add(name);
                ImlCatchImg.Images.Add(Image.FromFile(pathImg + $"{name}.jpg"));
            }

            ImlCatchImg.ImageSize = new Size(tw, th);
            ImlCatchImg.ColorDepth = ColorDepth.Depth32Bit;
        }

        private void Img_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn == null || btn.ImageIndex != -1) return;

            if (BtnFirst == null)
            {
                BtnFirst = btn;
                string[] idx = btn.Name.Split(' ');
                btn.ImageIndex = imgIndex[int.Parse(idx[0])][int.Parse(idx[1])];
            }
            else if (BtnSecond == null)
            {
                BtnSecond = btn;
                string[] idx = btn.Name.Split(' ');
                btn.ImageIndex = imgIndex[int.Parse(idx[0])][int.Parse(idx[1])];

                if (BtnFirst.ImageIndex == BtnSecond.ImageIndex)
                {
                    BtnFirst.Enabled = false;
                    BtnSecond.Enabled = false;
                    BtnFirst = BtnSecond = null;
                }
                else
                {
                    var t = new System.Windows.Forms.Timer();
                    t.Interval = 1000;
                    t.Tick += (s, args) =>
                    {
                        BtnFirst.ImageIndex = -1;
                        BtnSecond.ImageIndex = -1;
                        BtnFirst = BtnSecond = null;
                        t.Stop();
                        t.Dispose();
                    };
                    t.Start();
                }
            }
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
                    Set_Table_Layout(4, 4);
                    user_num = RedisConn.Sub_Count(Ch_name);
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
