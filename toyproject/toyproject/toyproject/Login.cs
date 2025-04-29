namespace toyproject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            User admin = Admin_Info();

            if (admin.ID == "")
            {
                MessageBox.Show("아이디를 입력해 주세요!", "로그인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!admin.ID_Check(admin.ID))
            {
                MessageBox.Show("아이디를 정확히 입력해 주세요!", "로그인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (admin.Password == "")
            {
                MessageBox.Show("비밀번호를 입력해 주세요!", "로그인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!admin.PW_Check(admin.ID, admin.Password))
            {
                MessageBox.Show("비밀번호를 정확히 입력해 주세요!", "로그인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("로그인 되었습니다.", "로그인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtId.Text = "";
                TxtPW.Text = "";

                Hide();
                WallPaper main = new WallPaper();
                main.Show();
            }
        }

        private void BtnJoin_Click(object sender, EventArgs e)
        {
            Join join = new Join();
            join.ShowDialog();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("정말 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.FormClosing -= Login_FormClosing;
                Application.Exit();
            }
        }
        private User Admin_Info()
        {
            User admin = new User();

            admin.ID = TxtId.Text.Trim();
            admin.Password = TxtPW.Text.Trim();

            return admin;
        }
    }
}
