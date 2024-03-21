using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    public class Canvas_Visibility : MonoBehaviour
    {
        [HideInInspector] public Canvas canvas;

        private void Start()
        {
            canvas = GetComponentInChildren<Canvas>();
        }

        public void ShowCanvas()
        {
            canvas.enabled = true;
        }

        public void HideCanvas()
        {
            StartCoroutine(FadeCanvas());
        }

        private IEnumerator FadeCanvas()
        {
            yield return new WaitForSeconds(2);

            canvas.enabled = false;
        }
    }
}