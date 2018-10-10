using System.Collections.Generic;

namespace GrandPrixApp
{
    public class Individual
    {
        public IList<int> Gene { get; }
        public Move StartingMove { get; }
        public IList<Move> MoveList { get; }

        public Individual(IList<int> gene, Coordinate startingLocation) : this(gene, (Move) startingLocation)
        {
        }

        public Individual(IList<int> gene, Move startingMove)
        {
            Gene = gene;
            StartingMove = startingMove;
            MoveList = StartingMove * Gene;
        }
    }
}