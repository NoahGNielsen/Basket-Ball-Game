namespace Basket_Ball_Game
{
    public static class GlobalConfig //settings
    {
        public readonly static bool debugMode = true; //default: false
        public readonly static int pointAddOnGoal = 1; //default: 1
        public readonly static int playerMovementSpeed = 5; //default: placeHolder
        public readonly static int playerMovementJumpHeight = 10; //default: placeHolder
        public readonly static int playerThrowingPower = 10; //default: placeHolder
        public readonly static int ballMovementSpeed = 5; //default: placeHolder
        public readonly static int gameSizeX = 1822; //default: 1822
        public readonly static int gameSizeY = 1032; //default: 1032
        public readonly static int pFieldY = 636;
        public readonly static int gameUpdateRate = 16; //default: 16 (60 times per second)

        //Goal Area Coordinates - Left Hoop
        public readonly static int team1GoalX1 = 0; //default: placeholder
        public readonly static int team1GoalX2 = 0; //default: placeholder
        public readonly static int team1GoalY1 = 0; //default: placeholder
        public readonly static int team1GoalY2 = 0; //default: placeholder
        //Goal Area Coordinates - Right Hoop
        public readonly static int team2GoalX1 = 0; //default: placeholder
        public readonly static int team2GoalX2 = 0; //default: placeholder
        public readonly static int team2GoalY1 = 0; //default: placeholder
        public readonly static int team2GoalY2 = 0; //default: placeholder
    }
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Task.Run(() => Startup.Start());
            gameScoreMngr.StartGoalChecking(this);
            Console.WriteLine("Hello");
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}