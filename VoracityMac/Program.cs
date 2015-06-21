using System;

namespace VoracityMac
{
    public class Program
    {
        private const int _boardSize = 17;
        private static Game _gameEngine;
        
        private static void Main(string[] args)
        {
            Console.Clear();
            var positionFinder = new PositionFinder(_boardSize);
            var surroundingTileFinder = new SurroundingTileFinder(_boardSize, positionFinder);
            _gameEngine = new Game(new Board(_boardSize, positionFinder, surroundingTileFinder));
            while (_gameEngine.Board.AvailableMoves().Count > 0)
            {
                DrawBoard(_gameEngine.Board);
                ProcessInput();
            }
            DrawBoard(_gameEngine.Board);
            System.Console.WriteLine("\n\nGame Over.  Score: " + _gameEngine.Score() + ".  Press Enter to continue.");
            System.Console.ReadLine();
        }

        private static void DrawBoard(IBoard board)
        {
            int i = 1;
            foreach (PositionedTile tile in board.Tiles())
            {
                if (board.CurrentTile == tile)
                    DrawColoredSpace(ConsoleColor.Yellow);
                else
                {
                    if (tile.IsActive)
                        System.Console.Write(tile.Number);
                    else
                        DrawColoredSpace(ConsoleColor.Blue);
                }
                System.Console.Write("   ");
                if (i%_boardSize == 0) System.Console.Write("\n\n");
                i++;
            }
        }

        private static void DrawColoredSpace(ConsoleColor background)
        {
            System.Console.BackgroundColor = background;
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write(" ");
            System.Console.ResetColor();
        }

        private static void ProcessInput()
        {
            var k = Console.Read();
            Directions direction = Directions.None;
            var key = Convert.ToChar(k).ToString().ToLower();
            
            switch (key)
            {
                case "e":
                    direction = Directions.North;
                    break;
               case "w":
                    direction = Directions.NorthWest;
                    break;
               case "r":
                    direction = Directions.NorthEast;
                    break;
               case "s":
                    direction = Directions.West;
                    break;
               case "f":
                    direction = Directions.East;
                    break;
               case "d":
                    direction = Directions.South;
                    break;
               case "x":
                    direction = Directions.SouthWest;
                    break;
               case "c":
                    direction = Directions.SouthEast;
                    break;
            }
            _gameEngine.Chomp(direction);
            Console.Clear();
        }
    }
}