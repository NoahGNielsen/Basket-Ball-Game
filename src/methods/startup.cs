namespace Basket_Ball_Game
{
    static class Startup
    {
        public static void Start()
        {
            Console.WriteLine("Hello World");
            Thread.Sleep(500); // wait for Form1 to open
            gameScoreMngr.StartGoalChecking();
        }
    }
}