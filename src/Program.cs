namespace Basket_Ball_Game
{
    public static class GlobalConfig //settings
    {
        // Very fun boolean
        public readonly static bool Chernobyl_V2 = false; // set to true if you want a visual representation of Chernobyl in task manager
        // Did you try setting it to true and looking in task manager?
        // Sure?
        // Very sure?

        public static int gameSizeX = 1780; //default: 1780 (DO NOT CHANGE)
        public static int gameSizeY = 961; //default: 961 (DO NOT CHANGE) (Total height including border 994)
        public readonly static int pFieldY = 850;
        public readonly static int gameUpdateRate = 1000/60; //default: 1000/60 (60 times per second)
        public readonly static int gameResetTimer = 5; // delay before starting new game Default: 5

        // Player elements:
        public static class Player
        {
            public readonly static int movementSpeed = 20; //default: 20
            public readonly static int jumpHeight = 25; //default: 25

            // Arm
            public readonly static int grabDistance = 35; // Grab distance in px
            public readonly static double reGrabCooldown = 60 * 0.5; // Default: 0.5s (fps * how many sec cooldown)
            public readonly static int armRotatingSpeed = 4; // default = 4
            public readonly static int throwingPower = 40; //default: 40
        }

        // Physics elements
        public readonly static double gFriction = 0.9;  // 0 is the highest         Default: 0.9
        public readonly static double airRes = 0.1;  // 0 is the highest            Default: 0.1
        public readonly static double bouncyness = 0.85; // 0 == no bouncing        Default: 0.85
        public readonly static double gravity = 1.8;    // bigger == more gravity   Default: 1.8

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
    }
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Hello");
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}