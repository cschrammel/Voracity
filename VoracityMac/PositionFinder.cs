namespace VoracityMac
{
    public class PositionFinder
    {
        private readonly int _boardSize;

        public PositionFinder(int boardSize)
        {
            _boardSize = boardSize;
        }

        public Position GetPosition(int positionIndex)
        {
            return new Position(((positionIndex - 1) % _boardSize), (positionIndex - 1) / _boardSize);
        }

        public int GetIndex(Position position)
        {
            return (position.Y) * _boardSize + position.X;
        }
    }
}