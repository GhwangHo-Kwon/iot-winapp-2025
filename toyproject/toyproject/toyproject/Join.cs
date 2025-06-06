﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toyproject
{
    public partial class Join : Form
    {
        public Join()
        {
            InitializeComponent();
        }

        private void Join_Load(object sender, EventArgs e)
        {

        }

        private void BtnJoin_Click(object sender, EventArgs e)
        {
            bool idCheck = Program.user.ID_Dupl(TxtID.Text);

            if (ChkID.Checked)
            {
                if (!idCheck)
                {
                    if (ChkPW.Checked)
                    {
                        if (ChkName.Checked)
                        {
                            if (ChkPhone.Checked)
                            {
                                User_Join();
                                MessageBox.Show("가입 하셨습니다.", "회원가입", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.FormClosing -= Join_FormClosing;
                                Close();
                            }
                            else MessageBox.Show("전화번호를 다시확인해주세요.", "회원가입", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else MessageBox.Show("이름을 적어주세요.", "회원가입", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else MessageBox.Show("비밀번호를 다시확인해주세요.", "회원가입", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else MessageBox.Show("아이디 중복!\r\n다시 입력해주세요.", "회원가입", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("아이디를 적어주세요.", "회원가입", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void TxtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnJoin_Click(sender, e);
            }
        }

        private void TxtID_TextChanged(object sender, EventArgs e)
        {
            if (TxtID.Text.Trim() != "")
            {
                ChkID.CheckState = CheckState.Checked;
            }
            else
            {
                ChkID.CheckState = CheckState.Unchecked;
            }
        }

        private void TxtPW_TextChanged(object sender, EventArgs e)
        {
            PW_Check();
        }

        private void TxtPW_R_TextChanged(object sender, EventArgs e)
        {
            PW_Check();
        }

        private void PW_Check()
        {
            if (TxtPW.Text != "" && TxtPW_R.Text != "")
            {
                if (TxtPW.Text == TxtPW_R.Text)
                {
                    ChkPW.CheckState = CheckState.Checked;
                }
                else
                {
                    ChkPW.CheckState = CheckState.Unchecked;
                }
            }
            else
            {
                ChkPW.CheckState = CheckState.Unchecked;
            }
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            if (TxtName.Text != "")
            {
                ChkName.CheckState = CheckState.Checked;
            }
            else
            {
                ChkName.CheckState = CheckState.Unchecked;
            }
        }

        private void TxtPhone_TextChanged(object sender, EventArgs e)
        {
            if (TxtPhone.MaskCompleted == true)
            {
                ChkPhone.CheckState = CheckState.Checked;
            }
            else
            {
                ChkPhone.CheckState = CheckState.Unchecked;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말 취소하시겠습니까?", "가입취소", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.FormClosing -= Join_FormClosing;
                Close();
            }
        }
        private void Join_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("정말 취소하시겠습니까?", "가입취소", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        public void User_Join()
        {
            User user = Program.user;

            user.ID = TxtID.Text.Trim();
            user.Password = TxtPW.Text.Trim();
            user.Name = TxtName.Text.Trim();
            user.Email = TxtEmail.Text.Trim();
            user.Birth = DtpBirth.Value.ToString("yyyy-MM-dd");
            user.Phone = TxtPhone.Text.Trim();
            user.Age = user.Age_Proc();
            if (RbtMan.Checked) user.Gender = 0;
            else user.Gender = 1;

            user.DB_Add();
            //MessageBox.Show($"{admin.ID}, {admin.Password}, {admin.Name}, {admin.Email}, {admin.Birth}, {admin.Phone}, {admin.Gender}");
        }

    }
}
