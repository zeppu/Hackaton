using System;
using System.Collections.Generic;
using System.Linq;

namespace GrandPrixApp
{
    public class FitnessFunctionEvaluator : IFitnessFunctionEvaluator
    {
        private readonly NodeGrid _grid;

        public FitnessFunctionEvaluator(NodeGrid grid)
        {
            _grid = grid;
        }

        public IFitnessReport<Individual> GetFitness(Individual individual)
        {
            var validMoves = 0;

            foreach (var item in individual.MoveList)
            {
                if (_grid.IsValidNode(item.End))
                {
                    validMoves++;
                }
                else
                {
                    break;
                }
            }

            if (validMoves == 0)
            {
                return IndividualFitness.ForDeadIndvidual(individual);
            }

            var lastValidMode = individual.MoveList[validMoves - 1];

            var closestWinningNode = FindClosestWinningNode(lastValidMode.End);
            if (closestWinningNode.Equals(default))
            {
                return new IndividualFitness(individual, validMoves, 1, 100);
            }

            return new IndividualFitness(individual,
                closestWinningNode.node.PathLength,
                closestWinningNode.distance,
                validMoves);
        }

        private (Node node, int distance) FindClosestWinningNode(Coordinate coordinate, int maxDistance = 20)
        {
            var node = _grid.GetAt(coordinate);

            if (node.IsWinner)
            {
                return (node, 0);
            }

            for (var i = 1; i < maxDistance; i++)
            {
                var winner =
                    GetNeighbours(coordinate, i).FirstOrDefault(m => _grid.IsValidNode(m) && _grid.GetAt(m).IsWinner);
                if (winner != null)
                {
                    return (_grid.GetAt(winner), i);
                }
            }

            return default;
        }

        private static IEnumerable<Coordinate> GetNeighbours(Coordinate point, int distance)
        {
            var result = new List<Coordinate>
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

            return result.OrderBy(m => Math.Abs(point.X - m.X) + Math.Abs(point.Y - m.Y));
        }
    }
}