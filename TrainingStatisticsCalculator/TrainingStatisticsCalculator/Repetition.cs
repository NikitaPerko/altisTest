using System;

namespace TrainingCalculator
{
    public class Repetition
    {
        public readonly float AverageAccuracy;

        public Repetition(float averageAccuracy)
        {
            if (averageAccuracy > 1 || averageAccuracy < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(averageAccuracy), "Accuracy must be in the range from 0 to 1");
            }

            AverageAccuracy = averageAccuracy;
        }
    }
}