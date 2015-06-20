namespace VoracityMac
{
    public class PositionedTile : Tile
    {
        public PositionedTile(Position position, int number) : base(number)
        {
            Position = position;
        }

        public Position Position { get; set; }
    }
}