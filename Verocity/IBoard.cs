using System.Collections.Generic;

namespace Voracity
{
    public interface IBoard
    {
        PositionedTile CurrentTile { get; }
        void ResetTiles();
        List<PositionedTile> Tiles();
        void Move(Directions direction);
        bool CanMove(Directions direction);
        List<PositionedTile> AvailableMoves();
    }
}