namespace VoracityMac
{
    public class Tile
    {
        public int Number { get; set; }

        public bool IsActive { get; private set; }

        public Tile(int number)
        {
            Number = number;
            IsActive = true;
        }

        public void Flip()
        {
            IsActive = false;
        }
    }
}