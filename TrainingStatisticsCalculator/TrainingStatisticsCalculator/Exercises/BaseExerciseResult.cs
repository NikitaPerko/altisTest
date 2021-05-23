namespace TrainingCalculator.Exercises
{
    public abstract class BaseExerciseResult : ICalculatable, ITotalTimeCalculator, ICaloriesCalculator, ICompletionCalculator
    {
        public float PercentOfCompletion { get; protected set; }
        public float AverageAccuracy { get; protected set; }

        public virtual void Calculate()
        {
            CalculateAverageAccuracy();
            CalculateCompletion();
        }

        protected abstract void CalculateAverageAccuracy();

        public abstract int CalculateTotalTime();
        public abstract int CalculateCalories();
        public abstract void CalculateCompletion();
    }
}