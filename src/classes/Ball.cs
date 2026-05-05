using Basket_Ball_Game.methods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket_Ball_Game
{
    public class Ball
    {
        public double bx;
        public double by;

        double gravity = 9.82;
        double velocity = 0;
        double bouncyness = 0.9;




        private Form1 _form;

        public Ball(Form1 form)
        {
            _form = form;


        }
        public void UpdateBox()
        {
            // _form.P1.Location = new Point(pX, pY);
        }

        public void startP(int x, int y)
        {
            bx = Convert.ToDouble(x - (_form.picBox_basketBall.Size.Width / 2));
            by = Convert.ToDouble(y - _form.picBox_basketBall.Size.Height);
            _form.picBox_basketBall.Location = new Point(Convert.ToInt32(bx), Convert.ToInt32(by));
        }

        public void VectorMovement()
        {
            while (_form.picBox_basketBall.Location.Y < GlobalConfig.pFieldY)
            {
                velocity += gravity;
                by += +velocity;
                _form.picBox_basketBall.Location = new Point(Convert.ToInt32(bx), Convert.ToInt32(by));
            }

            if (_form.picBox_basketBall.Location.Y > GlobalConfig.pFieldY)
            {
                velocity = -velocity * bouncyness;

                while (velocity >= 1);
                {
                    by += +velocity;
                    _form.picBox_basketBall.Location = new Point(Convert.ToInt32(bx), Convert.ToInt32(by));
                    velocity += gravity;
                    VectorMovement();
                }
            }
        }
    }
}
