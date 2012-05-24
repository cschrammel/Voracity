using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Voracity.Tests
{
    [TestClass]
    public class TestPositionFinder
    {
        private PositionFinder _positionFinder;
        private const int _boardSize = 5;

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

        private void AssertTilePosition(int position, int expectedX, int expectedY)
        {
            Position positionOfTile = _positionFinder.GetPosition(position);
            Assert.AreEqual(expectedX, positionOfTile.X);
            Assert.AreEqual(expectedY, positionOfTile.Y);
        }

    }
}
