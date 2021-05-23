namespace TrainingCalculator.TrainingCalculator
{
    public class TrainingCalculator
    {
        public TrainingResult CalculateResult(Training training)
        {
            var trainingResult = new TrainingResult();

            training.Calculate();

            trainingResult.TotalTime = training.CalculateTotalTime();
            trainingResult.TotalCaloriesCount = training.CalculateCalories();
            return trainingResult;
        }
    }
}