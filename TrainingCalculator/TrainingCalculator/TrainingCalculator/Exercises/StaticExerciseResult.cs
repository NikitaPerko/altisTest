using System.Collections.Generic;
using System.Linq;
using TrainingCalculator.TrainingCalculator.Sets;

namespace TrainingCalculator.TrainingCalculator.Exercises
{
    public class StaticExerciseResult : BaseExerciseResult
    {
        public List<StaticSet> Sets { get; }
        public StaticExerciseInfo ExerciseInfo { get; }

        public StaticExerciseResult(List<StaticSet> sets, StaticExerciseInfo exerciseInfo)
        {
            Sets = sets;
            ExerciseInfo = exerciseInfo;
        }

        protected override void CalculateAverageAccuracy()
        {
            foreach (var set in Sets)
            {
                set.Calculate();
            }
        }

        public override int CalculateTotalTime()
        {
            return Sets.Sum(x => x.Time);
        }

        public override int CalculateCalories()
        {
            int totalTime = CalculateTotalTime();
            return totalTime * ExerciseInfo.CaloriesPerSecond;
        }
    }
}