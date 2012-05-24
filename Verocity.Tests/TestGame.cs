using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Voracity.Tests
{
    [TestClass]
    public class TestGame
    {
        private const int _boardSize = 10;
        private readonly Game _game = new Game(_boardSize);

        [TestMethod]
        public void NewGame()
        {
            _game.NewGame();
            Assert.AreEqual(0, _game.Score());
            Assert.AreEqual(_boardSize*_boardSize, _game.TilesLeft());
        }

        [TestMethod]
        public void RandomNumbersMatrix()
        {
            _game.NewGame();
            List<Tile> tiles1 = _game.Tiles();

            _game.NewGame();
            List<Tile> tiles2 = _game.Tiles();
            Assert.AreEqual(tiles1.Count, tiles2.Count);
        }
    }
}