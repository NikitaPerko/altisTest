using System.Collections.Generic;
using System.Linq;
using TrainingCalculator.Sets;

namespace TrainingCalculator.Exercises
{
    public class StaticExerciseResult : BaseExerciseResult
    {
        private List<StaticSet> Sets { get; }
        private StaticExerciseInfo ExerciseInfo { get; }

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

        public override void CalculateCompletion()
        {
            PercentOfCompletion = MathUtils.Clamp01(CalculateTotalTime() / (float) ExerciseInfo.TargetSeconds);
        }
    }
}