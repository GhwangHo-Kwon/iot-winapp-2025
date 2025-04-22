namespace SyntaxWinApp04
{
    partial class FrmMain
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
            LblName = new Label();
            TxtName = new TextBox();
            LblAge = new Label();
            LblGender = new Label();
            RdoMale = new RadioButton();
            RdoFemale = new RadioButton();
            BtnMsg = new Button();
            LblResult = new Label();
            TxtResult = new TextBox();
            TxtAge = new MaskedTextBox();
            SuspendLayout();
            // 
            // LblName
            // 
            LblName.AutoSize = true;
            LblName.Location = new Point(12, 15);
            LblName.Name = "LblName";
            LblName.Size = new Size(66, 15);
            LblName.TabIndex = 0;
            LblName.Text = "이름입력 : ";
            // 
            // TxtName
            // 
            TxtName.Location = new Point(84, 12);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(170, 23);
            TxtName.TabIndex = 1;
            // 
            // LblAge
            // 
            LblAge.AutoSize = true;
            LblAge.Location = new Point(12, 44);
            LblAge.Name = "LblAge";
            LblAge.Size = new Size(66, 15);
            LblAge.TabIndex = 0;
            LblAge.Text = "생년월일 : ";
            // 
            // LblGender
            // 
            LblGender.AutoSize = true;
            LblGender.Location = new Point(12, 73);
            LblGender.Name = "LblGender";
            LblGender.Size = new Size(66, 15);
            LblGender.TabIndex = 0;
            LblGender.Text = "성별입력 : ";
            // 
            // RdoMale
            // 
            RdoMale.AutoSize = true;
            RdoMale.Checked = true;
            RdoMale.Location = new Point(84, 71);
            RdoMale.Name = "RdoMale";
            RdoMale.Size = new Size(49, 19);
            RdoMale.TabIndex = 3;
            RdoMale.TabStop = true;
            RdoMale.Text = "남성";
            RdoMale.UseVisualStyleBackColor = true;
            // 
            // RdoFemale
            // 
            RdoFemale.AutoSize = true;
            RdoFemale.Location = new Point(139, 71);
            RdoFemale.Name = "RdoFemale";
            RdoFemale.Size = new Size(49, 19);
            RdoFemale.TabIndex = 4;
            RdoFemale.Text = "여성";
            RdoFemale.UseVisualStyleBackColor = true;
            // 
            // BtnMsg
            // 
            BtnMsg.Location = new Point(472, 259);
            BtnMsg.Name = "BtnMsg";
            BtnMsg.Size = new Size(100, 40);
            BtnMsg.TabIndex = 6;
            BtnMsg.Text = "확인";
            BtnMsg.UseVisualStyleBackColor = true;
            BtnMsg.Click += BtnMsg_Click;
            // 
            // LblResult
            // 
            LblResult.AutoSize = true;
            LblResult.Location = new Point(12, 128);
            LblResult.Name = "LblResult";
            LblResult.Size = new Size(66, 15);
            LblResult.TabIndex = 0;
            LblResult.Text = "결      과 : ";
            // 
            // TxtResult
            // 
            TxtResult.Location = new Point(84, 125);
            TxtResult.Name = "TxtResult";
            TxtResult.Size = new Size(488, 23);
            TxtResult.TabIndex = 5;
            // 
            // TxtAge
            // 
            TxtAge.Location = new Point(84, 41);
            TxtAge.Mask = "0000-00-00";
            TxtAge.Name = "TxtAge";
            TxtAge.Size = new Size(170, 23);
            TxtAge.TabIndex = 2;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 311);
            Controls.Add(TxtAge);
            Controls.Add(BtnMsg);
            Controls.Add(RdoFemale);
            Controls.Add(RdoMale);
            Controls.Add(LblGender);
            Controls.Add(TxtResult);
            Controls.Add(LblResult);
            Controls.Add(LblAge);
            Controls.Add(TxtName);
            Controls.Add(LblName);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "문법연습 윈앱04";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblName;
        private TextBox TxtName;
        private Label LblAge;
        private Label LblGender;
        private RadioButton RdoMale;
        private RadioButton RdoFemale;
        private Button BtnMsg;
        private Label LblResult;
        private TextBox TxtResult;
        private MaskedTextBox TxtAge;
    }
}
