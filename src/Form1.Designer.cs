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
            label_scoreTitle = new Label();
            label_scoreTeam1 = new Label();
            label_scoreTeam2 = new Label();
            P1 = new PictureBox();
            picBox_basketBall = new PictureBox();
            LocatorArrow = new PictureBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)P1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBox_basketBall).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LocatorArrow).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label_scoreTitle
            // 
            label_scoreTitle.AutoSize = true;
            label_scoreTitle.BackColor = Color.Transparent;
            label_scoreTitle.Font = new Font("Segoe UI", 20F);
            label_scoreTitle.Location = new Point(859, 51);
            label_scoreTitle.Name = "label_scoreTitle";
            label_scoreTitle.Size = new Size(104, 46);
            label_scoreTitle.TabIndex = 2;
            label_scoreTitle.Text = "Score";
            // 
            // label_scoreTeam1
            // 
            label_scoreTeam1.AutoSize = true;
            label_scoreTeam1.BackColor = Color.Transparent;
            label_scoreTeam1.Font = new Font("Segoe UI", 30F);
            label_scoreTeam1.Location = new Point(802, 117);
            label_scoreTeam1.Name = "label_scoreTeam1";
            label_scoreTeam1.Size = new Size(56, 67);
            label_scoreTeam1.TabIndex = 3;
            label_scoreTeam1.Text = "0";
            // 
            // label_scoreTeam2
            // 
            label_scoreTeam2.AutoSize = true;
            label_scoreTeam2.BackColor = Color.Transparent;
            label_scoreTeam2.Font = new Font("Segoe UI", 30F);
            label_scoreTeam2.Location = new Point(965, 117);
            label_scoreTeam2.Name = "label_scoreTeam2";
            label_scoreTeam2.Size = new Size(56, 67);
            label_scoreTeam2.TabIndex = 4;
            label_scoreTeam2.Text = "0";
            // 
            // P1
            // 
            P1.BackColor = Color.Transparent;
            P1.ErrorImage = null;
            P1.Image = Properties.Resources.Person_sprite_Scaled_down;
            P1.InitialImage = null;
            P1.Location = new Point(407, 565);
            P1.Margin = new Padding(3, 4, 3, 4);
            P1.Name = "P1";
            P1.Size = new Size(90, 300);
            P1.TabIndex = 5;
            P1.TabStop = false;
            P1.Visible = false;
            // 
            // picBox_basketBall
            // 
            picBox_basketBall.BackColor = Color.White;
            picBox_basketBall.Image = Properties.Resources.sprite_basketBall;
            picBox_basketBall.Location = new Point(1012, 422);
            picBox_basketBall.Name = "picBox_basketBall";
            picBox_basketBall.Size = new Size(75, 75);
            picBox_basketBall.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox_basketBall.TabIndex = 6;
            picBox_basketBall.TabStop = false;
            picBox_basketBall.Visible = false;
            // 
            // LocatorArrow
            // 
            LocatorArrow.BackColor = Color.Transparent;
            LocatorArrow.Image = Properties.Resources.Arrow;
            LocatorArrow.Location = new Point(95, -4);
            LocatorArrow.Name = "LocatorArrow";
            LocatorArrow.Size = new Size(48, 63);
            LocatorArrow.SizeMode = PictureBoxSizeMode.Zoom;
            LocatorArrow.TabIndex = 8;
            LocatorArrow.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(LocatorArrow);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1780, 63);
            panel1.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.map_basketBallCourt;
            ClientSize = new Size(1778, 984);
            Controls.Add(picBox_basketBall);
            Controls.Add(P1);
            Controls.Add(label_scoreTeam2);
            Controls.Add(label_scoreTeam1);
            Controls.Add(label_scoreTitle);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            FormScreenCaptureMode = ScreenCaptureMode.HideWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Paint += Form1_Paint;
            KeyDown += Form1_KeyDown_1;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)P1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBox_basketBall).EndInit();
            ((System.ComponentModel.ISupportInitialize)LocatorArrow).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public PictureBox P1;
        internal Label label_scoreTeam1;
        internal Label label_scoreTeam2;
        public PictureBox picBox_basketBall;
        public PictureBox LocatorArrow;
        public Label label_scoreTitle;
        private Panel panel1;
    }
}
