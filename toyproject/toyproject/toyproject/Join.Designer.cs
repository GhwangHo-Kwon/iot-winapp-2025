namespace toyproject
{
    partial class Join
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnCancel = new Button();
            BtnJoin = new Button();
            ChkPW = new CheckBox();
            ChkID = new CheckBox();
            TxtPW_R = new TextBox();
            label3 = new Label();
            TxtPW = new TextBox();
            label2 = new Label();
            TxtID = new TextBox();
            label1 = new Label();
            label4 = new Label();
            TxtName = new TextBox();
            ChkName = new CheckBox();
            PGender = new Panel();
            RbtWoman = new RadioButton();
            RbtMan = new RadioButton();
            label5 = new Label();
            label6 = new Label();
            DtpBirth = new DateTimePicker();
            label7 = new Label();
            TxtEmail = new TextBox();
            label8 = new Label();
            ChkPhone = new CheckBox();
            TxtPhone = new MaskedTextBox();
            PGender.SuspendLayout();
            SuspendLayout();
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(64, 359);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(100, 40);
            BtnCancel.TabIndex = 10;
            BtnCancel.Text = "가입취소";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnJoin
            // 
            BtnJoin.Location = new Point(176, 359);
            BtnJoin.Name = "BtnJoin";
            BtnJoin.Size = new Size(100, 40);
            BtnJoin.TabIndex = 11;
            BtnJoin.Text = "가입하기";
            BtnJoin.UseVisualStyleBackColor = true;
            BtnJoin.Click += BtnJoin_Click;
            // 
            // ChkPW
            // 
            ChkPW.AutoSize = true;
            ChkPW.Enabled = false;
            ChkPW.Location = new Point(293, 104);
            ChkPW.Name = "ChkPW";
            ChkPW.Size = new Size(15, 14);
            ChkPW.TabIndex = 8;
            ChkPW.UseVisualStyleBackColor = true;
            // 
            // ChkID
            // 
            ChkID.AutoSize = true;
            ChkID.Enabled = false;
            ChkID.Location = new Point(293, 27);
            ChkID.Name = "ChkID";
            ChkID.Size = new Size(15, 14);
            ChkID.TabIndex = 9;
            ChkID.UseVisualStyleBackColor = true;
            // 
            // TxtPW_R
            // 
            TxtPW_R.Location = new Point(112, 100);
            TxtPW_R.Name = "TxtPW_R";
            TxtPW_R.PasswordChar = '●';
            TxtPW_R.Size = new Size(164, 23);
            TxtPW_R.TabIndex = 3;
            TxtPW_R.TextChanged += TxtPW_R_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 103);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 4;
            label3.Text = "비밀번호 확인 : ";
            // 
            // TxtPW
            // 
            TxtPW.Location = new Point(112, 62);
            TxtPW.Name = "TxtPW";
            TxtPW.PasswordChar = '●';
            TxtPW.Size = new Size(164, 23);
            TxtPW.TabIndex = 2;
            TxtPW.TextChanged += TxtPW_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 65);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 5;
            label2.Text = "비밀번호 : ";
            // 
            // TxtID
            // 
            TxtID.Location = new Point(112, 23);
            TxtID.Name = "TxtID";
            TxtID.Size = new Size(164, 23);
            TxtID.TabIndex = 1;
            TxtID.TextChanged += TxtID_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 26);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 6;
            label1.Text = "아이디 : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(64, 184);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 6;
            label4.Text = "이름 : ";
            // 
            // TxtName
            // 
            TxtName.Location = new Point(112, 181);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(164, 23);
            TxtName.TabIndex = 5;
            TxtName.TextChanged += TxtName_TextChanged;
            // 
            // ChkName
            // 
            ChkName.AutoSize = true;
            ChkName.Enabled = false;
            ChkName.Location = new Point(293, 185);
            ChkName.Name = "ChkName";
            ChkName.Size = new Size(15, 14);
            ChkName.TabIndex = 8;
            ChkName.UseVisualStyleBackColor = true;
            // 
            // PGender
            // 
            PGender.Controls.Add(RbtWoman);
            PGender.Controls.Add(RbtMan);
            PGender.Controls.Add(label5);
            PGender.Location = new Point(52, 260);
            PGender.Name = "PGender";
            PGender.Size = new Size(224, 39);
            PGender.TabIndex = 15;
            // 
            // RbtWoman
            // 
            RbtWoman.AutoSize = true;
            RbtWoman.Location = new Point(151, 10);
            RbtWoman.Name = "RbtWoman";
            RbtWoman.Size = new Size(49, 19);
            RbtWoman.TabIndex = 8;
            RbtWoman.Text = "여자";
            RbtWoman.UseVisualStyleBackColor = true;
            // 
            // RbtMan
            // 
            RbtMan.AutoSize = true;
            RbtMan.Checked = true;
            RbtMan.Location = new Point(69, 10);
            RbtMan.Name = "RbtMan";
            RbtMan.Size = new Size(49, 19);
            RbtMan.TabIndex = 7;
            RbtMan.TabStop = true;
            RbtMan.Text = "남자";
            RbtMan.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 12);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 6;
            label5.Text = "성별 : ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 228);
            label6.Name = "label6";
            label6.Size = new Size(66, 15);
            label6.TabIndex = 5;
            label6.Text = "생년월일 : ";
            // 
            // DtpBirth
            // 
            DtpBirth.Location = new Point(112, 222);
            DtpBirth.Name = "DtpBirth";
            DtpBirth.Size = new Size(164, 23);
            DtpBirth.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(52, 143);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 6;
            label7.Text = "이메일 : ";
            // 
            // TxtEmail
            // 
            TxtEmail.Location = new Point(112, 140);
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(164, 23);
            TxtEmail.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(40, 315);
            label8.Name = "label8";
            label8.Size = new Size(66, 15);
            label8.TabIndex = 5;
            label8.Text = "전화번호 : ";
            // 
            // ChkPhone
            // 
            ChkPhone.AutoSize = true;
            ChkPhone.Enabled = false;
            ChkPhone.Location = new Point(293, 316);
            ChkPhone.Name = "ChkPhone";
            ChkPhone.Size = new Size(15, 14);
            ChkPhone.TabIndex = 8;
            ChkPhone.UseVisualStyleBackColor = true;
            // 
            // TxtPhone
            // 
            TxtPhone.Location = new Point(112, 312);
            TxtPhone.Mask = "000-9000-0000";
            TxtPhone.Name = "TxtPhone";
            TxtPhone.Size = new Size(164, 23);
            TxtPhone.TabIndex = 9;
            TxtPhone.TextChanged += TxtPhone_TextChanged;
            // 
            // Join
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 411);
            Controls.Add(TxtPhone);
            Controls.Add(DtpBirth);
            Controls.Add(PGender);
            Controls.Add(BtnCancel);
            Controls.Add(BtnJoin);
            Controls.Add(ChkPhone);
            Controls.Add(ChkName);
            Controls.Add(ChkPW);
            Controls.Add(ChkID);
            Controls.Add(TxtPW_R);
            Controls.Add(label3);
            Controls.Add(TxtPW);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(TxtName);
            Controls.Add(TxtEmail);
            Controls.Add(TxtID);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Join";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Join";
            FormClosing += Join_FormClosing;
            Load += Join_Load;
            PGender.ResumeLayout(false);
            PGender.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnCancel;
        private Button BtnJoin;
        private CheckBox ChkPW;
        private CheckBox ChkID;
        private TextBox TxtPW_R;
        private Label label3;
        private TextBox TxtPW;
        private Label label2;
        private TextBox TxtID;
        private Label label1;
        private Label label4;
        private TextBox TxtName;
        private CheckBox ChkName;
        private Panel PGender;
        private RadioButton RbtWoman;
        private RadioButton RbtMan;
        private Label label5;
        private Label label6;
        private DateTimePicker DtpBirth;
        private Label label7;
        private TextBox TxtEmail;
        private Label label8;
        private CheckBox ChkPhone;
        private MaskedTextBox TxtPhone;
    }
}