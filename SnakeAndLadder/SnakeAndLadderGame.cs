﻿using SnakeAndLadder.Core;
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
            for (var i = 0; i < noBoardCells; i++)
            {
                var pos = i + 1;

                var cell = snakeCells.FirstOrDefault(x => x.Position == pos);
                if (cell != null)
                {
                    boardCells.Add(cell);
                }
                else
                {
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

            currentPosition = newPosition;

            return false;
        }

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
    }
}
