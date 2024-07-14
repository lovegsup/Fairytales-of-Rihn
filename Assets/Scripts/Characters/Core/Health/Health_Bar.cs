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
        private Slider healthSlider;
        private TextMeshProUGUI textMesh;

        private void Start()
        {
            TryGetComponent(out health);
            healthSlider = healthBarTransform.GetComponent<Slider>();
            textMesh = healthSlider.GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Update()
        {
            healthSlider.value = (float)health.HealthValue / health.initialHealth;
            textMesh.SetText($"{health.HealthValue}/{health.initialHealth}");
        }
    }
}