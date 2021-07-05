using SnakeAndLadder.Core;
using System;

namespace SnakeAndLadder
{
    public class SnakeAndLadderGame
    {
        public SnakeAndLadderGame()
        {
        }

        public bool MoveToken(Token token)
        {
            if (token == null || token.Position < 1)
                throw new InvalidOperationException("Invalid token");

            return true;
        }

    }
}
