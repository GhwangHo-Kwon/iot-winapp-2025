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
            TxtCmd = new TextBox();
            label1 = new Label();
            TxtChannel = new RichTextBox();
            TxtSend = new TextBox();
            BtnSend = new Button();
            FlpParticipant = new FlowLayoutPanel();
            panel2 = new Panel();
            label2 = new Label();
            FlpStatus = new FlowLayoutPanel();
            BtnStart = new Button();
            ChkBoss = new CheckBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            FlpStatus.SuspendLayout();
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
            TlpSamePic.RowStyles.Add(new RowStyle(SizeType.Absolute, 350F));
            TlpSamePic.Size = new Size(500, 350);
            TlpSamePic.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(TxtCmd);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 58);
            panel1.TabIndex = 3;
            // 
            // TxtCmd
            // 
            TxtCmd.BorderStyle = BorderStyle.FixedSingle;
            TxtCmd.Location = new Point(0, 0);
            TxtCmd.Name = "TxtCmd";
            TxtCmd.Size = new Size(100, 23);
            TxtCmd.TabIndex = 13;
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
            label1.Text = "같 은 그 림 찾 기";
            label1.TextAlign = ContentAlignment.MiddleCenter;
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
            TxtChannel.Size = new Size(258, 368);
            TxtChannel.TabIndex = 11;
            TxtChannel.TabStop = false;
            TxtChannel.Text = "";
            // 
            // TxtSend
            // 
            TxtSend.Font = new Font("맑은 고딕", 12F);
            TxtSend.Location = new Point(517, 424);
            TxtSend.Margin = new Padding(2);
            TxtSend.Name = "TxtSend";
            TxtSend.Size = new Size(178, 29);
            TxtSend.TabIndex = 10;
            TxtSend.KeyDown += TxtSend_KeyDown;
            // 
            // BtnSend
            // 
            BtnSend.Location = new Point(700, 424);
            BtnSend.Name = "BtnSend";
            BtnSend.Size = new Size(74, 26);
            BtnSend.TabIndex = 9;
            BtnSend.Text = "전송";
            BtnSend.UseVisualStyleBackColor = true;
            BtnSend.Click += BtnSend_Click;
            // 
            // FlpParticipant
            // 
            FlpParticipant.AutoScroll = true;
            FlpParticipant.FlowDirection = FlowDirection.TopDown;
            FlpParticipant.Location = new Point(780, 58);
            FlpParticipant.Name = "FlpParticipant";
            FlpParticipant.Size = new Size(142, 395);
            FlpParticipant.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Location = new Point(780, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(142, 40);
            panel2.TabIndex = 12;
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
            // FlpStatus
            // 
            FlpStatus.Controls.Add(BtnStart);
            FlpStatus.Controls.Add(ChkBoss);
            FlpStatus.FlowDirection = FlowDirection.RightToLeft;
            FlpStatus.Location = new Point(518, 385);
            FlpStatus.Name = "FlpStatus";
            FlpStatus.Size = new Size(257, 34);
            FlpStatus.TabIndex = 14;
            // 
            // BtnStart
            // 
            BtnStart.Anchor = AnchorStyles.Right;
            BtnStart.Location = new Point(179, 3);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(75, 28);
            BtnStart.TabIndex = 0;
            BtnStart.Text = "시작";
            BtnStart.UseVisualStyleBackColor = true;
            BtnStart.Click += BtnStart_Click;
            // 
            // ChkBoss
            // 
            ChkBoss.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            ChkBoss.Enabled = false;
            ChkBoss.Location = new Point(123, 7);
            ChkBoss.Name = "ChkBoss";
            ChkBoss.Size = new Size(50, 20);
            ChkBoss.TabIndex = 0;
            ChkBoss.Text = "방장";
            ChkBoss.UseVisualStyleBackColor = true;
            // 
            // SamePicture
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 461);
            Controls.Add(FlpStatus);
            Controls.Add(FlpParticipant);
            Controls.Add(panel2);
            Controls.Add(TxtChannel);
            Controls.Add(TxtSend);
            Controls.Add(BtnSend);
            Controls.Add(panel1);
            Controls.Add(TlpSamePic);
            Name = "SamePicture";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SamePicture";
            FormClosing += SamePicture_FormClosing;
            Load += SamePicture_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            FlpStatus.ResumeLayout(false);
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
        private TextBox TxtCmd;
        private FlowLayoutPanel FlpParticipant;
        private Panel panel2;
        private Label label2;
        private FlowLayoutPanel FlpStatus;
        private Button BtnStart;
        private CheckBox ChkBoss;
    }
}