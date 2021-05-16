using System;
using TMPro;
using UnityEngine;

namespace CityGenerator
{
    public class CityGeneratorController : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField _xInput;

        [SerializeField]
        private TMP_InputField _yInput;

        [SerializeField]
        private TMP_InputField _nInput;

        private CityGenerator _cityGenerator;

        private void Start()
        {
            _cityGenerator = new CityGenerator();
        }

        public void GenerateQuarter()
        {
            float x = 0f;
            float y = 0f;
            int n = 0;

            if (float.TryParse(_xInput.text, out float xValue))
            {
                x = xValue;
            }
            else
            {
                Debug.LogError("X is not a float value");
            }

            if (float.TryParse(_yInput.text, out float yValue))
            {
                y = yValue;
            }
            else
            {
                Debug.LogError("Y is not a float value");
            }

            if (int.TryParse(_nInput.text, out int nValue))
            {
                n = nValue;
            }
            else
            {
                Debug.LogError("N is not a int value");
            }

            _cityGenerator.Generate(x, y, n);
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying)
            {
                _cityGenerator.OnDrawGizmos();
            }
        }
    }
}