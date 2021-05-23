using System;

namespace TrainingCalculator.Sets
{
    public class StaticSet : BaseSet
    {
        public StaticSet(int time, float averageAccuracy)
            : base(time)
        {
            if (averageAccuracy > 1 || averageAccuracy < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(averageAccuracy), "Accuracy must be in the range from 0 to 1");
            }

            AverageAccuracy = averageAccuracy;
        }
    }
}