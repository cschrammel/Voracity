using System;
using System.Collections.Generic;
using System.Linq;

namespace VoracityMac
{
    public class SurroundingTileFinder
    {
        private readonly int _boardSize;
        private readonly PositionFinder _positionFinder;

        public SurroundingTileFinder(int boardSize, PositionFinder positionFinder)
        {
            _boardSize = boardSize;
            _positionFinder = positionFinder;
        }

        public List<PositionedTile> GetSurroundingTiles(Position start, List<PositionedTile> tiles)
        {
            return (from direction in Enum.GetValues(typeof (Directions)).Cast<Directions>() 
                    select GetSurroundingPosition(start, direction) 
                    into p 
                    where IsValid(p) 
                    select GetTile(p, tiles)).ToList();
        }

        public bool IsValid(Position position)
        {
            if (position.X < 0 || position.Y < 0) return false;
            if (position.X > _boardSize - 1 || position.Y > _boardSize - 1) return false;
            return true;
        }

        public PositionedTile GetTile(Position position, List<PositionedTile> tiles)
        {
            return tiles[_positionFinder.GetIndex(position)];
        }

        public Position GetSurroundingPosition(Position start, Directions direction)
        {
            Position position;
            switch (direction)
            {
                case Directions.North:
                    position = new Position(start.X, start.Y - 1);
                    break;
                case Directions.South:
                    position = new Position(start.X, start.Y + 1);
                    break;
                case Directions.West:
                    position = new Position(start.X - 1, start.Y);
                    break;
                case Directions.East:
                    position = new Position(start.X + 1, start.Y);
                    break;
                case Directions.NorthEast:
                    position = new Position(start.X + 1, start.Y - 1);
                    break;
                case Directions.NorthWest:
                    position = new Position(start.X - 1, start.Y - 1);
                    break;
                case Directions.SouthWest:
                    position = new Position(start.X - 1, start.Y + 1);
                    break;
                default:
                    position = new Position(start.X + 1, start.Y + 1);
                    break;
            }
            return position;
        }
    }
}