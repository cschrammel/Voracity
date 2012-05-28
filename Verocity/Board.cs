using System;
using System.Collections.Generic;

namespace Voracity
{
    public class Board : IBoard
    {
        private readonly int _boardSize;
        private readonly int _maxTiles;
        private readonly PositionFinder _positionFinder;
        private readonly SurroundingTileFinder _tileFinder;
        private readonly List<PositionedTile> _tiles;
        private PositionedTile _currentTile;

        public Board(int boardSize, PositionFinder positionFinder, SurroundingTileFinder tileFinder)
        {
            _boardSize = boardSize;
            _positionFinder = positionFinder;
            _tileFinder = tileFinder;
            _maxTiles = _boardSize*_boardSize;
            _tiles = new List<PositionedTile>();
            ResetTiles();
        }

        #region IBoard Members

        public PositionedTile CurrentTile
        {
            get { return _currentTile; }
            protected set { _currentTile = value; }
        }

        public void Move(Directions direction)
        {
            Position surroundingPosition = _tileFinder.GetSurroundingPosition(_currentTile.Position, direction);
            PositionedTile nextTile = _tileFinder.GetTile(surroundingPosition, Tiles());
            nextTile.Flip();
            _currentTile = nextTile;
        }

        public void ResetTiles()
        {
            var random = new Random();
            _tiles.Clear();
            for (int i = 1; i <= _maxTiles; i++)
            {
                _tiles.Add(new PositionedTile(_positionFinder.GetPosition(i), random.Next(1, 8)));
            }
            _currentTile = _tiles[random.Next(0, _maxTiles)];
            _currentTile.Flip();
        }

        public List<PositionedTile> Tiles()
        {
            return _tiles;
        }

        #endregion
    }
}