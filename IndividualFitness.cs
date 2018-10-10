namespace GrandPrixApp
{
    public class IndividualFitness : IFitnessReport<Individual>
    {
        public Individual Individual { get; }
        public int DistanceFromStart { get; }
        public int DistanceFromWinningLine { get; }
        public int MoveCount { get; }
        public float Fitness => DistanceFromStart * (100 - DistanceFromWinningLine);

        /// <inheritdoc />
        public IndividualFitness(
            Individual individual,
            int distanceFromStart,
            int distanceFromWinningLine,
            int moveCount)
        {
            Individual = individual;

            DistanceFromStart = distanceFromStart;
            DistanceFromWinningLine = distanceFromWinningLine;
            MoveCount = moveCount;
        }

        public static IndividualFitness ForDeadIndvidual(Individual individual)
        {
            return new IndividualFitness(individual, 0, 0, 0);
        }
    }
}