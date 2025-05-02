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
            textBox1 = new TextBox();
            button1 = new Button();
            panel1.SuspendLayout();
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
            TlpBingo.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TlpBingo.Size = new Size(500, 350);
            TlpBingo.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 58);
            panel1.TabIndex = 4;
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
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.Enabled = false;
            textBox1.Location = new Point(518, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(254, 391);
            textBox1.TabIndex = 6;
            textBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(518, 409);
            button1.Name = "button1";
            button1.Size = new Size(254, 40);
            button1.TabIndex = 5;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // Bingo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(TlpBingo);
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
        private TextBox textBox1;
        private Button button1;
    }
}