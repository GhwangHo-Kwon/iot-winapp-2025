namespace SyntaxWinApp02
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
            BtmMsg = new Button();
            SuspendLayout();
            // 
            // BtmMsg
            // 
            BtmMsg.Location = new Point(472, 259);
            BtmMsg.Name = "BtmMsg";
            BtmMsg.Size = new Size(100, 40);
            BtmMsg.TabIndex = 0;
            BtmMsg.Text = "메시지";
            BtmMsg.UseVisualStyleBackColor = true;
            BtmMsg.Click += BtmMsg_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 311);
            Controls.Add(BtmMsg);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "문법학습 윈앱 02";
            ResumeLayout(false);
        }

        #endregion

        private Button BtmMsg;
    }
}
