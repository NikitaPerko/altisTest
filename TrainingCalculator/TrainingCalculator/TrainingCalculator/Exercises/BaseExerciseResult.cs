using System;

namespace TrainingCalculator.TrainingCalculator.Exercises
{
    public abstract class BaseExerciseResult : ICalculatable, ITotalTimeCalculator, ICaloriesCalculator
    {
        public float PercentOfCompletion { get; protected set; }
        public float AverageAccuracy { get; protected set; }

        public virtual void Calculate()
        {
            CalculateAverageAccuracy();
        }

        protected abstract void CalculateAverageAccuracy();

        public abstract int CalculateTotalTime();
        public abstract int CalculateCalories();
    }
}