using System;
using System.Collections.Generic;
using System.Text;

namespace Basket_Ball_Game
{

    public class Player1
    {
        int? speed = GlobalConfig.playerMovementSpeed;
        int? JHigh = GlobalConfig.playerMovementJumpHeight;

        private Form1 _form;

        public Player1(Form1 form)
        {
            _form = form;
        }

        public void UpdateBox()
        {
           // _form.P1.Location = new Point(pX, pY);
        }

        public void Move (int x, int y)
        {
            _form.P1.Location = new Point(x, (y - _form.P1.Size.Height));
        }
    }
}
