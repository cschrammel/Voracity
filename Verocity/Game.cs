using System;
using System.Collections.Generic;
using System.Linq;

namespace Voracity
{
    public class Game
    {
        private readonly IBoard _board;
        private readonly SurroundingTileFinder _tileFinder;
        private int _score;

        public Game(IBoard board, SurroundingTileFinder tileFinder)
        {
            _board = board;
            _tileFinder = tileFinder;
        }

        public IBoard Board
        {
            get { return _board; }
        }

        public int TilesRemaining()
        {
            return (from t in _board.Tiles() where t.IsActive select t).Count();
        }

        public void NewGame()
        {
            _score = 0;
            _board.ResetTiles();
        }

        public int Score()
        {
            return _score;
        }

        public void Chomp(Directions direction)
        {
            if (CanMove(direction))
            {
                Board.Move(direction);
                var tileWithNumberToMove = Board.CurrentTile;
                for (int i = 1; i < tileWithNumberToMove.Number; i++)
                {
                   _board.Move(direction);
                }
                _score += tileWithNumberToMove.Number;
            }
        }

        private bool CanMove(Directions direction)
        {
            Position surroundingPosition = _tileFinder.GetSurroundingPosition(_board.CurrentTile.Position, direction);
            if (_tileFinder.IsValid(surroundingPosition))
            {
                var nextTile = _tileFinder.GetTile(surroundingPosition, _board.Tiles());
                var nTile = nextTile;                 
                for (int i = 1; i < nextTile.Number; i++)
                {
                    Position nextPosition = _tileFinder.GetSurroundingPosition(nTile.Position, direction);
                    if (!_tileFinder.IsValid(nextPosition)) return false;
                    nTile = _tileFinder.GetTile(nextPosition, _board.Tiles());
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
            return (from direction in Enum.GetValues(typeof(Directions)).Cast<Directions>()
             where CanMove(direction)
                        select _tileFinder.GetTile(_tileFinder.GetSurroundingPosition(_board.CurrentTile.Position, direction), _board.Tiles())).ToList();
        }
    }
}