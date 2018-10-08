using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GrandPrixApp
{
    internal class Program
	{
		public static IList<Vector> SuccessPaths = new List<Vector>();

		private static void Main(string[] args)
        {

            //			var x = new Coordinate(25, 25);
            //			DrawCoordinate(x, ConsoleColor.DarkRed, "0");
            //			Console.ReadLine();
            //
            //			var movement = new Movement(0, 0);
            //			var i = 1;
            //			
            ////		    var points = new List<Coordinate> {x};
            //
            //			var move = x * movement;
            //			while (true)
            //			{
            //				move = move.GetNextMoves()
            //					.OrderBy(m => Guid.NewGuid())
            //					.First();
            //
            ////                moves = KnownMovements.Values.SelectMany(m => moves.Select(n=> n.NextMove(m))).Where(m => m != Movement.Empty).Distinct().ToList();
            ////		        points = points.SelectMany(m => moves.Select(n => m * n)).Distinct().OrderBy(m => Guid.NewGuid()).Take(1).ToList();
            //			    DrawCoordinate(move.End, ConsoleColor.Cyan, (i % 10).ToString());
            //				i++;
            //
            //				Console.ReadLine();
            //			}


            var grid =
                "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001111110000000000000000000000000000000000000000000000000000000000000000000000000111111110000000000000000000000000000000000000000000000000000000000000000000000011111111100000000000000000000000000000000000000000000000000000000000000000000001111111111000000000000000000000000000000000000000000000000000000000000000000000011111111111000000000000000000000000000000000000000000000000000000000000000000001111111111110000000000000000000000000000000000000000000000000000000000000000000011110011111100000000000000000000000000000000000000000000000000000000000000000000111100011111000000000011111100000000000000000000000000000000000000000000000000001111000111110000000001111111110000000000000000000000000000000000000000000000000111110001111100000001111111111110000000000000000000000000000000000000000000000001111100011111000001111111111111110000000000000000000000000000000000000000000000011111000111111101111111111111111111100000000000000000000000000000000000000000000111110000111111111111100000000011111111100000000000000000000000000000000000000001111100001111111111110000000000011111111111100000000000000000000000000000000000011111000001111111110000000000000001111111111111111000000000000000000000000000000111110000001111110000000000000000000111111111111111111111100000000000000000000001111110000000000000000000000000000000001111111111111111111111100000000000000000011111100000000000000000000000000000000000000011111111111111111111000000000000000111111000000000000000000000000000000000000000000000000011111111111100000000000001111111000000000000000000000000000000000000000000000000000001111111100000000000011111110000000000000000000000000000000000000000000000000000000111111100000000000111111100000000000000000000000000000000000000000000000000000000011111000000000001111111000000000000000000000000000000000000000000000000000000000011111000000000001111110000000000000000000000000000000000000000000000000000000000111110000000000011111100000000000000000000000000000000000000000000000000000000000111100000000000111111000000000000000000000000000000000000000000000000000000000011110000000000001111110000000000000000000000000000000000000000000000000000000000111100000000000011111100000000000000000000000000000000000000000000000000000000011111000000000000011111000000000000000000000000000000000000000000000000000000011111100000000000000111110000000000000000000000000000000000000000000000000000011111110000000000000001111100000000000000000000000000000000000000000000000000001111111000000000000000011111100000000000000000000000000000000000000000000000001111111100000000000000000111111000000000000000000000000000000000000000000000000111111100000000000000000001111110000000000000000000000000000000000000000000000011111110000000000000000000001111110000000000000000000000000000000000000000000001111111100000000000000000000011111111000000000000000000000000000000000000000000011111110000000000000000000000011111111100000000000000000000000000000000000000000111111000000000000000000000000111111111110000000000000000000000000000000000000001111110000000000000000000000000111111111110000000000000000000000000000000000000011111100000000000000000000000000111111111110000000000000000000000000000000000000111110000000000000000000000000000011111111100000000000000000000000000000000000011111100000000000000000000000000000000111111100000000000001110000000000000000000111111000000000000000000000000000000001111111000000000001111111100000000000000011111110000000000000000000000000000000001111111000000001111111111111000200000031111111100000000000000000000000000000000001111110000000111111111111111112000000311111110000000000000000000000000000000000001111110000111111000000111111120000003111111100000000000000000000000000000000000001111111111111000000000011111200000031111111000000000000000000000000000000000000001111111111100000000000000112000000311111100000000000000000000000000000000000000011111111111000000000000000000000003111110000000000000000000000000000000000000000011111111100000000000000000000000031100000000000000000000000000000000000000000000001111100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            // "000000000000000000000000000000000000000021110000000000000000000000000000000000002111111000000000000000000000000000000000211111111000000000000000000000000000000021111111110000000000000000000000000000002111111111100000000000000000000000000000200000111110000000000000000000000000000000000001111100000000000000011111000000000000000011111000000000001111111111100000000000000111100000000001111111111111110000000000011110000000001111111111111111130000000001111100000001111111111111111113000000000111110000000111111111111111111300000000001111000000111111111111111111130000000000111100000011111111111111111113000000000011110000011111110000000000000000000000001111000001111100000000000000000000000000111100000111110000000000000000000000000011110000011111000000000000000000000000001111000001111100000000000000000000000000111110001111110000000000000000000000000011111000111111000000000000000000000000001111100011111000000000000000000000000000011111111111100000000000000000000000000000111111111110000000000000000000000000000001111111110000000000000000000000000000000001111100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            //"000000000000000000000000000000000000000000000000000000000000222222222222222222222222222222222222222222222222222222222222111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111333333333333333333333333333333333333333333333333333333333333000000000000000000000000000000000000000000000000000000000000";
            const int COLS = 80;
            const int ROWS = 60;

            var nodelist = NodeGenerator.GenerateNodes(grid, COLS, ROWS);

            var nodeGrid = new NodeGrid(nodelist, COLS, ROWS);
            DrawGrid(nodelist);

            Console.BackgroundColor = ConsoleColor.Black;

            var startingNodes = nodeGrid.Nodes.Where(m => m.TrackType == NodeType.Start).ToList();
            startingNodes.ForEach(m => m.PathLength = 0);

            var neighbours = startingNodes;

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

            //
            //            string input;
            //
            //            do
            //            {
            //                input = Console.ReadLine();
            //                if (string.IsNullOrWhiteSpace(input))
            //                    continue;
            //
            //                var points = input.Split(",", StringSplitOptions.RemoveEmptyEntries);
            //                Coordinate c = (int.Parse(points[0]), int.Parse(points[1]));
            //                DrawCoordinate(c, ConsoleColor.Cyan);
            //                var closestWinner = nodeGrid.FindClosestWinner(c);
            //                DrawCoordinate(closestWinner.node.Position, ConsoleColor.DarkGreen, closestWinner.distance.ToString());
            //            } while (!string.IsNullOrWhiteSpace(input));




            //			var gen = CreateGeneration(nodeGrid, startingNodes);
            //
            //			var valueTuples = gen.Select(m => nodeGrid.FindClosestWinner(m)).OrderByDescending(m => m.Value).Take(5)
            //				.ToList();
            //			DrawCoordinates(valueTuples.Select(m => m.Point.End), ConsoleColor.DarkCyan, delay: 100);
            //
            //			IList<Vector> generation;
            //
            //			do
            //			{
            //				generation = CreateGeneration(nodeGrid, valueTuples.Select(m => m.Point));
            //
            //				valueTuples = generation.Select(m =>
            //					nodeGrid.FindClosestWinner(m))
            //					.Where(m => m != null)
            //					.OrderByDescending(m => m.Value)
            //					.Take(5)
            //					.ToList();
            //				DrawCoordinates(valueTuples.Select(m => m.Point.End), ConsoleColor.DarkYellow, delay: 20);
            //			} while (generation.All(m => nodeGrid.GetAt(m.End).TrackType != NodeType.End));
            //
            //			var winningPath = generation.FirstOrDefault(m => nodeGrid.GetAt(m.End).TrackType != NodeType.End);
            //
            //			var item = winningPath;
            //			var items = new List<Vector>();
            //			do
            //			{
            //				items.Add(item);
            //				item = item.Parent;
            //
            //			} while (item != null);
            //
            //			Console.SetCursorPosition(0, 60);
            //			Console.WriteLine(items.Count);
            //			Console.WriteLine(winningPath.MoveCount);
            //			DrawCoordinates(items.Select(m => m.End).Reverse(), ConsoleColor.DarkGreen, delay: 100);

            Movement startingMovement = (0, 0);

            var moveLists = new List<IList<Move>>();




            for (var i = 0; i < 50; i++)
            {
                var startingPoint = startingNodes.Random().Position;
                var startingMove = new Move()
                {
                    End = startingPoint,
                    Movement = startingMovement
                };

                var moveList = new List<Move> { startingMove };
                var nextMove = startingMove;

                for (var j = 0; j < 9; j++)
                {
                    nextMove = nextMove.GetNextMoves().Where(m => nodeGrid.IsValidNode(m.End)).Random();
                    if (nextMove == null)
                        break;

                    moveList.Add(nextMove);
                }

                moveLists.Add(moveList);
            }

            var results = moveLists.Select(m => nodeGrid.FindClosestWinner(m)).OrderByDescending(m => m.Value).ToList();

            foreach (var moveList in results)
            {
                var last = moveList.Movelist.Last();
                DrawCoordinate(last.End, ConsoleColor.Blue, moveList.Movelist.Count.ToString());
                Thread.Sleep(200);
            }

            var fittest = results.Take(10);
            foreach (var moveList in fittest)
            {
                var last = moveList.Movelist.Last();
                DrawCoordinate(last.End, ConsoleColor.Red, moveList.Movelist.Count.ToString());
                Thread.Sleep(200);
            }


            Console.ReadLine();
        }

        private static void DrawGrid(IList<Node> nodelist)
        {
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
                        break;
                        ;
                    case NodeType.End:
                        Console.BackgroundColor = ConsoleColor.Green;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Console.Write(" ");
            }
        }

        private static List<Vector> CreateGeneration(NodeGrid nodeGrid, List<Node> startingNodes)
		{
			const int GEN_SIZE = 50;
			const int STEPS = 5;

			var gen = new List<Vector>();

			for (var i = 0; i < GEN_SIZE; i++)
			{
				var start = startingNodes.Random();
				var vector = new Vector(start.Position, start.Position, null);
				for (var j = 0; j < STEPS; j++)
				{
					vector = vector
						.GenerateAllNextMoves()
						.Where(m => nodeGrid.IsValidNode(m.End))
						?.Random();

					if (vector == null)
					{
						break;
					}
				}

				if (vector != null)
				{
					gen.Add(vector);
				}
			}

			return gen;
		}

		private static IList<Vector> CreateGeneration(NodeGrid nodeGrid, IEnumerable<Vector> startingVectors)
		{
			const int GEN_SIZE = 50;
			const int STEPS = 5;

			var gen = new List<Vector>();

			for (var i = 0; i < GEN_SIZE; i++)
			{
				var vector = startingVectors.Random();
				for (var j = 0; j < STEPS; j++)
				{
					vector = vector
						.GenerateAllNextMoves()
						.Where(m => nodeGrid.IsValidNode(m.End))
						?.Random();

					if (vector == null)
					{
						break;
					}
				}

				if (vector != null)
				{
					gen.Add(vector);
				}
			}

			return gen;
		}


		private static void DrawCoordinates(IEnumerable<Coordinate> points, ConsoleColor color, string text = " ",
			int delay = 0)
		{
			Console.BackgroundColor = color;
			foreach (var point in points)
			{
				Console.SetCursorPosition(point.X, point.Y);
				Console.Write(text);
				if (delay > 0)
				{
					Thread.Sleep(delay);
				}
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