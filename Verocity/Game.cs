using System.Linq;

namespace Voracity
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

        public PositionedTile CurrentTile
        {
            get { return _board.CurrentTile; }
        }

        public int TilesRemaining()
        {
            return (from t in _board.Tiles() where t.IsActive select t).Count();
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
    }
}