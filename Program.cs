using System;
using System.Collections.Generic;
using System.Linq;

namespace GrandPrixApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid =
                "000000000000000000000000000000000000000021110000000000000000000000000000000000002111111000000000000000000000000000000000211111111000000000000000000000000000000021111111110000000000000000000000000000002111111111100000000000000000000000000000200000111110000000000000000000000000000000000001111100000000000000011111000000000000000011111000000000001111111111100000000000000111100000000001111111111111110000000000011110000000001111111111111111130000000001111100000001111111111111111113000000000111110000000111111111111111111300000000001111000000111111111111111111130000000000111100000011111111111111111113000000000011110000011111110000000000000000000000001111000001111100000000000000000000000000111100000111110000000000000000000000000011110000011111000000000000000000000000001111000001111100000000000000000000000000111110001111110000000000000000000000000011111000111111000000000000000000000000001111100011111000000000000000000000000000011111111111100000000000000000000000000000111111111110000000000000000000000000000001111111110000000000000000000000000000000001111100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            var rows = 30;
            var cols = 40;

            var Nodelist = NodeGenerator.GenerateNodes(grid, cols, rows);
            var gridz = new NodeGrid(Nodelist, cols, rows);
            foreach (var node in Nodelist)
            {
                Console.SetCursorPosition(node.X+1, node.Y+1);
                switch (node.TrackType)
                {
                    case NodeType.OffTrack:
                        Console.BackgroundColor = ConsoleColor.Gray;
                        break;
                    case NodeType.Track:
                        Console.BackgroundColor = ConsoleColor.White;
                        break;
                    case NodeType.Start:
                        Console.BackgroundColor = ConsoleColor.Red;
                        break;;
                    case NodeType.End:
                        Console.BackgroundColor = ConsoleColor.Green;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Console.WriteLine(" ");
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadKey();
        }
    }

    public class NodeGenerator
    {
        public static IList<Node> GenerateNodes(string nodestring, int columns, int rows)
        {
            var rowList = Enumerable.Range(0, nodestring.Length / columns)
                .Select(i => nodestring.Substring(i * columns, columns)).ToList();

            var finalList = new List<Node>(nodestring.Length);

            for (var i = 0; i < rowList.Count(); i++)
            {
                var y = i;

                var values = rowList[i].Select((x, j) => new Node(j, y, (NodeType) x - '0'));

                finalList.AddRange(values);
            }

            return finalList;
        }
    }

    public class Node
    {
        public int X => Position.X;
        public int Y => Position.Y;
        public Coordinate Position { get; }

        public Node PreviousNode { get; set; }
        public int PathLength { get; set; }
        public NodeType TrackType { get; set; }

        public Node()
        {
        }

        public Node(int x, int y, NodeType type)
        {
            Position = (x, y);
            TrackType = type;
        }
    }

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

    public enum NodeType
    {
        OffTrack = 0,
        Track = 1,
        Start = 2,
        End = 3
    }

    public class NodeGrid
    {
        public IList<Node> Nodes { get; }
        public int Columns { get; }
        public int Rows { get; }

        public NodeGrid(IList<Node> nodes, int columns, int rows)
        {
            Nodes = nodes;
            Columns = columns;
            Rows = rows;
        }

        public Node GetAt(int column, int row)
        {
            return Nodes[(column * Columns) + row];
        }
    }

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

        public Vector()
        {
            
        }

        /// <inheritdoc />
        public Vector(Coordinate start, Coordinate end)
        {
            Start = start;
            End = end;
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
            return new Vector((current.End))
            {
                StartX = current.EndX,
                StartY = current.EndY,
                EndX = current.EndX + (that.X),
                EndY = current.EndY + (that.Y)
            };
        }
    }

    public static class VectorExtensions
    {
        public static IList<Vector> GenerateAllNextMoves(this Vector vector)
        {
            var x = vector.MoveForward();

            var list = new HashSet<Vector>();

            for (var i = -1; i <= 1; i++)
            {
                for (var j = -1; j <= 1; j++)
                {
                    var item = x + (i, j);
                    list.Add(item);
                }
            }

            return list.ToList();
        }

        public static Vector MoveForward(this Vector vector)
        {
            return new Vector
            {
                StartX = vector.EndX,
                StartY = vector.EndY,
                EndX = vector.EndX + vector.DiffX,
                EndY = vector.EndY + vector.DiffY
            };
        }
    }
}