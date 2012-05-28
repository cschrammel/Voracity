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
            PositionedTile bottomLeftTile = _board.Tiles()[0];
            _board.SetCurrentTile(bottomLeftTile);
            _game.Chomp(Directions.North);
            PositionedTile northernTile = _game.Board.Tiles()[_boardSize];
            Assert.AreEqual(0, _game.Board.CurrentTile.Position.X);
            Assert.AreEqual(northernTile.Number, _game.Board.CurrentTile.Position.Y);
        }

        [TestMethod]
        public void ChompDown()
        {
            PositionedTile topRightTile = _board.Tiles()[_board.Tiles().Count - 1];
            _board.SetCurrentTile(topRightTile);
            _game.Chomp(Directions.South);
            PositionedTile southernTile = _game.Board.Tiles()[_board.Tiles().Count - _boardSize -1];
            Assert.AreEqual(_boardSize - 1, _game.Board.CurrentTile.Position.X);
            Assert.AreEqual(southernTile.Number, _boardSize - 1 - _game.Board.CurrentTile.Position.Y);
        }

        [TestMethod]
        public void ChompSouthWest()
        {
            PositionedTile topRightTile = _board.Tiles()[_board.Tiles().Count - 1];
            _board.SetCurrentTile(topRightTile);
            _game.Chomp(Directions.SouthWest);
            PositionedTile southEasternTile = _game.Board.Tiles()[_board.Tiles().Count - _boardSize - 2];
            Assert.AreEqual(southEasternTile.Number, _boardSize - 1 - _game.Board.CurrentTile.Position.X);
            Assert.AreEqual(southEasternTile.Number, _boardSize - 1 - _game.Board.CurrentTile.Position.Y);
        }

        [TestMethod]
        public void ChompWest()
        {
            PositionedTile topRightTile = _board.Tiles()[_board.Tiles().Count - 1];
            _board.SetCurrentTile(topRightTile);
            _game.Chomp(Directions.West);
            PositionedTile westernTile = _game.Board.Tiles()[_board.Tiles().Count - 2];
            Assert.AreEqual(_boardSize - 1 - westernTile.Number, _game.Board.CurrentTile.Position.X);
            Assert.AreEqual(_boardSize - 1, _game.Board.CurrentTile.Position.Y);
        }

        [TestMethod]
        public void ChompEast()
        {
            PositionedTile bottomLeftTile = _board.Tiles()[0];
            _board.SetCurrentTile(bottomLeftTile);
            _game.Chomp(Directions.East);
            PositionedTile easternTile = _game.Board.Tiles()[1];
            Assert.AreEqual(easternTile.Number, _game.Board.CurrentTile.Position.X);
            Assert.AreEqual(0, _game.Board.CurrentTile.Position.Y);
        }

        [TestMethod]
        public void CantMove()
        {
            PositionedTile bottomLeftTile = _board.Tiles()[0];
            _board.SetCurrentTile(bottomLeftTile);
            _game.Chomp(Directions.West);
            Assert.AreEqual(0, _game.Board.CurrentTile.Position.X);
            Assert.AreEqual(0, _game.Board.CurrentTile.Position.Y);
        }

        [TestMethod]
        public void ChompNorthEast()
        {
            PositionedTile bottomLetTile = _board.Tiles()[0];
            _board.SetCurrentTile(bottomLetTile);
            _game.Chomp(Directions.NorthEast);
            PositionedTile northeasternTile = _game.Board.Tiles()[_boardSize+1];
            Assert.AreEqual(northeasternTile.Number, _game.Board.CurrentTile.Position.X);
            Assert.AreEqual(northeasternTile.Number, _game.Board.CurrentTile.Position.Y);
        }

        [TestMethod]
        public void Score()
        {
            var expectedScore = 0;
            PositionedTile bottomLetTile = _board.Tiles()[0];
            _board.SetCurrentTile(bottomLetTile);
            _game.Chomp(Directions.NorthEast);
            PositionedTile surroundingTile = _game.Board.Tiles()[_boardSize + 1];
            expectedScore += surroundingTile.Number;
            Assert.AreEqual(expectedScore , _game.Score());
            
            var surroundingTileFinder = new SurroundingTileFinder(_boardSize, _positionFinder);
            surroundingTile = surroundingTileFinder.GetTile(surroundingTileFinder.GetSurroundingPosition(_game.Board.CurrentTile.Position, Directions.East), _game.Board.Tiles());
            expectedScore += surroundingTile.Number;
            _game.Chomp(Directions.East);
            Assert.AreEqual(expectedScore, _game.Score());
        }

        [TestMethod]
        public void TilesRemaining()
        {
            PositionedTile bottomLeftTile = _board.Tiles()[0];
            _board.SetCurrentTile(bottomLeftTile);
            _game.Chomp(Directions.North);
            PositionedTile northernTile = _game.Board.Tiles()[_boardSize];
            var expectedTilesRemaining = _game.Board.Tiles().Count - northernTile.Number - 1;
            Assert.AreEqual(expectedTilesRemaining, _game.TilesRemaining());
        }

        [TestMethod]
        public void AvailableMoves()
        {
            PositionedTile bottomLeftTile = _board.Tiles()[0];
            _board.SetCurrentTile(bottomLeftTile);
            const int expectedMovesRemaining = 3;
            Assert.AreEqual(expectedMovesRemaining, _game.AvailableMoves().Count);
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