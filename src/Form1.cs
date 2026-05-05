namespace Basket_Ball_Game
{
    public partial class Form1 : Form
    {
        Player1 player1;
        Ball ball;
        public int xP1 = 0;
        public int y = GlobalConfig.pFieldY;
        public int ballStartingHeight = 200;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            player1 = new Player1(this);
            player1.Move(xP1, y);

            ball = new Ball(this);
            ball.startP(GlobalConfig.gameSizeX / 2, GlobalConfig.pFieldY - ballStartingHeight);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int scoreOffset = 100; // in px

            this.Size = new Size(GlobalConfig.gameSizeX, GlobalConfig.gameSizeY); //sets window size

            // sets ui elements
            label_scoreTitle.Location = new Point((GlobalConfig.gameSizeX / 2) - label_scoreTitle.Width / 2, label_scoreTitle.Location.Y);
            label_scoreTeam1.Location = new Point(-scoreOffset + ((GlobalConfig.gameSizeX / 2) - label_scoreTeam1.Width), label_scoreTeam1.Location.Y);
            label_scoreTeam2.Location = new Point(scoreOffset + (GlobalConfig.gameSizeX / 2), label_scoreTeam1.Location.Y);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            // Check if the key pressed is the 'D' key
            if (e.KeyCode == Keys.D)
            {
                // Place your logic here (e.g., move the player right)
                xP1 += GlobalConfig.playerMovementSpeed;
                player1.Move(xP1, y);
            }
            else if (e.KeyCode == Keys.A)
            {
                // Place your logic here (e.g., move the player right)
                xP1 -= GlobalConfig.playerMovementSpeed;
                player1.Move(xP1, y);
            }
            else if (e.KeyCode == Keys.R)
            {
                ball.VectorMovement(0, 0); // (x,y) vector velocity
            }

            else if (e.KeyCode == Keys.G)
            {
                ball.VectorMovement(-10, 0); // (x,y) vector velocity
            }
            else if (e.KeyCode == Keys.J)
            {
                ball.VectorMovement(10, 0); // (x,y) vector velocity
            }
            else if (e.KeyCode == Keys.Y)
            {
                ball.VectorMovement(0, 10); // (x,y) vector velocity
            }
            else if (e.KeyCode == Keys.H)
            {
                ball.VectorMovement(0, -10); // (x,y) vector velocity
            }

        }
    }
}
