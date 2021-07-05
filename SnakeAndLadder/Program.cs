using System;

namespace SnakeAndLadder
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Snake And Ladder Game");

            SnakeAndLadderGame game = new SnakeAndLadderGame(100);
            game.PlayGame();

            Console.ReadLine();
        }
    }
}
