namespace Basket_Ball_Game
{
    public partial class Form1 : Form
    {
        public int x = 0;
        public int y = 0;

        public Form1()
        {
            InitializeComponent();
            Player1 obj = new Player1(this);
            obj.UpdateBox();
            obj.Move(x, y);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(GlobalConfig.gameSizeX, GlobalConfig.gameSizeY);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            x = x + 100;
            y = y + 150;
        }
    }
}
