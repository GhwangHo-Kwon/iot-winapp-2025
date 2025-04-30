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
            TabControl1.Location = new Point(12, 67);
            TabControl1.Size = new Size(360, 382);
            TabControl1.Hide();
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
        }

        private void BtnSamePic_Click(object sender, EventArgs e)
        {
            TabControl1.SelectTab(0);
            TabControl1.Show();
        }

        private void BtnBingo_Click(object sender, EventArgs e)
        {
            TabControl1.SelectTab(1);
            TabControl1.Show();
        }

        private void BtnTetris_Click(object sender, EventArgs e)
        {
            TabControl1.SelectTab(2);
            TabControl1.Show();
        }

        private void BtnPicServer_Click(object sender, EventArgs e)
        {
            SamePicture samePicture = new SamePicture();
            samePicture.Show();
            this.FormClosing -= Main_FormClosing;
            Close();
        }

        private void BtnbingoServer_Click(object sender, EventArgs e)
        {
            Bingo bingo = new Bingo();
            bingo.Show();
            this.FormClosing -= Main_FormClosing;
            Close();
        }

        private void BtnTetrisServer_Click(object sender, EventArgs e)
        {
            Tetris tetris = new Tetris();
            tetris.Show();
            this.FormClosing -= Main_FormClosing;
            Close();
        }
    }
}
