using System;
using UnityEngine;

namespace CityGenerator
{
    public class Test : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            var renderer = GetComponent<Renderer>();
            Gizmos.DrawWireCube(renderer.bounds.center, renderer.bounds.size);
            Gizmos.DrawWireSphere(transform.position, 0.1f);
            Gizmos.DrawWireSphere(renderer.bounds.center, 0.1f);
            Debug.Log(renderer.bounds.extents);
            Debug.Log(renderer.bounds.center);
        }
    }
}