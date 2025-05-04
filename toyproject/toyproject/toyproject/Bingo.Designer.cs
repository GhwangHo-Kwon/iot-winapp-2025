namespace toyproject
{
    partial class Bingo
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
            TlpBingo = new TableLayoutPanel();
            panel1 = new Panel();
            TxtCmd = new TextBox();
            label1 = new Label();
            BtnSend = new Button();
            TxtSend = new TextBox();
            TxtChannel = new RichTextBox();
            panel2 = new Panel();
            label2 = new Label();
            FlpParticipant = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // TlpBingo
            // 
            TlpBingo.ColumnCount = 1;
            TlpBingo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TlpBingo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            TlpBingo.Location = new Point(12, 99);
            TlpBingo.Name = "TlpBingo";
            TlpBingo.RowCount = 1;
            TlpBingo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TlpBingo.RowStyles.Add(new RowStyle(SizeType.Absolute, 350F));
            TlpBingo.Size = new Size(500, 350);
            TlpBingo.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(TxtCmd);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 58);
            panel1.TabIndex = 4;
            // 
            // TxtCmd
            // 
            TxtCmd.BorderStyle = BorderStyle.FixedSingle;
            TxtCmd.Location = new Point(0, -1);
            TxtCmd.Name = "TxtCmd";
            TxtCmd.Size = new Size(100, 23);
            TxtCmd.TabIndex = 12;
            TxtCmd.Visible = false;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("맑은 고딕", 30F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(500, 58);
            label1.TabIndex = 0;
            label1.Text = "빙 고";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BtnSend
            // 
            BtnSend.Location = new Point(700, 424);
            BtnSend.Name = "BtnSend";
            BtnSend.Size = new Size(74, 29);
            BtnSend.TabIndex = 5;
            BtnSend.Text = "전송";
            BtnSend.UseVisualStyleBackColor = true;
            BtnSend.Click += BtnSend_Click;
            // 
            // TxtSend
            // 
            TxtSend.Font = new Font("맑은 고딕", 12F);
            TxtSend.Location = new Point(517, 424);
            TxtSend.Margin = new Padding(2);
            TxtSend.Name = "TxtSend";
            TxtSend.Size = new Size(178, 29);
            TxtSend.TabIndex = 7;
            TxtSend.KeyDown += TxtSend_KeyDown;
            // 
            // TxtChannel
            // 
            TxtChannel.BackColor = Color.White;
            TxtChannel.BorderStyle = BorderStyle.FixedSingle;
            TxtChannel.Location = new Point(517, 12);
            TxtChannel.Margin = new Padding(2);
            TxtChannel.Name = "TxtChannel";
            TxtChannel.ReadOnly = true;
            TxtChannel.ScrollBars = RichTextBoxScrollBars.Vertical;
            TxtChannel.Size = new Size(258, 408);
            TxtChannel.TabIndex = 8;
            TxtChannel.TabStop = false;
            TxtChannel.Text = "";
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Location = new Point(780, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(142, 40);
            panel2.TabIndex = 10;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("맑은 고딕", 20F, FontStyle.Bold);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(142, 40);
            label2.TabIndex = 0;
            label2.Text = "참 가 자";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FlpParticipant
            // 
            FlpParticipant.AutoScroll = true;
            FlpParticipant.FlowDirection = FlowDirection.TopDown;
            FlpParticipant.Location = new Point(780, 58);
            FlpParticipant.Name = "FlpParticipant";
            FlpParticipant.Size = new Size(142, 395);
            FlpParticipant.TabIndex = 11;
            // 
            // Bingo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 461);
            Controls.Add(FlpParticipant);
            Controls.Add(panel2);
            Controls.Add(TxtChannel);
            Controls.Add(TxtSend);
            Controls.Add(BtnSend);
            Controls.Add(panel1);
            Controls.Add(TlpBingo);
            Name = "Bingo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bingo";
            FormClosing += Bingo_FormClosing;
            Load += Bingo_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel TlpBingo;
        private Panel panel1;
        private Label label1;
        private Button BtnSend;
        private TextBox TxtSend;
        private RichTextBox TxtChannel;
        private Panel panel2;
        private Label label2;
        private FlowLayoutPanel FlpParticipant;
        private TextBox TxtCmd;
    }
}