using System.Collections.Generic;

namespace Voracity
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
            var surroundingTiles = new List<PositionedTile>();

            Position n = GetSurroundingPosition(start, Directions.North);
            if (IsValid(n)) surroundingTiles.Add(GetTile(n, tiles));

            Position s = GetSurroundingPosition(start, Directions.South);
            if (IsValid(s)) surroundingTiles.Add(GetTile(s, tiles));

            Position w = GetSurroundingPosition(start, Directions.West);
            if (IsValid(w)) surroundingTiles.Add(GetTile(w, tiles));

            Position e = GetSurroundingPosition(start, Directions.East);
            if (IsValid(e)) surroundingTiles.Add(GetTile(e, tiles));

            Position ne = GetSurroundingPosition(start, Directions.NorthEast);
            if (IsValid(ne)) surroundingTiles.Add(GetTile(ne, tiles));

            Position se = GetSurroundingPosition(start, Directions.SouthEast);
            if (IsValid(se)) surroundingTiles.Add(GetTile(se, tiles));

            Position nw = GetSurroundingPosition(start, Directions.NorthWest);
            if (IsValid(nw)) surroundingTiles.Add(GetTile(nw, tiles));

            Position sw = GetSurroundingPosition(start, Directions.SouthWest);
            if (IsValid(sw)) surroundingTiles.Add(GetTile(sw, tiles));

            return surroundingTiles;
        }

        private bool IsValid(Position position)
        {
            if (position.X < 0 || position.Y < 0) return false;
            if (position.X > _boardSize - 1 || position.Y > _boardSize - 1) return false;
            return true;
        }

        private PositionedTile GetTile(Position n, List<PositionedTile> tiles)
        {
            return tiles[_positionFinder.GetIndex(n)];
        }

        private Position GetSurroundingPosition(Position start, Directions direction)
        {
            Position position;
            switch (direction)
            {
                case Directions.North:
                    position = new Position(start.X, start.Y + 1);
                    break;
                case Directions.South:
                    position = new Position(start.X, start.Y - 1);
                    break;
                case Directions.West:
                    position = new Position(start.X - 1, start.Y);
                    break;
                case Directions.East:
                    position = new Position(start.X + 1, start.Y);
                    break;
                case Directions.NorthEast:
                    position = new Position(start.X + 1, start.Y + 1);
                    break;
                case Directions.NorthWest:
                    position = new Position(start.X - 1, start.Y + 1);
                    break;
                case Directions.SouthWest:
                    position = new Position(start.X - 1, start.Y - 1);
                    break;
                default:
                    position = new Position(start.X + 1, start.Y - 1);
                    break;
            }
            return position;
        }
    }
}