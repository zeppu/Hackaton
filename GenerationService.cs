using System;
using System.Collections.Generic;

namespace GrandPrixApp
{
    public class GenerationService
    {
        private readonly NodeGrid _grid;
        private readonly Random _random;

        public GenerationService(Random random, NodeGrid grid)
        {
            _random = random;
            _grid = grid;
        }

        public Generation Generate(int individualCount, int moveCount)
        {
            var result = new List<Individual>();

            for (var i = 0; i < individualCount; i++)
            {
                var gene = new List<int>();

                for (var j = 0; j < moveCount; j++)
                {
                    gene.Add(_random.Next(0, 8));
                }

                result.Add(new Individual(gene, _grid.StartingLocations.Random().Position));
            }

            return new Generation(result);
        }
    }
}