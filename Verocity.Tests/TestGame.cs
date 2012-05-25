using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Voracity.Tests
{
    [TestClass]
    public class TestGame
    {
        private const int _boardSize = 25;
        private Game _game;

        [TestInitialize]
        public void TestInit()
        {
            var positionFinder = new PositionFinder(_boardSize);
            var board = new Board(_boardSize, positionFinder);
            _game = new Game(board, new SurroundingTileFinder(_boardSize, positionFinder));
        }

        [TestMethod]
        public void NewGame()
        {
            _game.NewGame();
            Assert.AreEqual(0, _game.Score());
            Assert.AreEqual(_boardSize*_boardSize, _game.TilesRemaining());
            Assert.IsNotNull(_game.Board);
        }

        [TestMethod]
        public void ChompUp()
        {
            PositionedTile firstTile = _game.Board.Tiles()[0];
            _game.Board.CurrentTile = firstTile;
            _game.Chomp(Directions.North);
            PositionedTile northernTile = _game.Board.Tiles()[25];
            Assert.AreEqual(0, _game.Board.CurrentTile.Position.X);
            Assert.AreEqual(northernTile.Number, _game.Board.CurrentTile.Position.Y);
        }
    }
}