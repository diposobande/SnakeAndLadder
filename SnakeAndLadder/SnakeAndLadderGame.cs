using SnakeAndLadder.Core;
using System;
using System.Collections.Generic;

namespace SnakeAndLadder
{
    public class SnakeAndLadderGame
    {
        private int currentPosition = 0;
        private int noBoardCells = 100;
        private List<BoardCell> boardCells = new List<BoardCell>();

        private BoardCell GoalCell { get { return new BoardCell { Position = boardCells.Count }; } }

        public SnakeAndLadderGame(int noBoardCells)
        {
            this.noBoardCells = noBoardCells;
            Setup();
        }

        /// <summary>
        /// Setup board for game
        /// </summary>
        public void Setup()
        {
            for (var i = 0; i < noBoardCells; i++)
            {
                var pos = i + 1;
                boardCells.Add(new BoardCell() { Position = pos });
            }
        }

        /// <summary>
        /// Move token and update new position
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool MoveToken(Token token)
        {
            if (token == null || token.Value < 1)
                throw new InvalidOperationException("Invalid token");

            currentPosition = token.Value + currentPosition;
            if (currentPosition == GoalCell.Position)
                return true;

            return false;
        }

    }
}
