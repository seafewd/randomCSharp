using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapitel3
{
    class Game
    {
        private IMovable ball;
        private IMovable paddle1;
        private IMovable paddle2;
        private ScoreKeeper sk;

        private bool Intersects()
        {
            return false;
        }

        private bool OutOfBounds()
        {
            return false;
        }
        private void MovePaddle(Rectangle paddle, int dy)
        {
            paddle.YPos = paddle.YPos + dy;
        }

    }
}
