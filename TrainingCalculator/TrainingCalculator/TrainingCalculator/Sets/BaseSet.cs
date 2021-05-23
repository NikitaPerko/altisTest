namespace TrainingCalculator.TrainingCalculator.Sets
{
    public abstract class BaseSet : ICalculatable, ITotalTimeCalculator
    {
        public int Time { get; }
        public float AverageAccuracy { get; protected set; }

        protected BaseSet(int time)
        {
            Time = time;
        }

        public void Calculate()
        {
            CalculateAverageAccuracy();
        }

        protected virtual void CalculateAverageAccuracy()
        {
            
        }

        public int CalculateTotalTime()
        {
            return Time;
        }
    }
}