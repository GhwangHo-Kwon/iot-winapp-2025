namespace toyproject
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnJoin = new Button();
            BtnLogin = new Button();
            TxtPW = new TextBox();
            TxtId = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            BtnExit = new Button();
            SuspendLayout();
            // 
            // BtnJoin
            // 
            BtnJoin.Location = new Point(208, 345);
            BtnJoin.Name = "BtnJoin";
            BtnJoin.Size = new Size(100, 40);
            BtnJoin.TabIndex = 4;
            BtnJoin.Text = "회원가입";
            BtnJoin.UseVisualStyleBackColor = true;
            BtnJoin.Click += BtnJoin_Click;
            // 
            // BtnLogin
            // 
            BtnLogin.Location = new Point(77, 345);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(100, 40);
            BtnLogin.TabIndex = 3;
            BtnLogin.Text = "로그인";
            BtnLogin.UseVisualStyleBackColor = true;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // TxtPW
            // 
            TxtPW.Location = new Point(139, 290);
            TxtPW.Name = "TxtPW";
            TxtPW.PasswordChar = '●';
            TxtPW.Size = new Size(169, 23);
            TxtPW.TabIndex = 2;
            // 
            // TxtId
            // 
            TxtId.Location = new Point(139, 250);
            TxtId.Name = "TxtId";
            TxtId.Size = new Size(169, 23);
            TxtId.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 12F);
            label3.Location = new Point(49, 288);
            label3.Name = "label3";
            label3.Size = new Size(84, 21);
            label3.TabIndex = 7;
            label3.Text = "비빌번호 :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 12F);
            label2.Location = new Point(65, 248);
            label2.Name = "label2";
            label2.Size = new Size(68, 21);
            label2.TabIndex = 8;
            label2.Text = "아이디 :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 30F);
            label1.Location = new Point(95, 30);
            label1.Name = "label1";
            label1.Size = new Size(208, 54);
            label1.TabIndex = 5;
            label1.Text = "MiniGame";
            // 
            // BtnExit
            // 
            BtnExit.Location = new Point(139, 409);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(100, 40);
            BtnExit.TabIndex = 3;
            BtnExit.Text = "종료";
            BtnExit.UseVisualStyleBackColor = true;
            BtnExit.Click += BtnExit_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 461);
            Controls.Add(BtnJoin);
            Controls.Add(BtnExit);
            Controls.Add(BtnLogin);
            Controls.Add(TxtPW);
            Controls.Add(TxtId);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            FormClosing += Login_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnJoin;
        private Button BtnLogin;
        private TextBox TxtPW;
        private TextBox TxtId;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button BtnExit;
    }
}
