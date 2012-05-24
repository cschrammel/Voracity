namespace Voracity
{
    public class Tile
    {
        public int Number { get; set; }

        public bool IsActive { get; set; }

        public Tile(int number)
        {
            Number = number;
            IsActive = true;
        }
    }
}