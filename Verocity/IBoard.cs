using System.Collections.Generic;

namespace Voracity
{
    public interface IBoard
    {
        PositionedTile CurrentTile { get; }
        void ResetTiles();
        List<PositionedTile> Tiles();
    }
}