using System;

namespace GrandPrixApp
{
    public struct Movement
    {
        public static readonly Movement Empty;

        public int X { get; set; }
        public int Y { get; set; }
        public int Speed => Math.Abs(X) + Math.Abs(Y);

        public Movement(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Movement other)
        {
            return X == other.X && Y == other.Y;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return obj is Movement move && Equals(move);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public Movement NextMove(Movement offset = default(Movement))
        {
            return this + offset;
        }

        public static Movement operator +(Movement first, Movement second)
        {
            return new Movement
            {
                X = first.X + second.X,
                Y = first.Y + second.Y
            };
        }

        public static bool operator ==(Movement first, Movement second)
        {
            return first.Equals(second);
        }

        public static implicit operator Movement((int x, int y) move)
        {
            return new Movement(move.x, move.y);
        }

        public static bool operator !=(Movement first, Movement second)
        {
            return !first.Equals(second);
        }

        public static Move operator *(Coordinate coordinate, Movement movement)
        {
            var end = new Coordinate(
                coordinate.X + movement.X,
                coordinate.Y + movement.Y
            );

            return new Move
            {
                End = end,
                Start = coordinate,
                Movement = movement
            };
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
} 