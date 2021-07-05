using SnakeAndLadder.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeAndLadder
{
    public class SnakeAndLadderGame
    {
        private int currentPosition = 0;
        private int noBoardCells = 100;
        private List<BoardCell> boardCells = new List<BoardCell>();

        private Dice dice = new Dice(6);

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
            var snakeCells = GetSnakeCells();
            var ladderCells = GetLadderCells();
            var snakeAndLadderCells = snakeCells.Concat(ladderCells);

            for (var i = 0; i < noBoardCells; i++)
            {
                var pos = i + 1;

                //add a snake or ladder if it exists at the current cell position
                var cell = snakeAndLadderCells.FirstOrDefault(x => x.Position == pos);
                if (cell != null)
                {
                    boardCells.Add(cell);
                }
                else
                {
                    //add empty cell
                    boardCells.Add(new BoardCell() { Position = pos });
                }
            }
        }

        public void PlayGame()
        {
            var gameWon = false;
            while (!gameWon)
            {
                gameWon = Move();
            }
        }

        public bool Move()
        {
            int number = dice.Roll();
            var token = new Token() { Value = number };

            return MoveToken(token);
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

            var newPosition = token.Value + currentPosition;

            Console.WriteLine($"New Position: {currentPosition}");
            if (newPosition == GoalCell.Position) //we have a winner!
            {
                Console.WriteLine("We have a winner");
                return true;
            }
            else if (newPosition > GoalCell.Position)
            {
                Console.WriteLine("Game continues");
                return false;
            }

            var newCell = boardCells[newPosition - 1];
            if (newCell.CellType == CellType.Snake )
            {
                Console.WriteLine($"Token landed on a snake head");
                currentPosition = newCell.Adjustment;
            }
            if (newCell.CellType == CellType.Ladder)
            {
                Console.WriteLine($"Token landed on a ladder");
                currentPosition = newCell.Adjustment;
            }
            else
            {
                currentPosition = newPosition;
            }

            return false;
        }

        /// <summary>
        /// Get Ssnakes cells 
        /// </summary>
        /// <returns></returns>
        private List<BoardCell> GetSnakeCells()
        {
            var snakeCells = new List<BoardCell>() {
                new BoardCell { Position=98, Adjustment = 40, CellType = CellType.Snake } ,
                new BoardCell { Position=71, Adjustment = 54, CellType = CellType.Snake } ,
                new BoardCell { Position=35, Adjustment = 7, CellType = CellType.Snake } ,
                new BoardCell { Position=23, Adjustment = 2, CellType = CellType.Snake }
            };

            return snakeCells;
        }

        //Get ladder cells
        private List<BoardCell> GetLadderCells()
        {
            var ladderCells = new List<BoardCell>() {
                new BoardCell { Position=67, Adjustment = 83, CellType = CellType.Ladder } ,
                new BoardCell { Position=50, Adjustment = 79 , CellType = CellType.Ladder} ,
                new BoardCell { Position=21, Adjustment = 69, CellType = CellType.Ladder } ,
                new BoardCell { Position=5, Adjustment = 20, CellType = CellType.Ladder } ,
            };

            return ladderCells;
        }
    }
}
