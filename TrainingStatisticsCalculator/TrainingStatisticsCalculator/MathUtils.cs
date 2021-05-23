namespace TrainingCalculator
{
    public static class MathUtils
    {
        public static float Clamp01(float value)
        {
            if (value < 0)
            {
                value = 0;
            }

            if (value > 1)
            {
                value = 1;
            }

            return value;
        }
    }
}