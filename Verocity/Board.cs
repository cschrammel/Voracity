using System;
using System.Collections.Generic;

namespace Voracity
{
    public class Board : IBoard
    {
        private readonly int _boardSize;
        private readonly PositionFinder _positionFinder;
        private readonly int _maxTiles;
        private readonly List<PositionedTile> _tiles;
        private PositionedTile _currentTile;

        public Board(int boardSize, PositionFinder positionFinder)
        {
            _boardSize = boardSize;
            _positionFinder = positionFinder;
            _maxTiles = _boardSize*_boardSize;
            _tiles = new List<PositionedTile>();
            Reset();
        }

        public PositionedTile CurrentTile
        {
            get { return _currentTile; }
        }

        public void Reset()
        {
            var random = new Random();
            _tiles.Clear();
            for (int i = 1; i <= _maxTiles; i++)
            {
                _tiles.Add(new PositionedTile(_positionFinder.GetPosition(i, _boardSize), random.Next(1, 8)));
            }
            _currentTile = _tiles[random.Next(0, _maxTiles)];
        }

        public List<PositionedTile> Tiles()
        {
            return _tiles;
        }
    }
}