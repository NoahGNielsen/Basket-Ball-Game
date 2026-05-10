namespace Basket_Ball_Game
{
    public static class GlobalConfig //settings
    {
        public readonly static bool debugMode = true; //default: false
        public readonly static int pointAddOnGoal = 1; //default: 1
        public readonly static int playerMovementSpeed = 20; //default: placeHolder
        public readonly static int playerMovementJumpHeight = 20; //default: placeHolder
        public readonly static int playerThrowingPower = 10; //default: placeHolder
        public readonly static int ballMovementSpeed = 15; //default: placeHolder
        public readonly static int gameSizeX = 1796; //default: 1796
        public readonly static int gameSizeY = 1031; //default: 1032
        public readonly static int pFieldY = 850;
        public readonly static int gameUpdateRate = 1000/60; //default: ~16 (60 times per second)

        // Physics elements
        public readonly static double gFriction = 0.9;  // 0 is the highest
        public readonly static double bouncyness = 0.9; // 0 == no bouncing
        public readonly static double gravity = 0.8;    // bigger == more gravity  

        public static class BackboardLeft 
        {
            // Backboard Coords
            public readonly static int xL = 143;    //left x default: 143
            public readonly static int xR = 165;    //right x default: 165
            public readonly static int yB = 430;    //bottom y default: 430
            public readonly static int yT = 240;    //top y default: 240
        }
        public static class BackboardRight
        {
            // Backboard Coords
            public readonly static int xL = 1617;   //left x default: 1617
            public readonly static int xR = 1639;   //right x default: 1639
            public readonly static int yB = 430;    //bottom y default: 430
            public readonly static int yT = 240;    //top y default: 240
        }
        public static class rimLeft
        {
            // Backboard Coords
            public readonly static int xL = 185;    //left x default: 183
            public readonly static int xR = 175;    //right x default: 175
            public readonly static int xL2 = 330;   //left x default: 330
            public readonly static int xR2 = 340;   //right x default: 340
            public readonly static int yB = 360;    //bottom y default: 360
            public readonly static int yT = 350;    //top y default: 350
        }
        public static class rimRight
        {
            // Backboard Coords
            public readonly static int xL = 1585;   //left x default: 1585
            public readonly static int xR = 1595;   //right x default: 1595
            public readonly static int xL2 = 1440;  //left x default: 1440
            public readonly static int xR2 = 1430;  //right x default: 1430
            public readonly static int yB = 360;    //bottom y default: 360
            public readonly static int yT = 350;    //top y default: 350
        }


        //Goal Area Coordinates - Left Hoop
        public readonly static int team1GoalX1 = 190; //default: 190
        public readonly static int team1GoalX2 = 340; //default: 340
        public readonly static int team1GoalY1 = 360; //default: 360
        public readonly static int team1GoalY2 = 360; //default: 360
        //Goal Area Coordinates - Right Hoop
        public readonly static int team2GoalX1 = 1445; //default: 1445
        public readonly static int team2GoalX2 = 1600; //default: 1600
        public readonly static int team2GoalY1 = 360; //default: 360
        public readonly static int team2GoalY2 = 360; //default: 360
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
            Console.WriteLine("Hello");
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}