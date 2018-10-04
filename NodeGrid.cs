using System.Collections.Generic;

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

        public bool IsValidNode(Coordinate coordinate)
        {
            if (coordinate.X < 0 || coordinate.X >= Columns)
            {
                return false;
            }

            if(coordinate.Y < 0 || coordinate.Y >= Rows)
            {
                return false;
            }

            if (GetAt(coordinate.X, coordinate.Y).TrackType == NodeType.OffTrack || GetAt(coordinate.X, coordinate.Y).TrackType == NodeType.Start)
            {
                return false;
            }

            return true;
        }
    }
}