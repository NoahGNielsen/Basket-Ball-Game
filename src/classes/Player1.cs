using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Basket_Ball_Game
{
    public class Player1
    {
        int? JHigh = GlobalConfig.playerMovementJumpHeight;

        private int currentX;
        private int currentY;

        private bool isRunning = false;
        private Thread playerThread;
        private Form1 _form;

        public Player1(Form1 form)
        {
            _form = form;
        }

        public void Move(int x, int y)
        {
            currentX = x;
            currentY = y - _form.P1.Size.Height;

            if (!isRunning)
            {
                StartThread();
            }
        }

        private void StartThread()
        {
            isRunning = true;
            playerThread = new Thread(PlayerLoop);
            playerThread.IsBackground = true;
            playerThread.Start();
        }

        private void PlayerLoop()
        {
            while (isRunning)
            {
                if (_form.P1.IsHandleCreated)
                {
                    _form.Invoke((MethodInvoker)delegate {
                        _form.P1.Location = new Point(currentX, currentY);
                    });
                }
                Thread.Sleep(GlobalConfig.gameUpdateRate);
            }
        }

        public void Stop()
        {
            isRunning = false;
        }
    }
}