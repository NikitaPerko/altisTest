using System.Collections.Generic;
using UnityEngine;

namespace CityGenerator
{
    public class CityGenerator
    {
        private float _x;
        private float _y;
        private int _objectsCount;

        private CityElementsAnalyzer _cityElementsAnalyzer;
        private CityElementsProcessor _cityElementsProcessor;
        private CityObjectsPlacer _cityObjectsPlacer;

        public CityGenerator()
        {
            _cityElementsProcessor = new CityElementsProcessor();
            _cityElementsAnalyzer = new CityElementsAnalyzer();
            _cityObjectsPlacer = new CityObjectsPlacer();
        }

        public void Generate(float x, float y, int n)
        {
            _x = x;
            _y = y;
            _objectsCount = n;
            var elements = _cityElementsProcessor.Process();
            _cityElementsAnalyzer.Analyze(elements);
            List<CityObject> objectsToPlace = new List<CityObject>(n);

            for (int i = 0; i < n; i++)
            {
                int randomIndex = Random.Range(0, elements.Count);
                var objectInfo = elements[randomIndex];
                var objectToPlace = Object.Instantiate(objectInfo.Prefab);
                objectsToPlace.Add(new CityObject {Object = objectToPlace, objectInfo = objectInfo});
            }

            var analyzis = _cityElementsAnalyzer.Analyze(elements);
            _cityObjectsPlacer.PlaceObjects(x, y, objectsToPlace, analyzis);
        }

        public void OnDrawGizmos()
        {
            Vector3 center = new Vector3(_x / 2, 0, _y / 2);
            Vector3 size = new Vector3(_x, 0, _y);
            Gizmos.DrawWireCube(center, size);
            _cityObjectsPlacer.DrawGizmos();
        }
    }
}