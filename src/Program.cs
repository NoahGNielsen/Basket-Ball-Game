namespace Basket_Ball_Game
{
    public class GlobalConfig //settings
    {
        public readonly static bool debugMode = true; //default: false
        public readonly static int pointAddOnGoal = 1; //default: 1
        public readonly static int ballMovementSpeed = 15; //default: placeHolder

        public static int gameSizeX = 1780; //default: 1780 (DO NOT CHANGE)
        public  static int gameSizeY = 961; //default: 961 (DO NOT CHANGE) (Total height including border 994)
        public readonly static int pFieldY = 850;
        public readonly static int gameUpdateRate = 1000/60; //default: 1000/60 (60 times per second)
        public readonly static int gameResetTimer = 5; // delay before starting new game

        // Player elements:
        public static class Player
        {
            public readonly static int movementSpeed = 20; //default: placeHolder
            public readonly static int jumpHeight = 20; //default: placeHolder

            // Arm
            public readonly static int grabDistance = 35; // Grab distance in px
            public readonly static double reGrabCooldown = 60 * 0.5; // Default: 3s (fps * how many sec cooldown)
            public readonly static int armRotatingSpeed = 4;
            public readonly static int throwingPower = 40; //default: placeHolder
        }

        // Physics elements
        public readonly static double gFriction = 0.9;  // 0 is the highest
        public readonly static double bouncyness = 0.9; // 0 == no bouncing
        public readonly static double gravity = 1.8;    // bigger == more gravity  

        public static class BackboardLeft 
        {
            // Backboard Coords (NO TOUCHING OR BIG BOOM)
            public readonly static int xL = 142;    //left x default: 142
            public readonly static int xR = 165;    //right x default: 165
            public readonly static int yB = 430;    //bottom y default: 430
            public readonly static int yT = 239;    //top y default: 239
        }
        public static class BackboardRight
        {
            // Backboard Coords (NO TOUCHING OR BIG BOOM)
            public readonly static int xL = 1618;   //left x default: 1618
            public readonly static int xR = 1639;   //right x default: 1639
            public readonly static int yB = 430;    //bottom y default: 430
            public readonly static int yT = 239;    //top y default: 239
        }
        public static class rimLeft
        {
            // Rim Coords (NO TOUCHING OR BIG BOOM)
            public readonly static int xL = 185;    //left x default: 185
            public readonly static int xR = 175;    //right x default: 175
            public readonly static int xL2 = 343;   //left2 x default: 343
            public readonly static int xR2 = 333;   //right2 x default: 333
            public readonly static int yB = 350;    //top y default: 350
            public readonly static int yT = 340;    //bottom y default: 340
        }
        public static class rimRight
        {
            // Rim Coords (NO TOUCHING OR BIG BOOM)
            public readonly static int xL = 1588;   //left x default: 1588
            public readonly static int xR = 1598;   //right x default: 1598
            public readonly static int xL2 = 1440;  //left2 x default: 1440
            public readonly static int xR2 = 1430;  //right2 x default: 1430
            public readonly static int yB = 350;    //top y default: 350
            public readonly static int yT = 340;    //bottom y default: 340
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