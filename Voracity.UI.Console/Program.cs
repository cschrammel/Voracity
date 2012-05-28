using System;

namespace Voracity.UI.Console
{
    public class Program
    {
        private const int _boardSize = 10;
        private static Game _gameEngine;

        private static void Main(string[] args)
        {
            var positionFinder = new PositionFinder(_boardSize);
            var surroundingTileFinder = new SurroundingTileFinder(_boardSize, positionFinder);
            _gameEngine = new Game(new Board(_boardSize, positionFinder, surroundingTileFinder),
                                   surroundingTileFinder);
            while (_gameEngine.AvailableMoves().Count > 0)
            {
                System.Console.Clear();
                System.Console.WriteLine(
                    String.Format(
                        "Keys: Up={0}, Down={1}, Left={2}, Right={3}, \n" +
                        "Up-Left={4}, Up-Right={5}, Down-Left={6}, Down-Right={7}\n\n",
                        "W", "X", "A", "D", "Q", "E", "Z", "C"));
                DrawBoard(_gameEngine.Board);
                ProcessInput();
            }
            System.Console.WriteLine("\n\nGame Over.  Score: " + _gameEngine.Score() + ".  Press Enter to continue.");
            System.Console.ReadLine();
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
            _gameEngine.Chomp(InputMapper(input));
        }

        private static Directions InputMapper(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.W:
                    return Directions.South;
                case ConsoleKey.X:
                    return Directions.North;
                case ConsoleKey.D:
                    return Directions.East;
                case ConsoleKey.A:
                    return Directions.West;
                case ConsoleKey.Q:
                    return Directions.SouthWest;
                case ConsoleKey.E:
                    return Directions.SouthEast;
                case ConsoleKey.Z:
                    return Directions.NorthWest;
                case ConsoleKey.C:
                    return Directions.NorthEast;
                default:
                    return Directions.None;
            }
        }
    }
}