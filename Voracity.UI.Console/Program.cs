using System;

namespace Voracity.UI.Console
{
    public class Program
    {
        private const int _boardSize = 10;
        private static Game _gameEngine;
        private static KeyboardInputMapper _inputMapper;

        private static void Main(string[] args)
        {
            var positionFinder = new PositionFinder(_boardSize);
            var surroundingTileFinder = new SurroundingTileFinder(_boardSize, positionFinder);
            _gameEngine = new Game(new Board(_boardSize, positionFinder, surroundingTileFinder),
                                   surroundingTileFinder);
            _inputMapper = new KeyboardInputMapper();
            while (_gameEngine.AvailableMoves().Count > 0)
            {
                System.Console.Clear();
                System.Console.WriteLine(GetControlsInstructions());
                DrawBoard(_gameEngine.Board);
                ProcessInput();
            }
            System.Console.WriteLine("\n\nGame Over.  Score: " + _gameEngine.Score() + ".  Press Enter to continue.");
            System.Console.ReadLine();
        }

        private static string GetControlsInstructions()
        {
            return String.Format(
                "Keys: Up={0}, Down={1}, Left={2}, Right={3}, \n" +
                "Up-Left={4}, Up-Right={5}, Down-Left={6}, Down-Right={7}\n\n",
                _inputMapper.GetKey(Directions.South), _inputMapper.GetKey(Directions.North),
                _inputMapper.GetKey(Directions.West), _inputMapper.GetKey(Directions.East),
                _inputMapper.GetKey(Directions.SouthWest), _inputMapper.GetKey(Directions.SouthEast),
                _inputMapper.GetKey(Directions.NorthWest), _inputMapper.GetKey(Directions.NorthEast));
        }

        private static void DrawBoard(IBoard board)
        {
            int i = 1;
            foreach (PositionedTile tile in board.Tiles())
            {
                if (board.CurrentTile == tile)
                {
                    System.Console.BackgroundColor = ConsoleColor.Yellow;
                    System.Console.ForegroundColor = ConsoleColor.White;
                    System.Console.Write(" ");
                    System.Console.ResetColor();
                }
                else
                {
                    if (tile.IsActive)
                        System.Console.Write(tile.Number);
                    else
                    {
                        System.Console.BackgroundColor = ConsoleColor.Blue;
                        System.Console.ForegroundColor = ConsoleColor.White;
                        System.Console.Write(" ");
                        System.Console.ResetColor();
                    }
                }
                System.Console.Write("   ");
                if (i%_boardSize == 0) System.Console.Write("\n\n");
                i++;
            }
        }

        private static void ProcessInput()
        {
            ConsoleKeyInfo input = System.Console.ReadKey();
            _gameEngine.Chomp(_inputMapper.GetDirection(input.Key));
        }
    }
}