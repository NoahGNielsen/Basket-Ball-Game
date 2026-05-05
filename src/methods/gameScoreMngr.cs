namespace Basket_Ball_Game
{
    internal static class gameScoreMngr
    {
        static int team1Score = 0;
        static int team2Score = 0;

        //returns the score of a team
        public static int getScore(int team)
        {
            if (team == 1)
            {
                return team1Score;
            }
            else if (team == 2)
            {
                return team2Score;
            }
            else {
                return -1;
            }
        }

        //add point to a team
        public static bool addPoint(int team)
        {
            if (team == 1)
            {
                //add 1 point to team 1
                team1Score += GlobalConfig.pointAddOnGoal;
                updateScoreDisplay();
                return true;
            }
            else if (team == 2)
            {
                //add 1 point to team 2
                team2Score += GlobalConfig.pointAddOnGoal;
                updateScoreDisplay();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void updateScoreDisplay()
        {
            //update the score display on the form
            Form1 form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (form != null)
            {
                form.Invoke(new Action(() =>
                {
                    form.label_scoreTeam1.Text = team1Score.ToString();
                    form.label_scoreTeam2.Text = team2Score.ToString();
                }));
            }
        }

        //reset the score of both teams to 0
        static void resetScore()
        {
            team1Score = 0;
            team2Score = 0;
            updateScoreDisplay();
        }

        static void c //stub, shoud check the ball position and if it is in the goal area, add point to the team that scored. Prob something like 60 times a secound. And also super light weight, so it doesn't lag the game.
        {

        }
    }
}