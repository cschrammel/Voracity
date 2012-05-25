using System.Collections.Generic;

namespace Voracity
{
    public interface IBoard
    {
        PositionedTile CurrentTile { get; set; }
        void ResetTiles();
        List<PositionedTile> Tiles();
    }
}