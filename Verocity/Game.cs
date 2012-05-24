using System;
using System.Collections.Generic;

namespace Voracity
{
    public class Game
    {
        private readonly int _boardSize;
        private int _score;
        private List<Tile> _tiles;

        public Game(int boardSize)
        {
            _boardSize = boardSize;
            _tiles = new List<Tile>();
            
        }

        public void NewGame()
        {
            _score = 0;
            var random = new System.Random();
            _tiles = new List<Tile>();
            for (int i = 0; i <= _boardSize*2; i++)
            {
                _tiles.Add(new Tile(random.Next(1,8)));
            }
    }

        public int Score()
        {
            return _score;
        }

        public int TilesLeft()
        {
            return _boardSize*_boardSize;
        }

        public List<Tile> Tiles()
        {
            return _tiles;
        }
    }
}