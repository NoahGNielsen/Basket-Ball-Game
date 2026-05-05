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
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)P1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBox_basketBall).BeginInit();
            SuspendLayout();
            // 
            // label_scoreTitle
            // 
            label_scoreTitle.AutoSize = true;
            label_scoreTitle.BackColor = Color.Transparent;
            label_scoreTitle.Font = new Font("Segoe UI", 20F);
            label_scoreTitle.Location = new Point(752, 38);
            label_scoreTitle.Name = "label_scoreTitle";
            label_scoreTitle.Size = new Size(82, 37);
            label_scoreTitle.TabIndex = 2;
            label_scoreTitle.Text = "Score";
            // 
            // label_scoreTeam1
            // 
            label_scoreTeam1.AutoSize = true;
            label_scoreTeam1.BackColor = Color.Transparent;
            label_scoreTeam1.Font = new Font("Segoe UI", 30F);
            label_scoreTeam1.Location = new Point(702, 88);
            label_scoreTeam1.Name = "label_scoreTeam1";
            label_scoreTeam1.Size = new Size(45, 54);
            label_scoreTeam1.TabIndex = 3;
            label_scoreTeam1.Text = "0";
            label_scoreTeam1.Click += label1_Click;
            // 
            // label_scoreTeam2
            // 
            label_scoreTeam2.AutoSize = true;
            label_scoreTeam2.BackColor = Color.Transparent;
            label_scoreTeam2.Font = new Font("Segoe UI", 30F);
            label_scoreTeam2.Location = new Point(844, 88);
            label_scoreTeam2.Name = "label_scoreTeam2";
            label_scoreTeam2.Size = new Size(45, 54);
            label_scoreTeam2.TabIndex = 4;
            label_scoreTeam2.Text = "0";
            // 
            // P1
            // 
            P1.ErrorImage = Properties.Resources.Person_sprite;
            P1.Image = Properties.Resources.Person_sprite;
            P1.InitialImage = Properties.Resources.Person_sprite;
            P1.Location = new Point(356, 424);
            P1.Name = "P1";
            P1.Size = new Size(77, 224);
            P1.SizeMode = PictureBoxSizeMode.Zoom;
            P1.TabIndex = 5;
            P1.TabStop = false;
            // 
            // picBox_basketBall
            // 
            picBox_basketBall.Image = Properties.Resources.sprite_basketBall;
            picBox_basketBall.Location = new Point(531, 240);
            picBox_basketBall.Margin = new Padding(3, 2, 3, 2);
            picBox_basketBall.Name = "picBox_basketBall";
            picBox_basketBall.Size = new Size(66, 56);
            picBox_basketBall.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox_basketBall.TabIndex = 6;
            picBox_basketBall.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(142, 60);
            button1.Name = "button1";
            button1.Size = new Size(177, 65);
            button1.TabIndex = 7;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.map_basketBallCourt;
            ClientSize = new Size(1381, 651);
            Controls.Add(button1);
            Controls.Add(picBox_basketBall);
            Controls.Add(P1);
            Controls.Add(label_scoreTeam2);
            Controls.Add(label_scoreTeam1);
            Controls.Add(label_scoreTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            FormScreenCaptureMode = ScreenCaptureMode.HideWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown_1;
            ((System.ComponentModel.ISupportInitialize)P1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBox_basketBall).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label_scoreTitle;
        public PictureBox P1;
        internal Label label_scoreTeam1;
        internal Label label_scoreTeam2;
        internal PictureBox picBox_basketBall;
        private Button button1;
    }
}
