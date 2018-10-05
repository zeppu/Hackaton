using System.Collections.Generic;
using System.Linq;

namespace GrandPrixApp
{
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

        public Node GetAt(int x, int y)
        {
            return Nodes[(y * Columns) + x];
        }

        public Node GetAt(Coordinate coordinate)
        {
            return GetAt(coordinate.X, coordinate.Y);
        }

        public bool IsValidNode(Coordinate coordinate)
        {
            if (coordinate.X < 0 || coordinate.X >= Columns)
            {
                return false;
            }

            if (coordinate.Y < 0 || coordinate.Y >= Rows)
            {
                return false;
            }

            if (GetAt(coordinate.X, coordinate.Y).TrackType == NodeType.OffTrack)
            {
                return false;
            }

            return true;
        }
    }

    public static class NodeGridExtensions
    {
        public const int MAX_DISTANCE = 5;

        public static (Node node, int distance) FindClosestWinner(this NodeGrid grid, Coordinate point)
        {
            var distance = 0;
            var node = grid.GetAt(point);
            if (node.IsWinner)
            {
                return (node, distance);
            }

            distance++;

            for (var i = distance; i < MAX_DISTANCE; i++)
            {
                var winner = GetNeighbours(node.Position, i).FirstOrDefault(m => grid.GetAt(m).IsWinner);
                if (winner != null)
                    return (grid.GetAt(winner), i);
            }

            return (null, -1);
        }

        

        private static IList<Coordinate> GetNeighbours(Coordinate point, int distance)
        {
            var result = new List<Coordinate>()
            {
                point + (-distance, -distance),
                point + (-distance, distance),
                point + (distance, -distance),
                point + (distance, distance)
            };

            for (var i = -distance; i <= distance; i++)
            {
                result.Add(point + (-distance, i));
                result.Add(point + (distance, i));
                result.Add(point + (i, -distance));
                result.Add(point + (i, distance));
            }

            return result;
        }
    }
}