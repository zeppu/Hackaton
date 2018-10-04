using System;
using System.Collections.Generic;
using System.Linq;

namespace GrandPrixApp
{
    class Program
    {
        public static IList<Vector> SuccessPaths = new List<Vector>();

        static void Main(string[] args)
        {
            var grid =
                "000000000000000000000000000000000000000021110000000000000000000000000000000000002111111000000000000000000000000000000000211111111000000000000000000000000000000021111111110000000000000000000000000000002111111111100000000000000000000000000000200000111110000000000000000000000000000000000001111100000000000000011111000000000000000011111000000000001111111111100000000000000111100000000001111111111111110000000000011110000000001111111111111111130000000001111100000001111111111111111113000000000111110000000111111111111111111300000000001111000000111111111111111111130000000000111100000011111111111111111113000000000011110000011111110000000000000000000000001111000001111100000000000000000000000000111100000111110000000000000000000000000011110000011111000000000000000000000000001111000001111100000000000000000000000000111110001111110000000000000000000000000011111000111111000000000000000000000000001111100011111000000000000000000000000000011111111111100000000000000000000000000000111111111110000000000000000000000000000001111111110000000000000000000000000000000001111100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            var rows = 30;
            var cols = 40;

            var nodelist = NodeGenerator.GenerateNodes(grid, cols, rows);

            var gridz = new NodeGrid(nodelist, cols, rows);
            foreach (var node in nodelist)
            {
                Console.SetCursorPosition(node.X, node.Y);
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
                        break; ;
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

            var startingPoints = nodelist.Where(m => m.TrackType == NodeType.Start)
                .Select(m => new Vector(m.Position, m.Position, null)).ToList();

            ExtractNextGen(gridz, startingPoints,0);
        }

        private static void ExtractNextGen(NodeGrid gridz, IEnumerable<Vector> moves, int gen)
        {
            var nextGenMoves = new List<Vector>();

            foreach (var nextMove in moves)
            {
                var vectors = nextMove.GenerateAllNextMoves()
                    .Where(z => gridz.IsValidNode(z.End) && !z.HasRepeatedAncestor(new List<Coordinate>())).ToList();
                nextGenMoves.AddRange(vectors);
            }

            nextGenMoves = nextGenMoves.ToList();


            foreach (var nextMove in nextGenMoves)
            {
                if (gridz.GetAt(nextMove.EndX, nextMove.EndY).TrackType == NodeType.End)
                {
                    SuccessPaths.Add(nextMove);
                }
//                Console.SetCursorPosition(nextMove.EndX, nextMove.EndY);
//                Console.BackgroundColor = ConsoleColor.DarkGreen;
//                Console.WriteLine(gen);
            }
//            Console.ReadKey();

            ExtractNextGen(gridz, nextGenMoves, ++gen);

        }
    }
}