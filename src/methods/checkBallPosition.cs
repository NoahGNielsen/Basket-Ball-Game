using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Basket_Ball_Game.methods
{
    /*
     *  TODO:
     *  - Check for goals and out of bounds
     *  - if the ball is out of bounds, reset the ball to the center of the field
     *  - Check every 16 miliseconds (60 times per second) for the position of the ball
     */

    public class Ball
    {
        private readonly Form1 _ball;

        public Ball(Form1 form)
        {
            _ball = form;
        }

        private static int ballPositionX() //STUB
        {
            return -1;
        }

        private static int ballPositionY() //STUB
        {
            return -1;
        }

        public void checkBallPosition()
        {
            //get the position of the ball
            int ballX = ballPositionX();
            int ballY = ballPositionY();

            //check if the ball is out of bounds

            //check if the ball is in the goal area of team 1


            //check if the ball is in the goal area of team 2
        }
    }
}