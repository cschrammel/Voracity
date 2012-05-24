using System.Linq;

namespace Voracity
{
    public class Game
    {
        private readonly Board _board;
        private int _score;

        public Game(int boardSize)
        {
            _board = new Board(boardSize);
        }

        public Board Board
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
            _board.Reset();
        }

        public int Score()
        {
            return _score;
        }
    }
}