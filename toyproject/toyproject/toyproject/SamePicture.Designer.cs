namespace toyproject
{
    partial class SamePicture
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
            components = new System.ComponentModel.Container();
            ImlCatchImg = new ImageList(components);
            TlpSamePic = new TableLayoutPanel();
            button1 = new Button();
            panel1 = new Panel();
            label1 = new Label();
            textBox1 = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ImlCatchImg
            // 
            ImlCatchImg.ColorDepth = ColorDepth.Depth32Bit;
            ImlCatchImg.ImageSize = new Size(128, 128);
            ImlCatchImg.TransparentColor = Color.Transparent;
            // 
            // TlpSamePic
            // 
            TlpSamePic.ColumnCount = 1;
            TlpSamePic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TlpSamePic.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            TlpSamePic.Location = new Point(12, 99);
            TlpSamePic.Name = "TlpSamePic";
            TlpSamePic.RowCount = 1;
            TlpSamePic.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TlpSamePic.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TlpSamePic.Size = new Size(500, 350);
            TlpSamePic.TabIndex = 0;
            // 
            // button1
            // 
            button1.ImageList = ImlCatchImg;
            button1.Location = new Point(518, 409);
            button1.Name = "button1";
            button1.Size = new Size(254, 40);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 58);
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("맑은 고딕", 30F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(500, 58);
            label1.TabIndex = 0;
            label1.Text = "같 은 그 림 찾 기";
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
            textBox1.TabIndex = 4;
            textBox1.TabStop = false;
            // 
            // SamePicture
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(textBox1);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(TlpSamePic);
            Name = "SamePicture";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SamePicture";
            FormClosing += SamePicture_FormClosing;
            Load += SamePicture_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ImageList ImlCatchImg;
        private TableLayoutPanel TlpSamePic;
        private Button button1;
        private Panel panel1;
        private Label label1;
        private TextBox textBox1;
    }
}