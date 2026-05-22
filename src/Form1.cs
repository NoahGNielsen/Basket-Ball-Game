namespace Basket_Ball_Game
{
    public partial class Form1 : Form
    {
        PhysicsThread physics;
        public int xP1 = 0;
        public int xP2 = 1790;
        public int y;
        public int ballStartingHeight = 200;
        public bool start;
        public Form1()
        {
            InitializeComponent();

            // le holy grail
            //
            this.Text = "Thy utmost exquisite festive exhibition of projectiles, wherein spherical entities are deliberately propelled through the air"; // NO QUESTIONS
            //
            // these lines are dedecated to praise 'le name'
            
            this.ClientSize = new Size(GlobalConfig.gameSizeX, GlobalConfig.gameSizeY);
            GlobalConfig.gameSizeX = this.ClientSize.Width;

            y = GlobalConfig.pFieldY;

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);

            this.KeyPreview = true;

            physics = new PhysicsThread(this);


            physics.theGreatReset = true;
            physics.StartEngine();
            
            physics.startP((GlobalConfig.gameSizeX - picBox_basketBall.Width) / 2, GlobalConfig.pFieldY - ballStartingHeight);
            physics.moveP1(xP1, y);
            physics.moveP2(xP2 - P2.Width-20, y);

            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int scoreOffset = 100; // in px

            // sets ui elements posision
            label_scoreTitle.Location = new Point((GlobalConfig.gameSizeX / 2) - label_scoreTitle.Width / 2, label_scoreTitle.Location.Y);
            label_scoreTeam1.Location = new Point(-scoreOffset + ((GlobalConfig.gameSizeX / 2) - label_scoreTeam1.Width), label_scoreTeam1.Location.Y);
            label_scoreTeam2.Location = new Point(scoreOffset + (GlobalConfig.gameSizeX / 2), label_scoreTeam1.Location.Y);
            GameStartTimer.Hide();



            // Debug stuff
            label1.Hide();
            label2.Hide();

            //Debugging location
            //label2.Location = new Point(0, 0);
            //label2.BackColor = Color.Red;

            picBox_basketBall.BackColor = Color.Transparent;
            P1.BackColor = Color.White;
            //P2.BackColor = Color.Transparent;

        }


        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            // Player 1
            if (e.KeyCode == Keys.D) physics.moveRight1 = true;
            if (e.KeyCode == Keys.A) physics.moveLeft1 = true;
            if (e.KeyCode == Keys.Space) physics.jump1 = true;
            if (e.KeyCode == Keys.ControlKey) physics.pitchUp1 = true;
            if (e.KeyCode == Keys.ShiftKey) physics.pitchDown1 = true;
            if (e.KeyCode == Keys.F) physics.greenFN1 = true;

            // Player 2
            if (e.KeyCode == Keys.Right) physics.moveRight2 = true;
            if (e.KeyCode == Keys.Left) physics.moveLeft2 = true;
            if (e.KeyCode == Keys.Up) physics.jump2 = true;
            if (e.KeyCode == Keys.OemSemicolon) physics.pitchUp2 = true;
            if (e.KeyCode == Keys.Oem2) physics.pitchDown2 = true;
            if (e.KeyCode == Keys.Oem6) physics.greenFN2 = true;

            //Resetting
            if (e.KeyCode == Keys.Y)
            {
                physics.Stop();
            }

            //Starting
            if (e.KeyCode == Keys.T)
            {
                start = true;
            }

            ////Debugging
            //if (e.KeyCode == Keys.V) physics.dropBall = true;
            //if (e.KeyCode == Keys.G) physics.deXl = true;
            //if (e.KeyCode == Keys.J) physics.deXr = true;
            //if (e.KeyCode == Keys.Y) physics.deYu = true;
            //if (e.KeyCode == Keys.H) physics.deYd = true;

            // Key debugging
            //label2.Text = Convert.ToString(e.KeyCode);

            //// Debugging ball controll
            //if (e.KeyCode == Keys.G)
            //{
            //    physics.VectorMovement(-10, 0); // (x,y) vector velocity
            //}
            //if (e.KeyCode == Keys.J)
            //{
            //    physics.VectorMovement(10, 0); // (x,y) vector velocity
            //}

            // (x,y) vector velocity
            //}
            //if (e.KeyCode == Keys.H)
            //{
            //    physics.VectorMovement(0, -10); // (x,y) vector velocity
            //}
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // Player 1
            if (e.KeyCode == Keys.D) physics.moveRight1 = false;
            if (e.KeyCode == Keys.A) physics.moveLeft1 = false;
            if (e.KeyCode == Keys.Space) physics.jump1 = false;
            if (e.KeyCode == Keys.ControlKey) physics.pitchUp1 = false;
            if (e.KeyCode == Keys.ShiftKey) physics.pitchDown1 = false;
            if (e.KeyCode == Keys.F) physics.greenFN1 = false;
            if (e.KeyCode == Keys.V) physics.dropBall = false;

            // Player 2
            if (e.KeyCode == Keys.Right) physics.moveRight2 = false;
            if (e.KeyCode == Keys.Left) physics.moveLeft2 = false;
            if (e.KeyCode == Keys.Up) physics.jump2 = false;
            if (e.KeyCode == Keys.OemSemicolon) physics.pitchUp2 = false;
            if (e.KeyCode == Keys.Oem2) physics.pitchDown2 = false;
            if (e.KeyCode == Keys.Oem6) physics.greenFN2 = false;


            //// Debugging
            //if (e.KeyCode == Keys.G) physics.deXl = false;
            //if (e.KeyCode == Keys.J) physics.deXr = false;
            //if (e.KeyCode == Keys.Y) physics.deYu = false;
            //if (e.KeyCode == Keys.H) physics.deYd = false;
            //if (e.KeyCode == Keys.V) physics.dropBall = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            if (physics == null) return;

            //Drawing the Ball w rolling
            var stateb = e.Graphics.Save();

            float x = (float)physics.bx;
            float y = (float)physics.by;
            float size = 75f;

            // Move origin to center of the ball
            e.Graphics.TranslateTransform(
                x + size / 2f,
                y + size / 2f
            );

            // Rotate (degrees)
            e.Graphics.RotateTransform((float)physics.broll);

            // Move origin back
            e.Graphics.TranslateTransform(-size / 2f, -size / 2f);

            // Draw ball
            e.Graphics.DrawImage(
                Properties.Resources.sprite_basketBall,
                0f,
                0f,
                size,
                size
            );

            e.Graphics.Restore(stateb);

            //Drawing the Player 1
            e.Graphics.DrawImage(Properties.Resources.Person_sprite_Scaled_down,
                (int)physics.x1, (int)physics.y1,
                100, 300);

            float shoulderX = (float)physics.x1 + 50; // Adjust these numbers 
            float shoulderY = (float)physics.y1 + 111; // to match your sprite's shoulder

            // visual rotation
            var state = e.Graphics.Save(); // Save the screen state
            e.Graphics.TranslateTransform(shoulderX, shoulderY); // Move 'pen' to shoulder
            e.Graphics.RotateTransform(physics.armAngle1);       // Spin the 'pen'

            // Draw the Arm 
            e.Graphics.DrawImage(Properties.Resources.Person_arm_Scaled_down, 0, -16, 150, 32);
            e.Graphics.Restore(state);

            //Drawing the locator arrow
            if (physics.by < -50) // Only show if the ball is above the visible area
            {
                float arrowX = Convert.ToSingle(physics.bx) - 15;
                arrowX = Math.Max(20, Math.Min(this.ClientSize.Width - 20, arrowX));

                float distance = Convert.ToSingle(Math.Abs(physics.by));
                float scale = 2000f / (2000f + distance); // If distance is 0, scale is 1.0. If distance is 1000, scale is 0.5.
                scale = Math.Max(0.4f, scale);


                var arrowState = e.Graphics.Save();

                // Drawing shi
                e.Graphics.TranslateTransform(arrowX + (75 / 2), 30);
                e.Graphics.ScaleTransform(scale, scale);
                e.Graphics.RotateTransform(-90);
                e.Graphics.DrawImage(Properties.Resources.Arrow_Scaled_down, -15, 0, 30, 30);
                e.Graphics.Restore(arrowState);
            }

            //Drawing the Player 2
            e.Graphics.DrawImage(Properties.Resources.Person_sprite_Scaled_down,
                (int)physics.x2, (int)physics.y2,
                100, 300);

            float shoulderX1 = (float)physics.x2 + 50; // Adjust these numbers 
            float shoulderY1 = (float)physics.y2 + 111; // to match your sprite's shoulder

            // visual rotation
            var state1 = e.Graphics.Save(); // Save the screen state
            e.Graphics.TranslateTransform(shoulderX1, shoulderY1); // Move 'pen' to shoulder
            e.Graphics.RotateTransform(physics.armAngle2);       // Spin the 'pen'

            // Draw the Arm 
            e.Graphics.DrawImage(Properties.Resources.Person_arm_Scaled_down, 0, -16, 150, 32);
            e.Graphics.Restore(state1);
        }
    }
}
