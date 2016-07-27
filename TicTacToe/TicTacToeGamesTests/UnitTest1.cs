using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;

namespace TicTacToeGamesTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PlayerMove_WithIllegalIndexes_ExpectedFalls()
        {
            TicTacToeGame t = new TicTacToeGame();            
            Assert.IsFalse(t.PlayerMove(1, 3));
        }

        [TestMethod]
        public void PlayerMove_WithlegalIndexes_ExpectedTrue()
        {
            TicTacToeGame t = new TicTacToeGame();
            Assert.IsTrue(t.PlayerMove(1, 1));
        }

        [TestMethod]
        public void PlayerMove_WithPlayer1_ExpectedX()
        {            
            TicTacToeGame t = new TicTacToeGame();            
            t.PlayerMove(1, 1);
            string res = t[1, 1].ToString();
            Assert.IsTrue(StringAssert.Equals(res,"X"));
        }

        [TestMethod]
        public void PlayerMove_WithPlayer2_ExpectedO()
        {
            TicTacToeGame t = new TicTacToeGame();
            t.PlayerMove(0, 0);
            t.PlayerMove(1, 1);
            string res = t[1, 1].ToString();
            Assert.IsTrue(StringAssert.Equals(res, "O"));
        }
        
        [TestMethod]
        public void IsGameOver_Draw_ExpectedTrue()
        {
            TicTacToeGame t = new TicTacToeGame();
            Assert.IsTrue(t.IsGameOver(1));
        }
    }
}
