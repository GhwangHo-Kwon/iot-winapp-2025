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
            label1 = new Label();
            BtnSend = new Button();
            TxtSend = new TextBox();
            TxtChannel = new RichTextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // TlpBingo
            // 
            TlpBingo.ColumnCount = 1;
            TlpBingo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TlpBingo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 26F));
            TlpBingo.Location = new Point(15, 132);
            TlpBingo.Margin = new Padding(4);
            TlpBingo.Name = "TlpBingo";
            TlpBingo.RowCount = 1;
            TlpBingo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TlpBingo.RowStyles.Add(new RowStyle(SizeType.Absolute, 467F));
            TlpBingo.Size = new Size(643, 467);
            TlpBingo.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(15, 16);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(643, 77);
            panel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("맑은 고딕", 30F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(643, 77);
            label1.TabIndex = 0;
            label1.Text = "빙 고";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BtnSend
            // 
            BtnSend.Location = new Point(900, 565);
            BtnSend.Margin = new Padding(4);
            BtnSend.Name = "BtnSend";
            BtnSend.Size = new Size(95, 34);
            BtnSend.TabIndex = 5;
            BtnSend.Text = "전송";
            BtnSend.UseVisualStyleBackColor = true;
            BtnSend.Click += BtnSend_Click;
            // 
            // TxtSend
            // 
            TxtSend.Font = new Font("맑은 고딕", 12F);
            TxtSend.Location = new Point(665, 565);
            TxtSend.Name = "TxtSend";
            TxtSend.Size = new Size(228, 34);
            TxtSend.TabIndex = 7;
            TxtSend.KeyDown += TxtSend_KeyDown;
            // 
            // TxtChannel
            // 
            TxtChannel.BackColor = Color.White;
            TxtChannel.BorderStyle = BorderStyle.FixedSingle;
            TxtChannel.Location = new Point(665, 16);
            TxtChannel.Name = "TxtChannel";
            TxtChannel.ReadOnly = true;
            TxtChannel.ScrollBars = RichTextBoxScrollBars.Vertical;
            TxtChannel.Size = new Size(331, 542);
            TxtChannel.TabIndex = 8;
            TxtChannel.TabStop = false;
            TxtChannel.Text = "";
            // 
            // Bingo
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 615);
            Controls.Add(TxtChannel);
            Controls.Add(TxtSend);
            Controls.Add(BtnSend);
            Controls.Add(panel1);
            Controls.Add(TlpBingo);
            Margin = new Padding(4);
            Name = "Bingo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bingo";
            FormClosing += Bingo_FormClosing;
            Load += Bingo_Load;
            panel1.ResumeLayout(false);
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
    }
}