using System.Collections.Generic;

namespace TrainingCalculator.Sets
{
    public class DynamicSet : BaseSet
    {
        public readonly List<Repetition> Repetitions;

        public DynamicSet(int time, List<Repetition> repetitions)
            : base(time)
        {
            Repetitions = repetitions;
        }

        protected override void CalculateAverageAccuracy()
        {
            foreach (var repetition in Repetitions)
            {
                AverageAccuracy += repetition.AverageAccuracy;
            }

            AverageAccuracy /= Repetitions.Count;
        }
    }
}