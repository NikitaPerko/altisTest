using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CityGenerator
{
    public class CityElementsProcessor
    {
        private List<GameObject> cityElementsPrefabs;

        public CityElementsProcessor()
        {
            cityElementsPrefabs = Resources.LoadAll<GameObject>("CityObjects").ToList();
            //  cityElementsPrefabs.RemoveRange(1,cityElementsPrefabs.Count-1);
        }

        public List<CityElement> Process()
        {
            var cityElements = new List<CityElement>();

            foreach (var cityElementPrefab in cityElementsPrefabs)
            {
                cityElementPrefab.transform.position = Vector3.zero;
                var meshFilters = cityElementPrefab.GetComponentsInChildren<MeshFilter>();
                var meshRenderers = cityElementPrefab.GetComponentsInChildren<MeshRenderer>();

                if (meshFilters.Length > 1 || meshRenderers.Length > 1)
                {
                    throw new Exception("Complex objects are not supported");
                }

                if (meshFilters.Length == 0 || meshRenderers.Length == 0)
                {
                    Debug.LogError("Object does not have mesh");
                }

                var cityElement = new CityElement();
                cityElement.Prefab = cityElementPrefab;
                cityElement.Mesh = meshFilters[0].sharedMesh;
                cityElement.CorrectYPos = GetCorrectPos(meshFilters[0], meshRenderers[0]);

                cityElements.Add(cityElement);
            }
            
            

            return cityElements;
        }

        private float GetCorrectPos(MeshFilter meshFilter, MeshRenderer renderer)
        {
            float minYValue = float.MaxValue;
            var mesh = meshFilter.sharedMesh;

            foreach (var vertex in mesh.vertices)
            {
                if (vertex.y < minYValue)
                {
                    minYValue = vertex.y;
                }
            }

            return renderer.transform.position.y - minYValue;
        }
    }
}