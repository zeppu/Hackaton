namespace GrandPrixApp
{
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
}