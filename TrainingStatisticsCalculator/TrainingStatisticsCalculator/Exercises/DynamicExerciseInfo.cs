namespace TrainingCalculator.Exercises
{
    public class DynamicExerciseInfo : BaseExerciseInfo
    {
        public int CaloriesPerRepetition { get; }

        public DynamicExerciseInfo(int caloriesPerRepetition)
        {
            CaloriesPerRepetition = caloriesPerRepetition;
        }
    }
}