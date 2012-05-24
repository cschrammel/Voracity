using System.Collections.Generic;

namespace Voracity
{
    public interface IBoard
    {
        PositionedTile CurrentTile { get; }
        void Reset();
        List<PositionedTile> Tiles();
    }
}