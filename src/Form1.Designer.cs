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
            label1 = new Label();
            label2 = new Label();
            P2 = new PictureBox();
            p1Cooldown = new Label();
            p2Cooldown = new Label();
            GameStartTimer = new Label();
            ((System.ComponentModel.ISupportInitialize)P1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBox_basketBall).BeginInit();
            ((System.ComponentModel.ISupportInitialize)P2).BeginInit();
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
            P1.Location = new Point(1156, 453);
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
            picBox_basketBall.Location = new Point(884, 117);
            picBox_basketBall.Name = "picBox_basketBall";
            picBox_basketBall.Size = new Size(75, 75);
            picBox_basketBall.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox_basketBall.TabIndex = 6;
            picBox_basketBall.TabStop = false;
            picBox_basketBall.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 10;
            label1.Text = "label1 Debug";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 29);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 11;
            label2.Text = "label2 Debug";
            // 
            // P2
            // 
            P2.BackColor = Color.Transparent;
            P2.ErrorImage = null;
            P2.Image = Properties.Resources.Person_sprite_Scaled_down;
            P2.InitialImage = null;
            P2.Location = new Point(588, 453);
            P2.Margin = new Padding(3, 4, 3, 4);
            P2.Name = "P2";
            P2.Size = new Size(90, 300);
            P2.TabIndex = 12;
            P2.TabStop = false;
            P2.Visible = false;
            // 
            // p1Cooldown
            // 
            p1Cooldown.AutoSize = true;
            p1Cooldown.Location = new Point(575, 429);
            p1Cooldown.Name = "p1Cooldown";
            p1Cooldown.Size = new Size(117, 20);
            p1Cooldown.TabIndex = 13;
            p1Cooldown.Text = "Cooldown: N/As";
            // 
            // p2Cooldown
            // 
            p2Cooldown.AutoSize = true;
            p2Cooldown.Location = new Point(1143, 429);
            p2Cooldown.Name = "p2Cooldown";
            p2Cooldown.Size = new Size(117, 20);
            p2Cooldown.TabIndex = 14;
            p2Cooldown.Text = "Cooldown: N/As";
            // 
            // GameStartTimer
            // 
            GameStartTimer.AutoSize = true;
            GameStartTimer.BackColor = Color.Transparent;
            GameStartTimer.Font = new Font("Segoe UI", 30F);
            GameStartTimer.Location = new Point(834, 314);
            GameStartTimer.Name = "GameStartTimer";
            GameStartTimer.Size = new Size(56, 67);
            GameStartTimer.TabIndex = 15;
            GameStartTimer.Text = "0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.map_basketBallCourt;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1762, 947);
            Controls.Add(GameStartTimer);
            Controls.Add(p2Cooldown);
            Controls.Add(p1Cooldown);
            Controls.Add(P2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(picBox_basketBall);
            Controls.Add(P1);
            Controls.Add(label_scoreTeam2);
            Controls.Add(label_scoreTeam1);
            Controls.Add(label_scoreTitle);
            DoubleBuffered = true;
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
            ((System.ComponentModel.ISupportInitialize)P2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public PictureBox P1;
        internal Label label_scoreTeam1;
        internal Label label_scoreTeam2;
        public PictureBox picBox_basketBall;
        public Label label_scoreTitle;
        public Label label1;
        public Label label2;
        public PictureBox P2;
        public Label p1Cooldown;
        public Label p2Cooldown;
        public Label GameStartTimer;
    }
}
