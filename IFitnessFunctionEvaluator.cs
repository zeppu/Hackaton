namespace GrandPrixApp
{
    public interface IFitnessFunctionEvaluator
    {
        IFitnessReport<Individual> GetFitness(Individual individual);
    }
}