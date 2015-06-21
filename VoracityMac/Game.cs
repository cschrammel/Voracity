using System.Linq;

namespace VoracityMac
{
    public class Game
    {
        private readonly IBoard _board;
        private int _score;

        public Game(IBoard board)
        {
            _board = board;
        }

        public IBoard Board
        {
            get { return _board; }
        }

        public int TilesRemaining()
        {
            return _board.Tiles().Count(t => t.IsActive);
        }

        public void NewGame()
        {
            _score = 0;
            _board.ResetTiles();
        }

        public int Score()
        {
            return _score;
        }

        public void Chomp(Directions direction)
        {
            if (_board.CanMove(direction))
            {
                Board.Move(direction);
                var tileWithNumberToMove = Board.CurrentTile;
                for (int i = 1; i < tileWithNumberToMove.Number; i++)
                {
                    _board.Move(direction);
                }
                _score += tileWithNumberToMove.Number;
            }
        }
    }
}