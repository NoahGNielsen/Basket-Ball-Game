namespace Basket_Ball_Game
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            picBox_map = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picBox_map).BeginInit();
            SuspendLayout();
            // 
            // picBox_map
            // 
            picBox_map.Image = Properties.Resources.map_basketBallCourt;
            picBox_map.Location = new Point(10, 9);
            picBox_map.Margin = new Padding(3, 2, 3, 2);
            picBox_map.Name = "picBox_map";
            picBox_map.Size = new Size(1822, 1032);
            picBox_map.TabIndex = 1;
            picBox_map.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1806, 993);
            Controls.Add(picBox_map);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            FormScreenCaptureMode = ScreenCaptureMode.HideWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picBox_map).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picBox_map;
    }
}
