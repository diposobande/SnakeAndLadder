using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder.Core
{
    public class Dice
    {
        private readonly int maxValue = 6;
        private readonly Random random = new Random();

        public Dice(int maxValue)
        {
            this.maxValue = maxValue;
        }

        public int Roll()
        {
           return random.Next(1, maxValue);
        }
    }
}
