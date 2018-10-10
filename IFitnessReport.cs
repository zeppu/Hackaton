namespace GrandPrixApp
{
    public interface IFitnessReport<out T>
    {
        T Individual { get; }
        float Fitness { get; }
    }
}