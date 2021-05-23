namespace TrainingCalculator.Exercises
{
    public class StaticExerciseInfo : BaseExerciseInfo
    {
        public int CaloriesPerSecond { get; private set; }

        public StaticExerciseInfo(int caloriesPerSecond)
        {
            CaloriesPerSecond = caloriesPerSecond;
        }
    }
}