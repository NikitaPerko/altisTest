using System.Collections.Generic;
using System.Linq;
using TrainingCalculator.TrainingCalculator.Sets;

namespace TrainingCalculator.TrainingCalculator.Exercises
{
    public class DynamicExerciseResult : BaseExerciseResult
    {
        public List<DynamicSet> Sets { get; }
        public DynamicExerciseInfo ExerciseInfo { get;}

        public DynamicExerciseResult(List<DynamicSet> sets, DynamicExerciseInfo exerciseInfo)
        {
            Sets = sets;
            ExerciseInfo = exerciseInfo;
        }

        protected override void CalculateAverageAccuracy()
        {
            foreach (var set in Sets)
            {
                set.Calculate();
                AverageAccuracy += set.AverageAccuracy;
            }

            AverageAccuracy /= Sets.Count;
        }

        public override int CalculateTotalTime()
        {
            return Sets.Sum(x => x.CalculateTotalTime());
        }

        public override int CalculateCalories()
        {
            int repetitionsCount = Sets.Sum(x => x.Repetitions.Count);
            return repetitionsCount * ExerciseInfo.CaloriesPerRepetition;
        }
    }
}