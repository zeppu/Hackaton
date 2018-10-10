using System.Collections.Generic;

namespace GrandPrixApp
{
    public static class KnownMovements
    {
        public static IReadOnlyList<Movement> Values = new List<Movement>
        {
            new Movement(0, 0),
            new Movement(-1, -1),
            new Movement(0, -1),
            new Movement(1, -1),
            new Movement(1, 0),
            new Movement(1, 1),
            new Movement(0, 1),
            new Movement(-1, 1),
            new Movement(-1, 0)
        };

        public static Movement C => Values[0];
        public static Movement NW => Values[1];
        public static Movement N => Values[2];
        public static Movement NE => Values[3];
        public static Movement E => Values[4];
        public static Movement SE => Values[5];
        public static Movement S => Values[6];
        public static Movement SW => Values[7];
        public static Movement W => Values[8];
    }
}