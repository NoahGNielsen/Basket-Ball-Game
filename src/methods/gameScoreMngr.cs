namespace Basket_Ball_Game
{
    internal static class gameScoreMngr
    {
        static int team1Score = 0;
        static int team2Score = 0;

        private static Thread? _goalCheckThread;
        private static volatile bool _running = false;
        private static Form1? _form;

        // Call this once when the game starts to begin goal detection
        public static void StartGoalChecking(Form1 form)
        {
            _form = form;
            _running = true;

            _goalCheckThread = new Thread(GoalCheckLoop);
            _goalCheckThread.IsBackground = true; // thread dies when main app closes
            _goalCheckThread.Start();
        }

        // Call this when the game ends / form closes
        public static void StopGoalChecking()
        {
            _running = false;
        }

        // Runs on background thread, checks every GlobalConfig.gameUpdateRate ms
        private static void GoalCheckLoop()
        {
            while (_running)
            {
                checkGoalArea();
                Thread.Sleep(GlobalConfig.gameUpdateRate);
            }
        }

        // Gets the ball's current bounding rectangle from the UI thread safely
        private static Rectangle GetBallBounds()
        {
            if (_form == null) return Rectangle.Empty;

            Rectangle bounds = Rectangle.Empty;
            _form.Invoke(new Action(() =>
            {
                bounds = _form.picBox_basketBall.Bounds;
            }));
            return bounds;
        }

        // Checks whether the ball center is inside a goal area
        private static bool IsInGoalArea(Point ballCenter, int x1, int y1, int x2, int y2)
        {
            int left = Math.Min(x1, x2);
            int right = Math.Max(x1, x2);
            int top = Math.Min(y1, y2);
            int bottom = Math.Max(y1, y2);

            return ballCenter.X >= left && ballCenter.X <= right &&
                   ballCenter.Y >= top && ballCenter.Y <= bottom;
        }

        private static void checkGoalArea()
        {
            Rectangle ballBounds = GetBallBounds();
            if (ballBounds == Rectangle.Empty) return;

            // Use the center of the ball sprite for the position check
            Point ballCenter = new Point(
                ballBounds.X + ballBounds.Width / 2,
                ballBounds.Y + ballBounds.Height / 2
            );

            // Left hoop (team1GoalX/Y) -> team 2 scores
            if (IsInGoalArea(
                    ballCenter,
                    GlobalConfig.team1GoalX1, GlobalConfig.team1GoalY1,
                    GlobalConfig.team1GoalX2, GlobalConfig.team1GoalY2))
            {
                addPoint(2);
            }

            // Right hoop (team2GoalX/Y) -> team 1 scores
            if (IsInGoalArea(
                    ballCenter,
                    GlobalConfig.team2GoalX1, GlobalConfig.team2GoalY1,
                    GlobalConfig.team2GoalX2, GlobalConfig.team2GoalY2))
            {
                addPoint(1);
            }
        }

        // Returns the score of a team
        public static int getScore(int team)
        {
            if (team == 1) return team1Score;
            if (team == 2) return team2Score;
            return -1;
        }

        // Add a point to a team
        public static bool addPoint(int team)
        {
            if (team == 1)
            {
                team1Score += GlobalConfig.pointAddOnGoal;
                updateScoreDisplay();
                return true;
            }
            else if (team == 2)
            {
                team2Score += GlobalConfig.pointAddOnGoal;
                updateScoreDisplay();
                return true;
            }
            return false;
        }

        public static void updateScoreDisplay()
        {
            Form1? form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (form != null)
            {
                form.Invoke(new Action(() =>
                {
                    form.label_scoreTeam1.Text = team1Score.ToString();
                    form.label_scoreTeam2.Text = team2Score.ToString();
                }));
            }
        }

        static void resetScore()
        {
            team1Score = 0;
            team2Score = 0;
            updateScoreDisplay();
        }
    }
}