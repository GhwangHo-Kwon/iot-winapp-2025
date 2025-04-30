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
        public SamePicture()
        {
            InitializeComponent();
        }

        private void SamePicture_Load(object sender, EventArgs e)
        {
            Set_Table_Layout(4, 4);
            for (int i = 0; i < imgButtons.Count; i++)
            {
                for (int j = 0; j < imgButtons[i].Count; j++)
                {
                    imgButtons[i][j].Click += Img_Click;
                }
            }
        }

        private void SamePicture_FormClosing(object sender, FormClosingEventArgs e)
        {
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
    }
}
