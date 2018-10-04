using System;

namespace GrandPrixApp
{
    public class Vector
    {
        public Coordinate Start { get; set; }
        public Coordinate End { get; set; }
        public int StartX => Start.X;
        public int StartY => Start.Y;
        public int EndX => End.X;
        public int EndY => End.Y;
        public int DiffX => EndX - StartX;
        public int DiffY => EndY - StartY;
        public int Speed => Math.Abs(DiffX) + Math.Abs(DiffY);
        public int MoveCount { get; set; } = 0;
        public Vector Parent { get; }

        public Vector()
        {
            
        }

        /// <inheritdoc />
        public Vector(Coordinate start, Coordinate end, Vector parent)
        {
            Start = start;
            End = end;
            Parent = parent;
            if (parent != null)
                MoveCount = parent.MoveCount + 1;
        }

        public static bool operator ==(Vector a, Vector b)
        {
            if (a?.EndY == b?.EndY && a?.EndX == b?.EndX)
                return true;

            return false;
        }

        public static bool operator !=(Vector a, Vector b)
        {
            return !(a == b);
        }

        public static Vector operator +(Vector current, (int X, int Y) that)
        {
            return new Vector((current.EndX, current.EndY), (current.EndX + that.X, current.EndY + that.Y), current);

        }
    }
}