using UnityEngine;

namespace CityGenerator
{
    public class CityGenerator
    {
        private float _x;
        private float _y;
        private int _objectsCount;

        public void Generate(float x, float y, int n)
        {
            _x = x;
            _y = y;
            _objectsCount = n;
        }

        public void OnDrawGizmos()
        {
            Vector3 center = new Vector3(_x / 2, 0, _y / 2);
            Vector3 size = new Vector3(_x, 0, _y);
            Gizmos.DrawWireCube(center, size);
        }
    }
}