using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeAndLadder.Core;
using System;

namespace SnakeAndLadder.Test
{
    [TestClass]
    public class GameTest
    {
        SnakeAndLadderGame game = new SnakeAndLadderGame(100);
        Dice dice = new Dice(6);

        [TestMethod]
        public void Should_ReturnBool_When_TokenIsMoved()
        {
            var token = new Token() { Value = 100 };
            var result = game.MoveToken(token);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Should_ThrowException_WhenTokenIsInvalid()
        {
            var token = new Token() { Value = 0 };

            Assert.ThrowsException<InvalidOperationException>(() => game.MoveToken(token));
        }


        [TestMethod]
        public void Should_ReturnsAnIntegerLessThan7_When_Rolled()
        {
            var dice = new Dice(6);
            var result = dice.Roll();

            Assert.IsTrue(result < 7);
        }

    }
}
