﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GrandPrixApp
{
    class Program
    {
        public static IList<Vector> SuccessPaths = new List<Vector>();

        static void Main(string[] args)
        {


            var grid =
                //"000000000000000000000000000000000000000000000000000000000000000000000000000000000000002111111111111111111111111111111111111111111111111111111111111111111111111111111111111300000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
                "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001111110000000000000000000000000000000000000000000000000000000000000000000000000111111110000000000000000000000000000000000000000000000000000000000000000000000011111111100000000000000000000000000000000000000000000000000000000000000000000001111111111000000000000000000000000000000000000000000000000000000000000000000000011111111111000000000000000000000000000000000000000000000000000000000000000000001111111111110000000000000000000000000000000000000000000000000000000000000000000011110011111100000000000000000000000000000000000000000000000000000000000000000000111100011111000000000011111100000000000000000000000000000000000000000000000000001111000111110000000001111111110000000000000000000000000000000000000000000000000111110001111100000001111111111110000000000000000000000000000000000000000000000001111100011111000001111111111111110000000000000000000000000000000000000000000000011111000111111101111111111111111111100000000000000000000000000000000000000000000111110000111111111111100000000011111111100000000000000000000000000000000000000001111100001111111111110000000000011111111111100000000000000000000000000000000000011111000001111111110000000000000001111111111111111000000000000000000000000000000111110000001111110000000000000000000111111111111111111111100000000000000000000001111110000000000000000000000000000000001111111111111111111111100000000000000000011111100000000000000000000000000000000000000011111111111111111111000000000000000111111000000000000000000000000000000000000000000000000011111111111100000000000001111111000000000000000000000000000000000000000000000000000001111111100000000000011111110000000000000000000000000000000000000000000000000000000111111100000000000111111100000000000000000000000000000000000000000000000000000000011111000000000001111111000000000000000000000000000000000000000000000000000000000011111000000000001111110000000000000000000000000000000000000000000000000000000000111110000000000011111100000000000000000000000000000000000000000000000000000000000111100000000000111111000000000000000000000000000000000000000000000000000000000011110000000000001111110000000000000000000000000000000000000000000000000000000000111100000000000011111100000000000000000000000000000000000000000000000000000000011111000000000000011111000000000000000000000000000000000000000000000000000000011111100000000000000111110000000000000000000000000000000000000000000000000000011111110000000000000001111100000000000000000000000000000000000000000000000000001111111000000000000000011111100000000000000000000000000000000000000000000000001111111100000000000000000111111000000000000000000000000000000000000000000000000111111100000000000000000001111110000000000000000000000000000000000000000000000011111110000000000000000000001111110000000000000000000000000000000000000000000001111111100000000000000000000011111111000000000000000000000000000000000000000000011111110000000000000000000000011111111100000000000000000000000000000000000000000111111000000000000000000000000111111111110000000000000000000000000000000000000001111110000000000000000000000000111111111110000000000000000000000000000000000000011111100000000000000000000000000111111111110000000000000000000000000000000000000111110000000000000000000000000000011111111100000000000000000000000000000000000011111100000000000000000000000000000000111111100000000000001110000000000000000000111111000000000000000000000000000000001111111000000000001111111100000000000000011111110000000000000000000000000000000001111111000000001111111111111000200000031111111100000000000000000000000000000000001111110000000111111111111111112000000311111110000000000000000000000000000000000001111110000111111000000111111120000003111111100000000000000000000000000000000000001111111111111000000000011111200000031111111000000000000000000000000000000000000001111111111100000000000000112000000311111100000000000000000000000000000000000000011111111111000000000000000000000003111110000000000000000000000000000000000000000011111111100000000000000000000000031100000000000000000000000000000000000000000000001111100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            // "000000000000000000000000000000000000000021110000000000000000000000000000000000002111111000000000000000000000000000000000211111111000000000000000000000000000000021111111110000000000000000000000000000002111111111100000000000000000000000000000200000111110000000000000000000000000000000000001111100000000000000011111000000000000000011111000000000001111111111100000000000000111100000000001111111111111110000000000011110000000001111111111111111130000000001111100000001111111111111111113000000000111110000000111111111111111111300000000001111000000111111111111111111130000000000111100000011111111111111111113000000000011110000011111110000000000000000000000001111000001111100000000000000000000000000111100000111110000000000000000000000000011110000011111000000000000000000000000001111000001111100000000000000000000000000111110001111110000000000000000000000000011111000111111000000000000000000000000001111100011111000000000000000000000000000011111111111100000000000000000000000000000111111111110000000000000000000000000000001111111110000000000000000000000000000000001111100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            const int COLS = 80;
            const int ROWS = 60;

            var nodelist = NodeGenerator.GenerateNodes(grid, COLS, ROWS);

            var nodeGrid = new NodeGrid(nodelist, COLS, ROWS);
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
                Console.Write(" ");
            }

            Console.BackgroundColor = ConsoleColor.Black;

            var startingNodes = nodeGrid.Nodes.Where(m => m.TrackType == NodeType.Start).ToList();
            startingNodes.ForEach(m => m.PathLength = 0);

            List<Node> neighbours = startingNodes;

            do
            {
                neighbours = neighbours.SelectMany(m =>
                {
                    var nodes = m.GetNeighbours(nodeGrid);
                    return nodes.UpdateIfClosest(m);
                }).ToList();

//                DrawCoordinates(neighbours.Select(m => m.Position).ToList(), ConsoleColor.Blue);
//                Thread.Sleep(10);
//                Console.ReadLine();
            } while (neighbours.All(m => m.TrackType != NodeType.End));

            var winner = neighbours.First(m => m.TrackType == NodeType.End);

            var prev = winner;
            var winnerPath = new List<Node>();
            while (prev != null)
            {
                winnerPath.Add(prev);
                prev = prev.PreviousNode;
            }

            winnerPath.Reverse();
            winnerPath.ForEach(m => m.IsWinner = true);

            DrawCoordinates(winnerPath.Select(m => m.Position), ConsoleColor.Magenta);

//            var startingPoints = nodelist.Where(m => m.TrackType == NodeType.Start)
//                .Select(m => new Vector(m.Position, m.Position, null)).ToList();
//
//            ExtractNextGen(nodeGrid, startingPoints, 0);

            Console.SetCursorPosition(0, 60);
            Console.WriteLine(winner.PathLength);


            string input;

            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    continue;

                var points = input.Split(",", StringSplitOptions.RemoveEmptyEntries);
                Coordinate c = (int.Parse(points[0]), int.Parse(points[1]));
                DrawCoordinate(c, ConsoleColor.Cyan);
                var closestWinner = nodeGrid.FindClosestWinner(c);
                DrawCoordinate(closestWinner.node.Position, ConsoleColor.DarkGreen, closestWinner.distance.ToString());
            } while (!string.IsNullOrWhiteSpace(input));
        }

        private static void DrawCoordinates(IEnumerable<Coordinate> points, ConsoleColor color, string text = " ")
        {
            Console.BackgroundColor = color;
            foreach (var point in points)
            {
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write(text);
            }
        }

        private static void DrawCoordinate(Coordinate point, ConsoleColor color, string text = " ")
        {
            Console.BackgroundColor = color;
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write(text);
        }


        private static void ExtractNextGen(NodeGrid gridz, IList<Vector> moves, int gen)
        {
            var nextGenMoves = new List<Vector>();

            foreach (var nextMove in moves)
            {
                var vectors = nextMove.GenerateAllNextMoves()
                    .Where(z => gridz.IsValidNode(z.End) && !z.HasRepeatedAncestor(new List<Coordinate>())).ToList();
                nextGenMoves.AddRange(vectors);
            }

            nextGenMoves = nextGenMoves.ToList();
            Console.SetCursorPosition(85, 0);
            Console.WriteLine($"Move: {gen} [{nextGenMoves.Count}]");

            nextGenMoves = nextGenMoves.OrderBy(a => Guid.NewGuid()).Take(500).ToList();
            foreach (var nextGenMove in nextGenMoves)
            {
                Console.SetCursorPosition(nextGenMove.EndX, nextGenMove.EndY);
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.Write(" ");
            }

//            Console.ReadLine();

            Parallel.ForEach(moves, nextMove =>
            {
                if (gridz.GetAt(nextMove.EndX, nextMove.EndY).TrackType == NodeType.End)
                {
                    SuccessPaths.Add(nextMove);
                    var parent = nextMove.Parent;
                    do
                    {
                        Console.SetCursorPosition(parent.EndX, parent.EndY);
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.Write(" ");
                        Thread.Sleep(100);
                        parent = parent.Parent;

                    } while (parent != null);
                }
            });

            ExtractNextGen(gridz, nextGenMoves, ++gen);


        }
    }
}