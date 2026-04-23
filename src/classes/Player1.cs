using System;
using System.Collections.Generic;
using System.Text;

namespace Basket_Ball_Game
{

    internal class Player1
    {

    }

    public class MyClass
    {
        int? speed = GlobalConfig.playerMovementSpeed;
        int? JHigh = GlobalConfig.playerMovementJumpHeight;
        int? gx = GlobalConfig.gameSizeX;
        int? gy = GlobalConfig.gameSizeY;


        int pX;
        int pY;

        private Form1 _form;

        public MyClass(Form1 form)
        {
            _form = form;
        }

        public void UpdateBox()
        {
            _form.P1.Location = new Point(pX, pY);
        }
    }
}
