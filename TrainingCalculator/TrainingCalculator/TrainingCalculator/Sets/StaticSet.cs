namespace TrainingCalculator.TrainingCalculator.Sets
{
    public class StaticSet : BaseSet
    {

        public StaticSet(int time, float averageAccuracy)
            : base(time)
        {
            AverageAccuracy = averageAccuracy;
        }
    }
}