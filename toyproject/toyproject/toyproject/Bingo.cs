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

namespace toyproject
{
    public partial class Bingo : Form
    {
        public Bingo()
        {
            InitializeComponent();
        }

        private void Bingo_Load(object sender, EventArgs e)
        {
            Set_Table_Layout(5, 5);
        }

        private void Bingo_FormClosing(object sender, FormClosingEventArgs e)
        {
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
            int cnt = (rows * cols) - 1;
            int Btn_idx = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button BtnBingos = new Button();

                    BtnBingos.Tag = Btn_idx;
                    BtnBingos.Font = new Font(Font.FontFamily, 20, FontStyle.Bold);
                    BtnBingos.Name = $"{Btn_idx}";
                    BtnBingos.Text = $"{Btn_idx}";
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

            btn.Enabled = false;

            if (Bingo_Check(5, 5, sender))
            {
                MessageBox.Show("빙고!", "빙고여부", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool Bingo_Check(int rows, int cols, object sender)
        {
            if ((Row_Bingo(rows, cols, sender))) return true;
            else if ((Col_Bingo(rows, cols, sender))) return true;
            else if ((Left_Bingo(rows, cols))) return true;
            else if ((Right_Bingo(rows, cols))) { return true; }
            else return false;
        }

        private bool Row_Bingo(int rows, int cols, object sender)
        {
            Button btn = sender as Button;

            int row_ck = 1;
            int btn_idx = ((int)btn.Tag / rows) * rows;

            for (int i = btn_idx; i < (btn_idx+rows); i++)
            {
                if (Find_Btn(i).Enabled == true) return false;
            }

            return true;
        }

        private bool Col_Bingo(int rows, int cols, object sender)
        {
            Button btn = sender as Button;

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
    }
}
