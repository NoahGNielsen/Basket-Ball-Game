using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Basket_Ball_Game
{
    public class PhysicsThread
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


        // Player 1
        public bool moveLeft = false;
        public bool moveRight = false;
        public double x1;
        public double y1;
        public double vecy1;
        public bool jump;
        public bool jumping;
        public float armAngle1 = 0;










        public PhysicsThread(Form1 form)
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
        public void StartEngine()
        {
            if (isRunning) return;
            isRunning = true;
            physicsThread = new Thread(PhysicsLoop);
            physicsThread.IsBackground = true;
            physicsThread.Start();
        }

        public void moveP1(int x, int y)
        {
            x1 = x;
            y1 = y - _form.P1.Height;
            // Ensure the engine is running even if the ball hasn't been thrown
            StartEngine();
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

                if(moveRight && x1 < _form.Width - _form.P1.Width) x1 += GlobalConfig.playerMovementSpeed;
                if (moveLeft && x1 > 0) x1 -= GlobalConfig.playerMovementSpeed;



                if (jump && jumping)
                {
                    vecy1 = -GlobalConfig.playerMovementJumpHeight;
                    jumping = false;
                    jump = false;
                }

                if (!jumping)
                {
                    vecy1 += GlobalConfig.gravity;
                    y1 += vecy1;

                    // Floor Detection for Player
                    if (y1 > GlobalConfig.pFieldY - _form.P1.Height)
                    {
                        y1 = GlobalConfig.pFieldY - _form.P1.Height;
                        vecy1 = 0;
                        jumping = true;
                    }
                }

                // BALL PHYSICS
                velocityY += GlobalConfig.gravity;
                int subSteps = 8;
                double stepX = velocityX / subSteps;
                double stepY = velocityY / subSteps;

                for (int i = 0; i < subSteps; i++)
                {
                    bx += stepX;
                    by += stepY;

                    // Floor detection
                    if (by > GlobalConfig.pFieldY - _form.picBox_basketBall.Height)
                    {
                        by = GlobalConfig.pFieldY - _form.picBox_basketBall.Height;
                        velocityY = -velocityY * GlobalConfig.bouncyness;
                        velocityX = velocityX * GlobalConfig.gFriction;
                        if (Math.Abs(velocityY) < 1.5) velocityY = 0;
                    }

                    // Wall detection
                    if (bx < 0) { bx = 0; velocityX = -velocityX * GlobalConfig.bouncyness; }
                    int rightWall = _form.ClientSize.Width - _form.picBox_basketBall.Width;
                    if (bx > rightWall) { bx = rightWall; velocityX = -velocityX * GlobalConfig.bouncyness; }

                    // Collision checks
                    CheckBounce(GlobalConfig.BackboardLeft.xL, GlobalConfig.BackboardLeft.xR, GlobalConfig.BackboardLeft.yT, GlobalConfig.BackboardLeft.yB);
                    CheckBounce(GlobalConfig.BackboardRight.xL, GlobalConfig.BackboardRight.xR, GlobalConfig.BackboardRight.yT, GlobalConfig.BackboardRight.yB);
                    CheckBounce(GlobalConfig.rimLeft.xL, GlobalConfig.rimLeft.xR, GlobalConfig.rimLeft.yT, GlobalConfig.rimLeft.yB);
                    CheckBounce(GlobalConfig.rimLeft.xL2, GlobalConfig.rimLeft.xR2, GlobalConfig.rimLeft.yT, GlobalConfig.rimLeft.yB);
                    CheckBounce(GlobalConfig.rimRight.xL, GlobalConfig.rimRight.xR, GlobalConfig.rimRight.yT, GlobalConfig.rimRight.yB);
                    CheckBounce(GlobalConfig.rimRight.xL2, GlobalConfig.rimRight.xR2, GlobalConfig.rimRight.yT, GlobalConfig.rimRight.yB);

                    stepX = velocityX / subSteps;
                    stepY = velocityY / subSteps;
                }

                // ARROW LOGIC (Pre-calculate for UI)
                bool isOffScreen = (by + _form.picBox_basketBall.Height) < 20;
                int arrowH = 60 - (int)(Math.Abs(by) / 20);
                if (arrowH < 10) arrowH = 10;
                int arrowX = (int)bx + (_form.picBox_basketBall.Width / 2) - (_form.LocatorArrow.Width / 2);

                // UI UPDATER (Single Batch Update)
                //if (!_form.IsDisposed && _form.P1.IsHandleCreated)
                //{
                //    _form.BeginInvoke((MethodInvoker)delegate {
                //        _form.P1.Location = new Point((int)x1, (int)y1);
                //        _form.picBox_basketBall.Location = new Point((int)bx, (int)by);

                //        // Handle Arrow Visibility and Size
                //        _form.LocatorArrow.Visible = isOffScreen;
                //        if (isOffScreen)
                //        {
                //            _form.LocatorArrow.Height = arrowH;
                //            _form.LocatorArrow.Left = arrowX;
                //        }
                //    });
                //}

                if (!_form.IsDisposed && _form.IsHandleCreated)
                {
                    _form.BeginInvoke((MethodInvoker)delegate {
                        // This forces the Form1_Paint event to run
                        _form.Invalidate();
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