using console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace unittests
{
    [TestClass]
    public class UnitTest1
    {
        private BoardGame board;

        public UnitTest1()
        {
            board = new BoardGame();
        }

        [TestMethod]
        [DataRow("-8")]
        [DataRow("0")]
        [DataRow("10")]
        public void TestForValidInputRange(string value)
        {
            Assert.IsFalse(board.CheckInput(value), "I must be between 1 and 9.");
        }

        [TestMethod]
        public void TestForIllegalInput()
        {
            Assert.IsFalse(board.CheckInput("banana"), "I must be a whole number.");
        }

        [TestMethod]
        public void TestForDiagonalWinCondition()
        {
            board.grid = new string[3, 3] { { "X", "2", "3" }, { "4", "X", "6" }, { "7", "8", "X" } };
            board.CheckDiagonal();
            Assert.IsTrue(board.Flag == 2, "A diagonal input has won");
        }
    }
}
