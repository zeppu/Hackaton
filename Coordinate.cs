namespace GrandPrixApp
{
    public class Coordinate
    {
        public int X { get; }
        public int Y { get; }

        /// <inheritdoc />
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Coordinate operator +(Coordinate current, Coordinate that)
        {
            return new Coordinate(current.X + that.X, current.Y + that.Y);
        }

        public static Coordinate operator +(Coordinate current, (int X, int Y) that)
        {
            return new Coordinate(current.X + that.X, current.Y + that.Y);
        }

        public static implicit operator Coordinate((int, int) value)
        {
            return new Coordinate(value.Item1, value.Item2);
        }
    }
}