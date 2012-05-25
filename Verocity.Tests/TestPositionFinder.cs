using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Voracity.Tests
{
    [TestClass]
    public class TestPositionFinder
    {
        private const int _boardSize = 5;
        private PositionFinder _positionFinder;

        [TestInitialize]
        public void TestInit()
        {
            _positionFinder = new PositionFinder(_boardSize);
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

        [TestMethod]
        public void IndexOfTile1()
        {
            Assert.AreEqual(0, _positionFinder.GetIndex(new Position(0, 0)));
        }

        [TestMethod]
        public void IndexOfTile24()
        {
            Assert.AreEqual(23, _positionFinder.GetIndex(new Position(3, 4)));
        }

        [TestMethod]
        public void IndexOfTile25()
        {
            Assert.AreEqual(24, _positionFinder.GetIndex(new Position(4, 4)));
        }

        private void AssertTilePosition(int position, int expectedX, int expectedY)
        {
            Position positionOfTile = _positionFinder.GetPosition(position);
            Assert.AreEqual(expectedX, positionOfTile.X);
            Assert.AreEqual(expectedY, positionOfTile.Y);
        }
    }
}