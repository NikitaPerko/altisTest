using System.Collections.Generic;
using System.Linq;
using TrainingCalculator.Exercises;

namespace TrainingCalculator
{
    public class Training : ICalculatable, ITotalTimeCalculator, ICaloriesCalculator
    {
        public readonly List<BaseExerciseResult> ExerciseResults;

        public Training(List<BaseExerciseResult> exerciseResults)
        {
            ExerciseResults = exerciseResults;
        }

        public void Calculate()
        {
            foreach (var exerciseResult in ExerciseResults)
            {
                exerciseResult.Calculate();
            }
        }

        public int CalculateTotalTime()
        {
            return ExerciseResults.Sum(x => x.CalculateTotalTime());
        }

        public int CalculateCalories()
        {
            return ExerciseResults.Sum(x => x.CalculateCalories());
        }
    }
}