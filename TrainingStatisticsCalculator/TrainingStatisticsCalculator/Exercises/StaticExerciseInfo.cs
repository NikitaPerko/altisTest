using System;

namespace TrainingCalculator.Exercises
{
    public class StaticExerciseInfo : BaseExerciseInfo
    {
        public int CaloriesPerSecond { get; }
        public int TargetSeconds { get; }

        public StaticExerciseInfo(int caloriesPerSecond, int targetSeconds)
        {
            CaloriesPerSecond = caloriesPerSecond;
            TargetSeconds = targetSeconds;

            if (targetSeconds <= 0)
            {
                throw new ArgumentException("Cannot be less or equal 0 ", nameof(targetSeconds));
            }
        }
    }
}