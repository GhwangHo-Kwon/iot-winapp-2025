using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace toyproject
{
    public partial class WallPaper : Form
    {
        public WallPaper()
        {
            InitializeComponent();
        }

        private void WallPaper_Load(object sender, EventArgs e)
        {
            //TabControl1.Location = new Point(15, 89);
            //TabControl1.Size = new Size(463, 509);
            TabControl1.Hide();
            SamePicButton(5, 5);
            BingoButton(5, 5);
            TetrisButton(5, 5);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.login.Show();
        }

        private void BtnBefore_Click(object sender, EventArgs e)
        {
            Program.login.Show();
            Close();
        }

        private void BtnBefore2_Click(object sender, EventArgs e)
        {
            TabControl1.Hide();
            LblGameName.Text = "게임선택화면";
        }

        private void BtnSamePic_Click(object sender, EventArgs e)
        {
            TabControl1.SelectTab(0);
            TabControl1.Show();
            LblGameName.Text = "같은그림찾기";
        }

        private void BtnBingo_Click(object sender, EventArgs e)
        {
            TabControl1.SelectTab(1);
            TabControl1.Show();
            LblGameName.Text = "빙고";
        }

        private void BtnTetris_Click(object sender, EventArgs e)
        {
            TabControl1.SelectTab(2);
            TabControl1.Show();
            LblGameName.Text = "테트리스";
        }

        private void SamePicButton(int rows, int cols)
        {
            TlpSamePic.Controls.Clear();
            TlpSamePic.RowStyles.Clear();
            TlpSamePic.ColumnStyles.Clear();

            TlpSamePic.RowCount = rows;
            TlpSamePic.ColumnCount = cols;

            for (int  i = 0; i < rows; i++)
            {
                TlpSamePic.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));
            }

            for (int i = 0; i < cols; i++)
            {
                TlpSamePic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f /  cols));
            }

            int tw = TlpSamePic.Size.Width / cols;
            int th = TlpSamePic.Size.Height / rows;
            int cnt = (rows * cols) - 1;
            int Btn_idx = 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button BtnSamePic = new Button();

                    BtnSamePic.Tag = $"SamePicture:{Btn_idx}";
                    BtnSamePic.Font = new Font(Font.FontFamily, 12);
                    BtnSamePic.Name = $"SamePicture:{Btn_idx}";
                    BtnSamePic.Text = $"서버 {Btn_idx}";
                    BtnSamePic.Dock = DockStyle.Fill;
                    BtnSamePic.Click += BtnPicServer_Click;

                    TlpSamePic.Controls.Add(BtnSamePic, j, i);

                    Btn_idx++;
                }
            }
        }

        private void BtnPicServer_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            string BtnName = btn.Name;

            SamePicture samePicture = new SamePicture(BtnName);
            samePicture.Show();
            this.FormClosing -= Main_FormClosing;
            Close();
        }

        private void BingoButton(int rows, int cols)
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
            int cnt = (rows * cols) - 1;
            int Btn_idx = 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button BtnBingo = new Button();

                    BtnBingo.Tag = $"Bingo:{Btn_idx}";
                    BtnBingo.Font = new Font(Font.FontFamily, 12);
                    BtnBingo.Name = $"Bingo:{Btn_idx}";
                    BtnBingo.Text = $"서버 {Btn_idx}";
                    BtnBingo.Dock = DockStyle.Fill;
                    BtnBingo.Click += BtnBingoServer_Click;

                    TlpBingo.Controls.Add(BtnBingo, j, i);

                    Btn_idx++;
                }
            }
        }

        private void BtnBingoServer_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            string BtnName = btn.Name;

            Bingo bingo = new Bingo(BtnName);
            bingo.Show();
            this.FormClosing -= Main_FormClosing;
            Close();
        }

        private void TetrisButton(int rows, int cols)
        {
            TlpTetris.Controls.Clear();
            TlpTetris.RowStyles.Clear();
            TlpTetris.ColumnStyles.Clear();

            TlpTetris.RowCount = rows;
            TlpTetris.ColumnCount = cols;

            for (int i = 0; i < rows; i++)
            {
                TlpTetris.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));
            }

            for (int i = 0; i < cols; i++)
            {
                TlpTetris.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / cols));
            }

            int tw = TlpTetris.Size.Width / cols;
            int th = TlpTetris.Size.Height / rows;
            int cnt = (rows * cols) - 1;
            int Btn_idx = 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button BtnTetris = new Button();

                    BtnTetris.Tag = $"Tetris:{Btn_idx}";
                    BtnTetris.Font = new Font(Font.FontFamily, 12);
                    BtnTetris.Name = $"Tetris:{Btn_idx}";
                    BtnTetris.Text = $"서버 {Btn_idx}";
                    BtnTetris.Dock = DockStyle.Fill;
                    BtnTetris.Click += BtnTetrisServer_Click;

                    TlpTetris.Controls.Add(BtnTetris, j, i);

                    Btn_idx++;
                }
            }
        }

        private void BtnTetrisServer_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            string BtnName = btn.Name;

            Tetris tetris = new Tetris(BtnName);
            tetris.Show();
            this.FormClosing -= Main_FormClosing;
            Close();
        }
    }
}
