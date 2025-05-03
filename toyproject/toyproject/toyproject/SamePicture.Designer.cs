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
            panel1 = new Panel();
            label1 = new Label();
            TxtChannel = new RichTextBox();
            TxtSend = new TextBox();
            BtnSend = new Button();
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
            TlpSamePic.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 26F));
            TlpSamePic.Location = new Point(15, 132);
            TlpSamePic.Margin = new Padding(4);
            TlpSamePic.Name = "TlpSamePic";
            TlpSamePic.RowCount = 1;
            TlpSamePic.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TlpSamePic.RowStyles.Add(new RowStyle(SizeType.Absolute, 467F));
            TlpSamePic.Size = new Size(643, 467);
            TlpSamePic.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(15, 16);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(643, 77);
            panel1.TabIndex = 3;
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
            label1.Text = "같 은 그 림 찾 기";
            label1.TextAlign = ContentAlignment.MiddleCenter;
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
            TxtChannel.TabIndex = 11;
            TxtChannel.TabStop = false;
            TxtChannel.Text = "";
            // 
            // TxtSend
            // 
            TxtSend.Font = new Font("맑은 고딕", 12F);
            TxtSend.Location = new Point(665, 565);
            TxtSend.Name = "TxtSend";
            TxtSend.Size = new Size(228, 34);
            TxtSend.TabIndex = 10;
            TxtSend.KeyDown += TxtSend_KeyDown;
            // 
            // BtnSend
            // 
            BtnSend.Location = new Point(900, 565);
            BtnSend.Margin = new Padding(4);
            BtnSend.Name = "BtnSend";
            BtnSend.Size = new Size(95, 34);
            BtnSend.TabIndex = 9;
            BtnSend.Text = "전송";
            BtnSend.UseVisualStyleBackColor = true;
            BtnSend.Click += BtnSend_Click;
            // 
            // SamePicture
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 615);
            Controls.Add(TxtChannel);
            Controls.Add(TxtSend);
            Controls.Add(BtnSend);
            Controls.Add(panel1);
            Controls.Add(TlpSamePic);
            Margin = new Padding(4);
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
        private Panel panel1;
        private Label label1;
        private RichTextBox TxtChannel;
        private TextBox TxtSend;
        private Button BtnSend;
    }
}