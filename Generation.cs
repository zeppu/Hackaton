using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GrandPrixApp
{
    public class Generation
    {
        public IReadOnlyList<Individual> Individuals { get; }

        public Generation(IList<Individual> individuals)
        {
            Individuals = new ReadOnlyCollection<Individual>(individuals);
        }

        public void EvaluateAgainstGrid(NodeGrid grid)
        {
        }
    }
}