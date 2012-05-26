using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Voracity.Tests
{
    [TestClass]
    public class TestGame
    {
        private const int _boardSize = 25;
        private BoardTestDouble _board;
        private Game _game;
        private PositionFinder _positionFinder;

        [TestInitialize]
        public void TestInit()
        {
            _positionFinder = new PositionFinder(_boardSize);
            _board = new BoardTestDouble(_boardSize, _positionFinder,
                                         new SurroundingTileFinder(_boardSize, _positionFinder));
            _game = new Game(_board, new SurroundingTileFinder(_boardSize, _positionFinder));
        }

        [TestMethod]
        public void NewGame()
        {
            _game.NewGame();
            Assert.AreEqual(0, _game.Score());
            Assert.IsNotNull(_game.Board);
        }

        [TestMethod]
        public void ChompUp()
        {
            PositionedTile firstTile = _board.Tiles()[0];
            _board.SetCurrentTile(firstTile);
            _game.Chomp(Directions.North);
            PositionedTile northernTile = _game.Board.Tiles()[25];
            Assert.AreEqual(0, _game.Board.CurrentTile.Position.X);
            Assert.AreEqual(northernTile.Number, _game.Board.CurrentTile.Position.Y);
        }

        [TestMethod]
        public void ChompEast()
        {
            PositionedTile firstTile = _board.Tiles()[0];
            _board.SetCurrentTile(firstTile);
            _game.Chomp(Directions.East);
            PositionedTile easternTile = _game.Board.Tiles()[1];
            Assert.AreEqual(easternTile.Number, _game.Board.CurrentTile.Position.X);
            Assert.AreEqual(0, _game.Board.CurrentTile.Position.Y);
        }

        [TestMethod]
        public void ChompNorthEast()
        {
            PositionedTile firstTile = _board.Tiles()[0];
            _board.SetCurrentTile(firstTile);
            _game.Chomp(Directions.NorthEast);
            PositionedTile northeasternTile = _game.Board.Tiles()[_boardSize+1];
            Assert.AreEqual(northeasternTile.Number, _game.Board.CurrentTile.Position.X);
            Assert.AreEqual(northeasternTile.Number, _game.Board.CurrentTile.Position.Y);
        }
    }

    public class BoardTestDouble : Board
    {
        public BoardTestDouble(int boardSize, PositionFinder positionFinder, SurroundingTileFinder tileFinder)
            : base(boardSize, positionFinder, tileFinder)
        {
        }

        public void SetCurrentTile(PositionedTile tile)
        {
            CurrentTile = tile;
        }
    }
}