using System;
using System.Collections.Generic;
using NUnit.Framework;
using TrainingCalculator;
using TrainingCalculator.Exercises;
using TrainingCalculator.Sets;

namespace TrainingStatisticsCalculatorTests
{
    [TestFixture]
    public class TestTrainingStatisticsCalculator
    {
        private Training _training;
        private const float EPS = 00001f;

        [SetUp]
        public void Setup()
        {
            var plankInfo = new StaticExerciseInfo(3, 50);
            var jumpingInfo = new DynamicExerciseInfo(1, 2);
            var squatsInfo = new DynamicExerciseInfo(2, 3);

            _training = new Training(new List<BaseExerciseResult>
            {
                new DynamicExerciseResult(new List<DynamicSet>
                {
                    new DynamicSet(120,
                        new List<Repetition> {new Repetition(0.5f), new Repetition(0.3f), new Repetition(0.8f)})
                }, jumpingInfo),
                new DynamicExerciseResult(new List<DynamicSet>
                {
                    new DynamicSet(90,
                        new List<Repetition> {new Repetition(0.8f), new Repetition(0.9f), new Repetition(0.8f)}),
                    new DynamicSet(60, new List<Repetition> {new Repetition(0.5f), new Repetition(0.7f)})
                }, squatsInfo),
                new StaticExerciseResult(new List<StaticSet> {new StaticSet(20, 0.5f), new StaticSet(10, 0.7f)}, plankInfo)
            });
        }

        [Test]
        public void TestTotalTimeCalculation()
        {
            var calculator = new TrainingStatisticsCalculator();
            var result = calculator.CalculateResult(_training);

            Assert.IsTrue(Math.Abs(300f - result.TotalTime) <= EPS);
        }

        [Test]
        public void TestTotalCaloriesCalculation()
        {
            var calculator = new TrainingStatisticsCalculator();
            var result = calculator.CalculateResult(_training);

            Assert.AreEqual(103, result.TotalCaloriesCount);
        }

        [Test]
        public void TestAverageAccuracyCalculating()
        {
            var calculator = new TrainingStatisticsCalculator();
            calculator.CalculateResult(_training);

            Assert.IsTrue(Math.Abs(0.5333f - _training.ExerciseResults[0].AverageAccuracy) < EPS);
        }

        [Test]
        public void TestCompletionCalculating()
        {
            var calculator = new TrainingStatisticsCalculator();
            calculator.CalculateResult(_training);
            Assert.IsTrue(Math.Abs(1f - _training.ExerciseResults[1].PercentOfCompletion) < EPS);
        }
    }
}