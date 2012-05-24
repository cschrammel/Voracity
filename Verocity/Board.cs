using System;
using System.Collections.Generic;

namespace Voracity
{
    public class Board
    {
        private readonly int _boardSize;

        private readonly int _maxTiles;
        private readonly List<PositionedTile> _tiles;
        private PositionedTile _currentTile;

        public Board(int boardSize)
        {
            _boardSize = boardSize;
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
                _tiles.Add(new PositionedTile(GetPosition(i), random.Next(1, 8)));
            }
            _currentTile = _tiles[random.Next(0, _maxTiles)];
        }

        private Position GetPosition(int i)
        {
            return new Position(((i-1)%_boardSize), (i-1) / _boardSize);
        }

        public List<PositionedTile> Tiles()
        {
            return _tiles;
        }
    }
}