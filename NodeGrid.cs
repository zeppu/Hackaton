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

        public Node GetAt(int column, int row)
        {
            return Nodes[(column * Columns) + row];
        }
    }
}