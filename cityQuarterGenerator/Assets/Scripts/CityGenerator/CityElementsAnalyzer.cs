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

            float minEdgeSize = float.MaxValue;
            float maxYValue = float.MinValue;

            foreach (var element in elements)
            {
                Vector3 size = element.Mesh.bounds.size;

                if (minEdgeSize > size.x)
                {
                    minEdgeSize = size.x;
                }

                if (minEdgeSize > size.z)
                {
                    minEdgeSize = size.z;
                }

                if (maxYValue < size.y)
                {
                    maxYValue = size.y;
                }
            }

            analyzisResult.cellSize = minEdgeSize;
            analyzisResult.maxYSize = maxYValue;
            return analyzisResult;
        }
    }
}