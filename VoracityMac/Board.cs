using System;
using System.Collections.Generic;
using System.Linq;

namespace VoracityMac
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

        public bool CanMove(Directions direction)
        {
        Position surroundingPosition = _tileFinder.GetSurroundingPosition(_currentTile.Position, direction);
            if (_tileFinder.IsValid(surroundingPosition))
            {
                PositionedTile nextTile = _tileFinder.GetTile(surroundingPosition, _tiles);
                PositionedTile nTile = nextTile;
                if (nTile.IsActive == false) return false;
                for (int i = 1; i < nextTile.Number; i++)
                {
                    Position nextPosition = _tileFinder.GetSurroundingPosition(nTile.Position, direction);
                    if (!_tileFinder.IsValid(nextPosition)) return false;
                    nTile = _tileFinder.GetTile(nextPosition, _tiles);
                    if (nTile.IsActive == false) return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public List<PositionedTile> AvailableMoves()
        {
            return (from direction in GetAllDirections()
                    where CanMove(direction)
                    select GetSurroundingTile(direction)).ToList();
        }

        private PositionedTile GetSurroundingTile(Directions direction)
        {
            return _tileFinder.GetTile(
                _tileFinder.GetSurroundingPosition(_currentTile.Position, direction), _tiles);
        }

        private IEnumerable<Directions> GetAllDirections()
        {
            return Enum.GetValues(typeof(Directions)).Cast<Directions>();
        }
    }
}