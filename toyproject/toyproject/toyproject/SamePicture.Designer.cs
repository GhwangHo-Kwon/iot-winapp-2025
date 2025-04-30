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
            listView1 = new ListView();
            SuspendLayout();
            // 
            // ImlCatchImg
            // 
            ImlCatchImg.ColorDepth = ColorDepth.Depth32Bit;
            ImlCatchImg.ImageSize = new Size(16, 16);
            ImlCatchImg.TransparentColor = Color.Transparent;
            // 
            // listView1
            // 
            listView1.Location = new Point(280, 138);
            listView1.Name = "listView1";
            listView1.Size = new Size(121, 97);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // SamePicture
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            Name = "SamePicture";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SamePicture";
            FormClosing += SamePicture_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private ImageList ImlCatchImg;
        private ListView listView1;
    }
}