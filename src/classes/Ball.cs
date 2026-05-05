using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Basket_Ball_Game
{
    public class Ball
    {
        public double bx;
        public double by;
        public double vX;
        public double vY;

        double velocityY = 0;
        double velocityX  = 0;

        bool isRunning = false;

        private Form1 _form;
        private Thread physicsThread;

        public Ball(Form1 form)
        {
            _form = form;
        }

        // Sets the starting point and prepares the ball
        public void startP(int x, int y)
        {
            bx = Convert.ToDouble(x - (_form.picBox_basketBall.Width / 2));
            by = Convert.ToDouble(y - _form.picBox_basketBall.Height);

            // Move it immediately on the UI thread
            _form.picBox_basketBall.Location = new Point((int)bx, (int)by);

            // Reset velocity for a fresh drop
            velocityY = 0;
        }

        // Starts the background thread for physics
        public void VectorMovement(double vx, double vy)
        {
            vX = vx;
            vY = -vy;

            if (isRunning) return;

            isRunning = true;
            physicsThread = new Thread(PhysicsLoop);
            physicsThread.IsBackground = true;
            physicsThread.Start();
        }

        private void PhysicsLoop()
        {
            velocityY += vY;
            velocityX += vX;

            while (isRunning)
            {
                velocityY += GlobalConfig.gravity;
                by += velocityY;
                bx += velocityX;

                // Floor detection
                if (by > GlobalConfig.pFieldY)
                {
                    by = GlobalConfig.pFieldY; // Sticks it to the floor
                    velocityY = -velocityY * GlobalConfig.bouncyness;
                    velocityX = velocityX * GlobalConfig.gFriction;

                    // stop bouncing if velocity is too low
                    if (Math.Abs(velocityY) < 1.5)
                    {
                        velocityY = 0;
                    }
                }

                if (_form.picBox_basketBall.IsHandleCreated)
                {
                    _form.Invoke((MethodInvoker)delegate {
                        _form.picBox_basketBall.Location = new Point((int)bx, (int)by);
                    });
                }

                Thread.Sleep(GlobalConfig.gameUpdateRate);
            }
        }
    }
}