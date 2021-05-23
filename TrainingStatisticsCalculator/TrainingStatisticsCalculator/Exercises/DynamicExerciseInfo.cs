using System;

namespace TrainingCalculator.Exercises
{
    public class DynamicExerciseInfo : BaseExerciseInfo
    {
        public int CaloriesPerRepetition { get; }
        public int TargetRepetitionsCount { get; }

        public DynamicExerciseInfo(int caloriesPerRepetition, int targetRepetitionsCount)
        {
            CaloriesPerRepetition = caloriesPerRepetition;
            TargetRepetitionsCount = targetRepetitionsCount;

            if (targetRepetitionsCount <= 0)
            {
                throw new ArgumentException("Cannot be less or equal 0 ", nameof(targetRepetitionsCount));
            }
        }
    }
}