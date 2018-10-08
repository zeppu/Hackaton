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

	public class Fitness
	{
		public Node ClosestNode { get; set; }
		public int Distance { get; set; }
		public Vector Point { get; set; }
		public int Value => ClosestNode.PathLength * (20 - Distance);
	}

    public static class NodeGridExtensions
    {
        public const int MAX_DISTANCE = 5;

        public static Fitness FindClosestWinner(this NodeGrid grid, Vector vector)
        {
            var distance = 0;
	        
            var node = grid.GetAt(vector.End);
            if (node.IsWinner)
            {
	            return new Fitness()
	            {
		            ClosestNode = node,
		            Distance = distance,
		            Point = vector
	            };
            }

            distance++;

            for (var i = distance; i < MAX_DISTANCE; i++)
            {
                var winner = GetNeighbours(node.Position, i).FirstOrDefault(m => grid.IsValidNode(m) && grid.GetAt(m).IsWinner);
                if (winner != null)
	                return new Fitness()
	                {
		                ClosestNode = grid.GetAt(winner),
		                Distance = i,
		                Point = vector
	                };
            }

	        return null;
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