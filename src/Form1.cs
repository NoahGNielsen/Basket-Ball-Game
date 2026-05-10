namespace Basket_Ball_Game
{
    public partial class Form1 : Form
    {
        PhysicsThread physics;
        public int xP1 = 0;
        public int y = GlobalConfig.pFieldY;
        public int ballStartingHeight = 200;

        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);

            this.KeyPreview = true;

            physics = new PhysicsThread(this);
            physics.VectorMovement(0, 0);
            physics.startP(GlobalConfig.gameSizeX / 2, GlobalConfig.pFieldY - ballStartingHeight);
            physics.moveP1(xP1, y);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int scoreOffset = 100; // in px

            this.Size = new Size(GlobalConfig.gameSizeX, GlobalConfig.gameSizeY); //sets window size

            // sets ui elements posision
            label_scoreTitle.Location = new Point((GlobalConfig.gameSizeX / 2) - label_scoreTitle.Width / 2, label_scoreTitle.Location.Y);
            label_scoreTeam1.Location = new Point(-scoreOffset + ((GlobalConfig.gameSizeX / 2) - label_scoreTeam1.Width), label_scoreTeam1.Location.Y);
            label_scoreTeam2.Location = new Point(scoreOffset + (GlobalConfig.gameSizeX / 2), label_scoreTeam1.Location.Y);

            // Rotates arrow image
            LocatorArrow.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            LocatorArrow.Height = 50;
            LocatorArrow.Hide();
            LocatorArrow.Refresh();

            picBox_basketBall.BackColor = Color.Transparent;
            LocatorArrow.BackColor = Color.White;
            P1.BackColor = Color.White;
            //P2.BackColor = Color.Transparent;

        }

        private void button1_Click_1(object sender, EventArgs e) // Debugging
        {
            //button1.BackColor = Color.Red;
            //x += 100;
            //y -= 150;
            //player1.Move(x, y);
        }


        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D) physics.moveRight = true;
            if (e.KeyCode == Keys.A) physics.moveLeft = true;
            if (e.KeyCode == Keys.W) physics.jump = true;

            else if (e.KeyCode == Keys.R)
            {
                physics.VectorMovement(0, 0); // (x,y) vector velocity
            }


            // Fuckass debugging ball controll
            else if (e.KeyCode == Keys.G)
            {
                physics.VectorMovement(-10, 0); // (x,y) vector velocity
            }
            else if (e.KeyCode == Keys.J)
            {
                physics.VectorMovement(10, 0); // (x,y) vector velocity
            }
            else if (e.KeyCode == Keys.Y)
            {
                physics.VectorMovement(0, 10); // (x,y) vector velocity
            }
            else if (e.KeyCode == Keys.H)
            {
                physics.VectorMovement(0, -10); // (x,y) vector velocity
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D) physics.moveRight = false;
            if (e.KeyCode == Keys.A) physics.moveLeft = false;
            if (e.KeyCode == Keys.W) physics.jump = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            if (physics == null) return;

            //Drawing the Ball
            e.Graphics.DrawImage(Properties.Resources.sprite_basketBall,
                (int)physics.bx, (int)physics.by,
                75, 75);


            //Drawing the Player
            e.Graphics.DrawImage(Properties.Resources.Person_sprite_Scaled_down,
                (int)physics.x1, (int)physics.y1,
                100, 300);

            float shoulderX = (float)physics.x1 + 20; // Adjust these numbers 
            float shoulderY = (float)physics.y1 + 50; // to match your sprite's shoulder

            // 3. Setup Rotation
            var state = e.Graphics.Save(); // Save the screen state
            e.Graphics.TranslateTransform(shoulderX, shoulderY); // Move 'pen' to shoulder
            e.Graphics.RotateTransform(physics.armAngle1);       // Spin the 'pen'

            // 4. Draw the Arm 
            // Draw at 0,0 because we moved the "paper" to the shoulder position already
            // The -5 and -5 offset helps align the arm image so the "joint" is the center
            e.Graphics.DrawImage(Properties.Resources.Person_arm_Scaled_down, 10, 50, 150, 32);
        }

    }
}
