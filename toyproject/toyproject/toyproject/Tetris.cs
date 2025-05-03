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
    public partial class Tetris : Form
    {
        static User user = Program.user;
        string user_name = user.User_Name();
        string Ch_name = "";

        public Tetris(string BtnName)
        {
            Ch_name = BtnName;
            InitializeComponent();
        }

        private void Tetris_FormClosing(object sender, FormClosingEventArgs e)
        {
            WallPaper main = new WallPaper();
            main.Show();
        }
    }
}
