using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Threading;
using System.Windows.Forms;

namespace Basket_Ball_Game
{
    public class PhysicsThread
    {
        public bool deXl;
        public bool deXr;
        public bool deYu;
        public bool deYd;
        //int deX = 0;
        //int deY = 0;


        public double bx;
        public double by;
        public double vX;
        public double vY;
        double lastY;
        public double broll;

        int leftScore;
        int rightScore;
        bool hasScoredonce;

        double velocityY = 0;
        double velocityX = 0;

        bool isRunning = false;
        public bool dropBall;

        private Form1 _form;
        private Thread? physicsThread;
        public bool theGreatReset = false; // full hard reset
        bool softReset; // does not reset scores
        double resetTimeCounter;

        // Player 1
        public bool moveLeft1 = false;
        public bool moveRight1 = false;
        public double x1;
        public double y1;
        public double vecy1;
        public bool jump1;
        public bool jumping1;

        int armLength1 = Properties.Resources.Person_arm_Scaled_down.Width;
        bool isHolding1 = false;
        public float armAngle1 = 0; //in degrees
        public bool pitchUp1;
        public bool pitchDown1;
        public int armTipX1;
        public int armTipY1;
        public int gCldwn1 = 0; // Grab cooldown
        public bool greenFN1 = false; // Did he shoot?

        // Player 2
        public bool moveLeft2 = false;
        public bool moveRight2 = false;
        public double x2;
        public double y2;
        public double vecy2;
        public bool jump2;
        public bool jumping2;

        int armLength2 = Properties.Resources.Person_arm_Scaled_down.Width;
        bool isHolding2 = false;
        public float armAngle2 = 180; //in degrees (180 due to being the opposite side of the map)
        public bool pitchUp2;
        public bool pitchDown2;
        public int armTipX2;
        public int armTipY2;
        public int gCldwn2 = 0; // Grab cooldown
        public bool greenFN2 = false; // Did he shoot? 




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

            // Resets velocity for a fresh drop
            velocityY = 0;
        }
        public void StartEngine() // Vroom vroom, "put it in reverse Terry!!"
        {
            if (isRunning) return;
            isRunning = true;
            physicsThread = new Thread(PhysicsLoop);
            physicsThread.IsBackground = true;
            physicsThread.Start();
        }

        public void Stop()
        {
            theGreatReset = true;
        }


        public void moveP1(int x, int y)
        {
            x1 = x;
            y1 = y - _form.P1.Height;
            // Ensure the engine is running even if the ball hasn't been thrown
            //StartEngine();
        }
        public void moveP2(int x, int y)
        {
            x2 = x;
            y2 = y - _form.P2.Height;
            // Ensure the engine is running even if the ball hasn't been thrown
            //StartEngine();
        }




        // adds the ability to control the ball w vectors (for debugging)
        public void VectorMovement(double vx, double vy)
        {
            vX = vx;
            vY = -vy;
            velocityY += vY;
            velocityX += vX;
            StartEngine();
        }

        private void PhysicsLoop()
        {
            while (isRunning)
            {
                try
                {
                    if (theGreatReset || softReset)
                    {
                        // Start resetting procedure
                        velocityX = 0;
                        velocityY = 0;
                        moveP1(_form.xP1, _form.y);
                        moveP2(_form.xP2 - _form.P2.Width - 20, _form.y);
                        startP(GlobalConfig.gameSizeX / 2, GlobalConfig.pFieldY - _form.ballStartingHeight);

                        // Reseting cooldown timer locations
                        // P1
                        _form.p1Cooldown.Text = "Cooldown: " + (gCldwn1 / 60.0).ToString("F1") + "s"; // Display cooldown i seconds w 1 decimal place
                        _form.p1Cooldown.Location = new Point(Convert.ToInt32(x1 + (_form.P1.Width / 2) - (_form.p1Cooldown.Width / 2)), Convert.ToInt32(y1 - _form.p1Cooldown.Height));

                        // P2
                        _form.p2Cooldown.Text = "Cooldown: " + (gCldwn2 / 60.0).ToString("F1") + "s"; // Display cooldown i seconds w 1 decimal place
                        _form.p2Cooldown.Location = new Point(Convert.ToInt32(x2 + (_form.P2.Width / 2) - (_form.p2Cooldown.Width / 2)), Convert.ToInt32(y2 - _form.p2Cooldown.Height));

                        armAngle1 = 0;
                        armAngle2 = 180;
                        isHolding1 = false;
                        isHolding2 = false;
                        jumping1 = false;
                        jumping2 = false;

                        hasScoredonce = false;

                        while (!_form.start)
                        {
                            Thread.Sleep(50);
                        }


                        // starts the reset timer / play cooldown
                        if ((GlobalConfig.gameResetTimer * (1000 / 60)) - resetTimeCounter > 0)
                        {
                            _form.GameStartTimer.Show();
                            _form.GameStartTimer.Text = Convert.ToString(Convert.ToInt32((GlobalConfig.gameResetTimer * (1000 / 60)) - resetTimeCounter) / (1000 / 60));
                            _form.GameStartTimer.Location = new Point((GlobalConfig.gameSizeX / 2) - _form.GameStartTimer.Width / 2, _form.label_scoreTeam1.Location.Y);

                            resetTimeCounter++;
                        }
                        else if ((GlobalConfig.gameResetTimer * (1000 / 60)) - resetTimeCounter <= 0)
                        {
                            // Start again
                            theGreatReset = false;
                            softReset = false;
                            _form.GameStartTimer.Hide();
                            resetTimeCounter = 0;
                            StartEngine();
                        }

                        if (theGreatReset)
                        {
                            rightScore = 0;
                            leftScore = 0;
                        }
                    }

                    else
                    {
                        // Debugging locations
                        //if (deXl) deX -= 1;
                        //if (deXr) deX += 1;
                        //if (deYu) deY -= 1;
                        //if (deYd) deY += 1;
                        //_form.label2.Text = "X = " + Convert.ToString(deX) + "; Y = " + Convert.ToString(deY);

                        // Finding arm tip location
                        double rads = armAngle1 * (Math.PI / 180); // Finding rads
                        armTipY1 = Convert.ToInt32(y1 + 111 + (armLength1 * Math.Sin(rads)));
                        armTipX1 = Convert.ToInt32((x1 + (Properties.Resources.Person_sprite_Scaled_down.Width / 2)) + (armLength1 * Math.Cos(rads)));

                        double rads1 = armAngle2 * (Math.PI / 180); // Finding rads
                        armTipY2 = Convert.ToInt32(y2 + 111 + (armLength2 * Math.Sin(rads1)));
                        armTipX2 = Convert.ToInt32((x2 + (Properties.Resources.Person_sprite_Scaled_down.Width / 2)) + (armLength2 * Math.Cos(rads1)));


                        // Rotating arms
                        if (pitchUp1) armAngle1 += GlobalConfig.Player.armRotatingSpeed;
                        if (pitchDown1) armAngle1 -= GlobalConfig.Player.armRotatingSpeed;

                        // Moving Player
                        if (moveRight1 && x1 + GlobalConfig.Player.movementSpeed < GlobalConfig.gameSizeX - _form.P1.Width) x1 += GlobalConfig.Player.movementSpeed;
                        if (moveLeft1 && x1 > 0) x1 -= GlobalConfig.Player.movementSpeed;

                        // Jump duhh
                        if (jump1 && jumping1)
                        {
                            vecy1 = -GlobalConfig.Player.jumpHeight;
                            jumping1 = false;
                            jump1 = false;
                        }

                        if (!jumping1)
                        {
                            vecy1 += GlobalConfig.gravity;
                            y1 += vecy1;

                            // Floor Detection for Player
                            if (y1 > GlobalConfig.pFieldY - _form.P1.Height)
                            {
                                y1 = GlobalConfig.pFieldY - _form.P1.Height;
                                vecy1 = 0;
                                jumping1 = true;
                            }
                        }


                        // Moving Player 2
                        if (moveRight2 && x2 + GlobalConfig.Player.movementSpeed < GlobalConfig.gameSizeX - _form.P1.Width) x2 += GlobalConfig.Player.movementSpeed;
                        if (moveLeft2 && x2 > 0) x2 -= GlobalConfig.Player.movementSpeed;

                        // Rotating arms P2
                        if (pitchUp2) armAngle2 += GlobalConfig.Player.armRotatingSpeed;
                        if (pitchDown2) armAngle2 -= GlobalConfig.Player.armRotatingSpeed;

                        // Jump duhh
                        if (jump2 && jumping2)
                        {
                            vecy2 = -GlobalConfig.Player.jumpHeight;
                            jumping2 = false;
                            jump2 = false;
                        }

                        if (!jumping2)
                        {
                            vecy2 += GlobalConfig.gravity;
                            y2 += vecy2;

                            // Floor Detection for Player
                            if (y2 > GlobalConfig.pFieldY - _form.P2.Height)
                            {
                                y2 = GlobalConfig.pFieldY - _form.P2.Height;
                                vecy2 = 0;
                                jumping2 = true;
                            }
                        }


                        else if (dropBall)
                        {
                            gCldwn2 = Convert.ToInt32(GlobalConfig.Player.reGrabCooldown);
                            isHolding2 = false;
                        }


                        // Shooting
                        if (isHolding1 && greenFN1)
                        {
                            isHolding1 = false;
                            gCldwn1 = Convert.ToInt32(GlobalConfig.Player.reGrabCooldown);
                            velocityX = Math.Cos(rads) * GlobalConfig.Player.throwingPower;
                            velocityY = Math.Sin(rads) * GlobalConfig.Player.throwingPower;
                        }


                        // Shooting
                        if (isHolding2 && greenFN2)
                        {
                            isHolding2 = false;
                            gCldwn2 = Convert.ToInt32(GlobalConfig.Player.reGrabCooldown);
                            velocityX = Math.Cos(rads1) * GlobalConfig.Player.throwingPower;
                            velocityY = Math.Sin(rads1) * GlobalConfig.Player.throwingPower;
                        }



                        // BALL PHYSICS
                        if (!isHolding1 || !isHolding2)
                            velocityY += GlobalConfig.gravity;

                        int subSteps = 8;
                        double stepX = velocityX / subSteps;
                        double stepY = velocityY / subSteps;

                        for (int i = 0; i < subSteps; i++)
                        {
                            bx += stepX;
                            by += stepY;




                            // Player collisions
                            if (!isHolding1 && gCldwn1 == 0)
                            {
                                if (checkGrab(Convert.ToInt32(x1), Convert.ToInt32((x1 + _form.P1.Width)), Convert.ToInt32(y1), Convert.ToInt32((y1 + _form.P1.Height)), armTipX1, armTipY1))
                                {
                                    // Upon inserting the aforementioned spherical entity into one's grasping appendage, a harmonious union is thereby effectuated, thus yielding a most gratifying conjunction of the orb and the palm.
                                    velocityX = 0;
                                    velocityY = 0;
                                    if (!isHolding2)
                                        isHolding1 = true;
                                    else if (isHolding2)
                                    {
                                        isHolding2 = false;
                                        gCldwn2 = Convert.ToInt32(GlobalConfig.Player.reGrabCooldown);
                                        isHolding1 = true;
                                    }
                                }
                            }
                            else if (dropBall)
                            {
                                gCldwn1 = Convert.ToInt32(GlobalConfig.Player.reGrabCooldown);
                                isHolding1 = false;
                            }

                            // Player 2 collisions
                            if (!isHolding2 && gCldwn2 == 0)
                            {
                                if (checkGrab(Convert.ToInt32(x2), Convert.ToInt32((x2 + _form.P2.Width)), Convert.ToInt32(y2), Convert.ToInt32((y2 + _form.P2.Height)), armTipX2, armTipY2))
                                {
                                    // Upon inserting the aforementioned spherical entity into one's grasping appendage, a harmonious union is thereby effectuated, thus yielding a most gratifying conjunction of the orb and the palm.
                                    velocityX = 0;
                                    velocityY = 0;

                                    if (!isHolding1)
                                        isHolding2 = true;
                                    else if (isHolding1)
                                    {
                                        isHolding1 = false;
                                        gCldwn1 = Convert.ToInt32(GlobalConfig.Player.reGrabCooldown);
                                        isHolding2 = true;
                                    }
                                }
                            }

                            if (checkGoal(GlobalConfig.rimRight.xL2, GlobalConfig.rimRight.xR, GlobalConfig.rimRight.yB, GlobalConfig.rimRight.yT, velocityY) && !isHolding1 && !isHolding2 && !hasScoredonce) // right goal
                            {
                                // Right scored
                                rightScore++;
                                hasScoredonce = true;
                                _form.label_scoreTeam1.Text = (rightScore).ToString();
                                softReset = true;
                            }
                            if (checkGoal(GlobalConfig.rimLeft.xL, GlobalConfig.rimLeft.xL2, GlobalConfig.rimLeft.yB, GlobalConfig.rimLeft.yT, velocityY) && !isHolding1 && !isHolding2 && !hasScoredonce) // left goal
                            {
                                // Left scored
                                leftScore++;
                                hasScoredonce = true;
                                _form.label_scoreTeam2.Text = (leftScore).ToString();
                                softReset = true;
                            }


                            if (!isHolding1 || !isHolding2)
                            {
                                // Floor detctionad (Holy stroke)
                                if (by > GlobalConfig.pFieldY - _form.picBox_basketBall.Height)
                                {
                                    by = GlobalConfig.pFieldY - _form.picBox_basketBall.Height;
                                    velocityY = -velocityY * GlobalConfig.bouncyness;
                                    if (lastY == by)
                                    {
                                        velocityX = velocityX * (0.975);
                                        if (velocityX > 0.00 || velocityX < 0.00)
                                            broll += Convert.ToInt32(velocityX);
                                    }
                                    else
                                        velocityX = velocityX * GlobalConfig.gFriction;
                                    if (Math.Abs(velocityY) < 1.5) velocityY = 0;
                                }
                                else
                                {
                                    broll += Convert.ToInt32(velocityX * GlobalConfig.airRes);
                                    velocityX = velocityX - (velocityX * Math.Pow(GlobalConfig.airRes, 4));
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
                            }
                            stepX = velocityX / subSteps;
                            stepY = velocityY / subSteps;
                        }

                        if (isHolding1)
                        {
                            bx = armTipX1 - (_form.picBox_basketBall.Width / 2);
                            by = armTipY1 - (_form.picBox_basketBall.Height / 2);
                        }

                        if (isHolding2)
                        {
                            bx = armTipX2 - (_form.picBox_basketBall.Width / 2);
                            by = armTipY2 - (_form.picBox_basketBall.Height / 2);
                        }


                    }
                    if (!_form.IsDisposed && _form.IsHandleCreated)
                    {
                        _form.BeginInvoke((MethodInvoker)delegate
                        {
                            // Placing cooldown timers
                            // P1
                            _form.p1Cooldown.Text = "Cooldown: " + (gCldwn1 / 60.0).ToString("F1") + "s"; // Display cooldown i seconds w 1 decimal place
                            _form.p1Cooldown.Location = new Point(Convert.ToInt32(x1 + (_form.P1.Width / 2) - (_form.p1Cooldown.Width / 2)), Convert.ToInt32(y1 - _form.p1Cooldown.Height));

                            // P2
                            _form.p2Cooldown.Text = "Cooldown: " + (gCldwn2 / 60.0).ToString("F1") + "s"; // Display cooldown i seconds w 1 decimal place
                            _form.p2Cooldown.Location = new Point(Convert.ToInt32(x2 + (_form.P2.Width / 2) - (_form.p2Cooldown.Width / 2)), Convert.ToInt32(y2 - _form.p2Cooldown.Height));



                            //// Debugging locations
                            //_form.label2.Text = (GlobalConfig.gameResetTimer * (1000 / 60)).ToString("F2");
                            //_form.label2.Location = new Point(deX, deY);

                            //_form.label1.Text = (resetTimeCounter).ToString("F2");
                            //_form.label1.Location = new Point(armTipX1, armTipY1);

                            _form.Invalidate();
                        });
                    }

                    if (gCldwn1 > 0)
                        gCldwn1--;
                    if (gCldwn2 > 0)
                        gCldwn2--;

                    lastY = by;


                    Thread.Sleep(GlobalConfig.gameUpdateRate);
                }
                catch
                {
                    // so no boom boom when thread closing
                }
            }
        }
        private bool checkGoal(int x1, int x2, int y1, int y2, double v) // checks collision with goal and distance to ball
        {
            if (v < 0) { return false; }
            else
            {
                double radius = _form.picBox_basketBall.Width / 2.0;
                double centerX = bx + radius;
                double centerY = by + radius;

                // Where are goal and where is ball math
                double closestX = Math.Max(x1, Math.Min(centerX, x2));
                double closestY = Math.Max(y1, Math.Min(centerY, y2));

                // Calculate distance from the closest point on the goal to the ball's center
                double diffX = centerX - closestX;
                double diffY = centerY - closestY;
                double distanceSquared = (diffX * diffX) + (diffY * diffY);

                // Checks if the distance to the ball is less than ballRadius^2 (hitbox's overlapping)
                if (distanceSquared <= (radius * radius) / 2)
                {
                    return true;
                }

                // Didn't collide w nuffin' :(
                return false;
            }
        }


        private bool checkGrab(int x1, int x2, int y1, int y2, int hx, int hy) // checks collision with person and distance to ball
        {
            double radius = _form.picBox_basketBall.Width / 2.0;
            double centerX = bx + radius;
            double centerY = by + radius;

            // Where are we and where is ball math
            double closestX = Math.Max(x1, Math.Min(centerX, x2));
            double closestY = Math.Max(y1, Math.Min(centerY, y2));

            // Calculate distance from the closest point on the box to the ball's center
            double diffX = centerX - closestX;
            double diffY = centerY - closestY;
            double distanceSquared = (diffX * diffX) + (diffY * diffY);

            // Checks if the distance to the ball is less than ballRadius^2 (hitbox's overlapping)
            if (distanceSquared <= (radius * radius))
            {
                return true;
            }

            // Checks hand collision
            double hDX = hx - centerX;
            double hDY = hy - centerY;
            double handDistSquared = (hDX * hDX) + (hDY * hDY);
            double maxGrabDistSquared = GlobalConfig.Player.grabDistance * GlobalConfig.Player.grabDistance;

            if (handDistSquared <= maxGrabDistSquared)
            {
                // He reached for it and got that shi
                return true;
            }

            // Didn't collide w nuffin' :(
            return false;
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