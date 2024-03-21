using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SublimeFury
{
    [RequireComponent(typeof(Health))]

    public class Health_Bar : MonoBehaviour
    {
        [SerializeField] private Transform healthBarTransform;

        private Health health;
        private Canvas canvas;
        private Slider healthSlider;
        private TextMeshPro textMesh;

        private void Start()
        {
            TryGetComponent(out health);
            canvas = healthBarTransform.parent.GetComponentInChildren<Canvas>();
            healthSlider = healthBarTransform.GetComponentInChildren<Slider>();
            textMesh = healthSlider.GetComponentInChildren<TextMeshPro>();
        }

        private void Update()
        {
            textMesh.enabled = canvas.enabled;
            healthSlider.value = (float)health.HealthValue / health.initialHealth;
            textMesh.text = $"{health.HealthValue}/{health.initialHealth}";
        }
    }
}