using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    [RequireComponent(typeof(Health))]

    public class Health_Increaser : MonoBehaviour
    {
        private Health health;

        private bool increasingHealth;

        private void Start()
        {
            TryGetComponent(out health);
        }

        private void Update()
        {
            if (health.HealthValue >= health.initialHealth || increasingHealth)
            {
                return;
            }
            StartCoroutine(IncreaseHealth());
        }

        private IEnumerator IncreaseHealth()
        {
            increasingHealth = true;
            yield return new WaitForSeconds(1);
            increasingHealth = false;

            health.HealthValue += health.initialHealth * 0.1f;
        }
    }
}