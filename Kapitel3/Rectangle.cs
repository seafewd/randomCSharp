using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapitel3
{
    public class Rectangle : IMovable
    {
        protected int width;
        protected int height;
        protected int xPos;
        protected int yPos;
        protected int dx;
        protected int dy;

        public Rectangle(int width, int height, int xPos, int yPos, int dx, int dy)
        {
            this.width = width;
            this.height = height;
            this.xPos = xPos;
            this.yPos = yPos;
            this.dx = dx;
            this.dy = dy;
        }

        public Rectangle(int width, int height, int xPos, int yPos)
        {
            this.width = width;
            this.height = height;
            this.xPos = xPos;
            this.yPos = yPos;
            this.dx = 0;
            this.dy = 0;
        }

        public int XPos
        {
            get;
            set;
        }

        public int YPos
        {
            get;
            set;
        }



        public int getDx()
        {
            return dx;
        }

        public int getDy()
        {
            return dy;
        }

        public int getXPos()
        {
            return xPos;
        }

        public int getYPos()
        {
            return yPos;
        }
    }
}
