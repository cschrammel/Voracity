namespace Voracity.Tests
{
    public class BoardTestDouble : Board
    {
        public BoardTestDouble(int boardSize, PositionFinder positionFinder, SurroundingTileFinder tileFinder)
            : base(boardSize, positionFinder, tileFinder)
        {
        }

        public void SetCurrentTile(PositionedTile tile)
        {
            CurrentTile = tile;
        }
    }
}