using System.Collections.Generic;
using System.Linq;

namespace GrandPrixApp
{
    public class Node
    {
        public int X => Position.X;
        public int Y => Position.Y;
        public Coordinate Position { get; }

        public Node PreviousNode { get; set; }
        public int PathLength { get; set; }
        public NodeType TrackType { get; }
        public bool IsWinner { get; set; }

        public Node()
        {
        }

        public Node(int x, int y, NodeType type, int? length = null)
        {
            Position = (x, y);
            TrackType = type;
            PathLength = length ?? int.MaxValue;
        }
    }

    public static class NodeExtentsions
    {
        private static readonly IList<Coordinate> Diagonals = new List<Coordinate>()
        {
            (-1, -1),
            (-1, 1),
            (1, -1),
            (1, 1)
        };

        private static readonly IList<Coordinate> Laterals = new List<Coordinate>()
        {
            (-1, 0),
            (1, 0),
            (0, -1),
            (0, 1)
        };

        public static IList<Node> GetNeighbours(this Node node, NodeGrid grid)
        {
            var list = new HashSet<Node>();

            foreach (var coordinate in Laterals)
            {
                var pos = node.Position + coordinate;
                if (grid.IsValidNode(pos))
                {
                    list.Add(grid.GetAt(pos));
                }
            }

            foreach (var coordinate in Diagonals)
            {
                var pos = node.Position + coordinate;
                if (grid.IsValidNode(pos))
                {
                    list.Add(grid.GetAt(pos));
                }
            }

            return list.ToList();
        }

        public static IList<Node> UpdateIfClosest(this IList<Node> nodes, Node parent)
        {
            var distance = parent.PathLength + 1;
            var finalList = new List<Node>();
            foreach (var node in nodes)
            {
                if (distance < node.PathLength)
                {
                    node.PathLength = distance;
                    node.PreviousNode = parent;
                    finalList.Add(node);
                }
            }

            return finalList;
        }
    }

    
}