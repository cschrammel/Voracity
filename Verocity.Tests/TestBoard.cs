using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Voracity.Tests
{
    [TestClass]
    public class TestBoard
    {
        private Board _board;
        private const int _boardSize = 5;

        [TestInitialize]
        public void TestInit()
        {
            _board = new Board(_boardSize, new PositionFinder());
        }

        [TestMethod]
        public void TestSize()
        {
            Assert.AreEqual(_boardSize * _boardSize, _board.Tiles().Count());
        }

        [TestMethod]
        public void RandomNumbersMatrix()
        {
            List<PositionedTile> tiles1 = _board.Tiles();
            string numberList1 = GetTileNumberString(tiles1);
            Thread.Sleep(10);
            _board.Reset();
            List<PositionedTile> tiles2 = _board.Tiles();
            string numberList2 = GetTileNumberString(tiles2);

            Assert.AreEqual(tiles1.Count, tiles2.Count);
            Assert.AreNotEqual(numberList1, numberList2);
        }

        private static string GetTileNumberString(IEnumerable<Tile> tiles)
        {
            return tiles.Aggregate("", (current, t) => current + t.Number.ToString(CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void PositionOfTile1()
        {
            AssertTilePosition(1, 0, 0);
        }

        [TestMethod]
        public void PositionOfTile6()
        {
            AssertTilePosition(6, 0, 1);
        }

        [TestMethod]
        public void PositionOfTile9()
        {
            AssertTilePosition(9, 3, 1);
        }

        [TestMethod]
        public void PositionOfTile25()
        {
            AssertTilePosition(25, 4, 4);
        }

        [TestMethod]
        public void PositionOfTile24()
        {
            AssertTilePosition(24, 3, 4);
        }

        private void AssertTilePosition(int position, int expectedX, int expectedY)
        {
            Position positionOfTile = _board.Tiles()[position - 1].Position;
            Assert.AreEqual(expectedX, positionOfTile.X);
            Assert.AreEqual(expectedY, positionOfTile.Y);
        }


        [TestMethod]
        public void RandomStartPosition()
        {
            _board.Reset();
            Position startPosition1 = _board.CurrentTile.Position;
            Thread.Sleep(20);
            _board.Reset();
            Position startPosition2 = _board.CurrentTile.Position;
            Assert.AreNotEqual(startPosition1, startPosition2);
        }
    }
}