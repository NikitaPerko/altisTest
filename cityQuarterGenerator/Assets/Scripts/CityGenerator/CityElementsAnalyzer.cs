using System.Collections.Generic;
using UnityEngine;

namespace CityGenerator
{
    public class CityElementsAnalyzer
    {
        private List<CityElement> _elements;

        public AnalyzisResult Analyze(List<CityElement> elements)
        {
            AnalyzisResult analyzisResult = new AnalyzisResult();
            _elements = elements;

            Vector3 minBoundsSize = Vector3.one * float.MaxValue;
            float maxYValue = float.MinValue;

            foreach (var element in elements)
            {
                Vector3 size = element.Mesh.bounds.size;

                if (minBoundsSize.x > size.x)
                {
                    minBoundsSize.x = size.x;
                }

                if (minBoundsSize.y > size.y)
                {
                    minBoundsSize.y = size.y;
                }

                if (minBoundsSize.z > size.z)
                {
                    minBoundsSize.z = size.z;
                }

                if (maxYValue < size.y)
                {
                    maxYValue = size.y;
                }
            }

            analyzisResult.minBoundsSize = minBoundsSize;
            analyzisResult.maxYSize = maxYValue;
            return analyzisResult;
        }
    }
}