using System;
using System.Collections;
using System.Linq;

namespace Voracity.UI.Console
{
    public class KeyboardInputMapper
    {
        private readonly Hashtable _keys;

        public KeyboardInputMapper()
        {
            _keys = new Hashtable
                        {
                            {ConsoleKey.W, Directions.South},
                            {ConsoleKey.X, Directions.North},
                            {ConsoleKey.D, Directions.East},
                            {ConsoleKey.A, Directions.West},
                            {ConsoleKey.Q, Directions.SouthWest},
                            {ConsoleKey.E, Directions.SouthEast},
                            {ConsoleKey.Z, Directions.NorthWest},
                            {ConsoleKey.C, Directions.NorthEast}
                        };
        }

        public Directions GetDirection(ConsoleKey key)
        {
            if (_keys.ContainsKey(key)) return (Directions) _keys[key];
            return Directions.None;
        }

        public ConsoleKey GetKey(Directions direction)
        {
            return FindKey(direction);
        }

        private ConsoleKey FindKey(Directions direction)
        {
            foreach (var key in _keys.Keys.Cast<ConsoleKey>().Where(key => (Directions) _keys[key] == direction))
            {
                return key;
            }
            return ConsoleKey.Enter;
        }
    }
}