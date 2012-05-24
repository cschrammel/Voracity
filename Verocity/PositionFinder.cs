using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Voracity
{
    public class PositionFinder
    {
        public Position GetPosition(int positionIndex, int boardSize)
        {
            return new Position(((positionIndex - 1) % boardSize), (positionIndex - 1) / boardSize);
        }
    }
}
