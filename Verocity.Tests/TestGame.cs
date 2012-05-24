using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Voracity.Tests
{
    [TestClass]
    public class TestGame
    {
        private const int _boardSize = 5;
        private readonly Game _game = new Game(_boardSize);

        [TestMethod]
        public void NewGame()
        {
            _game.NewGame();
            Assert.AreEqual(0, _game.Score());
            Assert.AreEqual(_boardSize*_boardSize, _game.TilesRemaining());
        }

        [TestMethod]
        public void RandomNumbersMatrix()
        {
            _game.NewGame();
            var tiles1 = _game.Board.Tiles();
            string numberList1 = GetTileNumberString(tiles1);
            Thread.Sleep(10);
            _game.NewGame();
            var tiles2 = _game.Board.Tiles();
            string numberList2 = GetTileNumberString(tiles2);
            
            Assert.AreEqual(tiles1.Count, tiles2.Count);
            Assert.AreNotEqual(numberList1, numberList2);
        }

        [TestMethod]
        public void RandomStartPosition()
        {
            _game.NewGame();
            Position startPosition1 = _game.CurrentTile.Position;
            Thread.Sleep(10);
            _game.NewGame();
            Position startPosition2 = _game.CurrentTile.Position;
            Assert.AreNotEqual(startPosition1, startPosition2);
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
            AssertTilePosition(24,3,4);
        }

        private void AssertTilePosition(int position, int expectedX, int expectedY)
        {
            _game.NewGame();
            var positionOfTile = _game.Board.Tiles()[position - 1].Position;
            Assert.AreEqual(expectedX, positionOfTile.X);
            Assert.AreEqual(expectedY, positionOfTile.Y);
        }


        private static string GetTileNumberString(IEnumerable<Tile> tiles)
        {
            return tiles.Aggregate("", (current,t) => current + t.Number.ToString(CultureInfo.InvariantCulture));
        }
    }
}