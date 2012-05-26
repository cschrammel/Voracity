using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Voracity.Tests
{
    public class TestSurroundingTileFinder
    {
        private SurroundingTileFinder _surroundingTileFinder;
        private List<PositionedTile> _tiles;
        private const int _boardSize = 5;

        [TestInitialize]
        public void TestInit()
        {
            var positionFinder = new PositionFinder(_boardSize);
            _surroundingTileFinder = new SurroundingTileFinder(_boardSize, positionFinder);
            var board = new Board(_boardSize, positionFinder, _surroundingTileFinder);
            _tiles = board.Tiles();
        }

        [TestMethod]
        public void GetSurroundingTilesFromMiddleTile()
        {
            var start = new Position(2, 2);
            AssertTileCount(start, 8);
        }

        [TestMethod]
        public void GetSurroundingTilesFromEdgeTile()
        {
            var start = new Position(0, 2);
            AssertTileCount(start, 5);
        }

        [TestMethod]
        public void GetSurroundingTilesFromCornerTile()
        {
            var start = new Position(0, 0);
            AssertTileCount(start, 3);
        }

        private void AssertTileCount(Position start, int count)
        {
            List<PositionedTile> tiles = _surroundingTileFinder.GetSurroundingTiles(start, _tiles);
            Assert.AreEqual(count, tiles.Count);
        }
    }
}