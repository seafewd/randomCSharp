using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapitel3
{
    class Paddle : Rectangle
    {
        private static readonly int paddleWidth = 30;
        private static readonly int paddleHeight = 150;

        public Paddle(int xPos, int yPos) : base(paddleWidth, paddleHeight, xPos, yPos)
        {
            Console.WriteLine("Created paddle");
        }
    }
}
