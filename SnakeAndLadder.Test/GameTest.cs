using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeAndLadder.Core;
using System;

namespace SnakeAndLadder.Test
{
    [TestClass]
    public class GameTest
    {
        SnakeAndLadderGame game = new SnakeAndLadderGame(100);

        [TestMethod]
        public void Should_ReturnBool_When_TokenIsMoved()
        {
            var token = new Token() { Position = 2 };
            var result = game.MoveToken(token);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Should_ThrowException_WhenTokenIsInvalid()
        {
            var token = new Token() { Position = 0 };

            Assert.ThrowsException<InvalidOperationException>(()=>game.MoveToken(token));
        }
    }
}
