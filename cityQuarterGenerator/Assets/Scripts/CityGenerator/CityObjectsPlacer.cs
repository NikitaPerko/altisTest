using System.Collections.Generic;
using UnityEngine;

namespace CityGenerator
{
    public class CityObjectsPlacer
    {
        private BoundsOctree<CityElement> _octree;
        private Vector3 minBoundsSize;

        public void PlaceObjects(float x, float y, List<CityObject> objectsToPlace, AnalyzisResult analyzisResult)
        {
            objectsToPlace.Sort((a, b) => a.objectInfo.BoundingBoxVolume - b.objectInfo.BoundingBoxVolume < 0 ? -1 : 1);

            minBoundsSize = analyzisResult.minBoundsSize;

            _octree = new BoundsOctree<CityElement>(new Vector3(x, analyzisResult.maxYSize, y),
                new Vector3(x / 2, analyzisResult.maxYSize / 2, y / 2), minBoundsSize, 1f);

            foreach (var objectToPlace in objectsToPlace)
            {
                var bounds = objectToPlace.MeshRenderer.bounds;

                if (!_octree.IsColliding(bounds))
                {
                    _octree.Add(objectToPlace.objectInfo, bounds);
                }
                else
                {
                    objectToPlace.Object.transform.position = Vector3.up * 1000;
                }
            }
        }

        public void DrawGizmos()
        {
            _octree?.DrawAllBounds();
            _octree?.DrawAllObjects();
        }
    }
}