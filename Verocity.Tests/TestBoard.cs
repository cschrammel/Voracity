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
            _board = new Board(_boardSize, new PositionFinder(_boardSize));
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
            Thread.Sleep(20);
            _board.ResetTiles();
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
        public void RandomStartPosition()
        {
            _board.ResetTiles();
            Position startPosition1 = _board.CurrentTile.Position;
            Thread.Sleep(20);
            _board.ResetTiles();
            Position startPosition2 = _board.CurrentTile.Position;
            Assert.AreNotEqual(startPosition1, startPosition2);
        }

        
    }
}