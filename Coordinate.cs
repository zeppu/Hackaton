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

        public static bool operator ==(Coordinate first, Coordinate second)
        {
            if (ReferenceEquals(first, second)) return true;
            if (ReferenceEquals(null, second)) return false;
            if (ReferenceEquals(null, first)) return false;
            if (first.GetType() != second.GetType())
                return false;
            return first.Equals(second);
        }


        public static bool operator !=(Coordinate first, Coordinate second)
        {
            return !(first == second);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Coordinate) obj);
        }

        protected bool Equals(Coordinate other)
        {
            return X == other.X && Y == other.Y;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}