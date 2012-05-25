using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Voracity.Tests
{
    [TestClass]
    public class TestGame
    {
        private const int _boardSize = 5;
        private Game _game;

        [TestInitialize]
        public void TestInit()
        {
            List<PositionedTile> tiles;
            Mock<IBoard> board = CreateMockBoard(out tiles);
            _game = new Game(board.Object);
        }

        private static Mock<IBoard> CreateMockBoard(out List<PositionedTile> tiles)
        {
            var board = new Mock<IBoard>();
            tiles = new List<PositionedTile>();
            for (int i = 0; i < _boardSize*_boardSize; i++)
                tiles.Add(new PositionedTile(new PositionFinder(_boardSize).GetPosition(i), 1));
            board.Setup(b => b.Tiles()).Returns(tiles);
            board.Setup(b => b.CurrentTile).Returns(tiles[0]);
            return board;
        }

        [TestMethod]
        public void NewGame()
        {
            _game.NewGame();
            Assert.AreEqual(0, _game.Score());
            Assert.AreEqual(_boardSize*_boardSize, _game.TilesRemaining());
            Assert.IsNotNull(_game.Board);
        }

    }
}