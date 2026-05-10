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

            velocityY += vY;
            velocityX += vX;

            if (isRunning) return;

            isRunning = true;
            physicsThread = new Thread(PhysicsLoop);
            physicsThread.IsBackground = true;
            physicsThread.Start();
        }

        private void PhysicsLoop()
        {
            while (isRunning)
            {
                //Applying gravity
                velocityY += GlobalConfig.gravity;
                
                //Sub-stepping
                // 8 steps == check pr. 5 pixels
                int subSteps = 8;
                double stepX = velocityX / subSteps;
                double stepY = velocityY / subSteps;

                for (int i = 0; i < subSteps; i++)
                {
                    // moving by a fraction of actual speed
                    bx += stepX;
                    by += stepY;


                    // Floor detec
                    if (by > GlobalConfig.pFieldY - _form.picBox_basketBall.Height)
                    {
                        by = GlobalConfig.pFieldY - _form.picBox_basketBall.Height;
                        velocityY = -velocityY * GlobalConfig.bouncyness;
                        velocityX = velocityX * GlobalConfig.gFriction;
                        if (Math.Abs(velocityY) < 1.5) velocityY = 0;
                    }

                    // Wall detec
                    if (bx < 0) { bx = 0; velocityX = -velocityX * GlobalConfig.bouncyness; }
                    int rightWall = _form.ClientSize.Width - _form.picBox_basketBall.Width;
                    if (bx > rightWall) { bx = rightWall; velocityX = -velocityX * GlobalConfig.bouncyness; }

                    // Backboard detec
                    CheckBounce(GlobalConfig.BackboardLeft.xL, GlobalConfig.BackboardLeft.xR,
                                GlobalConfig.BackboardLeft.yT, GlobalConfig.BackboardLeft.yB);
                    CheckBounce(GlobalConfig.BackboardRight.xL, GlobalConfig.BackboardRight.xR,
                                GlobalConfig.BackboardRight.yT, GlobalConfig.BackboardRight.yB);

                    // Rim (Left and Right) detec
                    CheckBounce(GlobalConfig.rimLeft.xL, GlobalConfig.rimLeft.xR, GlobalConfig.rimLeft.yT, GlobalConfig.rimLeft.yB);
                    CheckBounce(GlobalConfig.rimLeft.xL2, GlobalConfig.rimLeft.xR2, GlobalConfig.rimLeft.yT, GlobalConfig.rimLeft.yB);

                    CheckBounce(GlobalConfig.rimRight.xL, GlobalConfig.rimRight.xR, GlobalConfig.rimRight.yT, GlobalConfig.rimRight.yB);
                    CheckBounce(GlobalConfig.rimRight.xL2, GlobalConfig.rimRight.xR2, GlobalConfig.rimRight.yT, GlobalConfig.rimRight.yB);

                    //recalculating step size after bounce
                    stepX = velocityX / subSteps;
                    stepY = velocityY / subSteps;

                    double distanceOffScreen = Math.Abs(by);
                    int simpleHeight = 60 - (int)(distanceOffScreen / 20);
                    if (simpleHeight < 10) simpleHeight = 10;

                    // 2. Logic Check
                    bool isOffScreen = (by + _form.picBox_basketBall.Height) < 20;

                    _form.Invoke((MethodInvoker)delegate
                    {
                        // 
                        if (isOffScreen && !_form.LocatorArrow.Visible)
                        {
                            _form.LocatorArrow.Visible = true;
                        }
                        else if (!isOffScreen && _form.LocatorArrow.Visible)
                        {
                            _form.LocatorArrow.Visible = false;
                        }

                        // Update if the arrow is being shown
                        if (isOffScreen)
                        {
                            _form.LocatorArrow.Height = simpleHeight;
                            _form.LocatorArrow.Left = (int)bx + (_form.picBox_basketBall.Width / 2) - (_form.LocatorArrow.Width / 2);
                        }
                    });
                }

                    //UI Updater
                    if (!_form.IsDisposed && _form.picBox_basketBall.IsHandleCreated)
                {
                    // displays locator arrow

                    _form.Invoke((MethodInvoker)delegate {
                        _form.picBox_basketBall.Location = new Point((int)bx, (int)by);
                    });
                }

                Thread.Sleep(GlobalConfig.gameUpdateRate);
            }
        }




        private void CheckBounce(int x1, int x2, int y1, int y2) // Square to circle
        {
            double radius = _form.picBox_basketBall.Width / 2;
            double centerX = bx + radius;
            double centerY = by + radius;

            // Finds the closest point on the hitbox to the ball center
            double closestX = Math.Max(x1, Math.Min(centerX, x2));
            double closestY = Math.Max(y1, Math.Min(centerY, y2));

            // Calculates the distance
            double diffX = centerX - closestX;
            double diffY = centerY - closestY;
            double distance = Math.Sqrt(diffX * diffX + diffY * diffY);

            // Collision detection
            if (distance < radius && distance > 0)
            {
                // Calculates the reflection if it was square on square
                double normalX = diffX / distance;
                double normalY = diffY / distance;

                // Prevents the ball from getting stuck inside hitbox
                double overlap = radius - distance;
                bx += normalX * overlap;
                by += normalY * overlap;

                // Calculates how the velocity vector reflects off the surface
                double dotProduct = (velocityX * normalX) + (velocityY * normalY);

                velocityX = (velocityX - 2 * dotProduct * normalX) * GlobalConfig.bouncyness;
                velocityY = (velocityY - 2 * dotProduct * normalY) * GlobalConfig.bouncyness;
            }
        }
    }
}