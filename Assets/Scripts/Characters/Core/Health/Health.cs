using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    [RequireComponent(typeof(State_Machine))]
    //DO NOT[RequireComponent(typeof(Canvas_Visibility))]

    public class Health : MonoBehaviour
    {
        private State_Machine stateMachine;
        private Canvas_Visibility canvasVisibility;
        private SpriteRenderer spriteRenderer;

        private float currentHealth;
        public float initialHealth = 100f;

        public float HealthValue
        {
            get => currentHealth;
            set
            {
                if (canvasVisibility && !canvasVisibility.canvas.enabled)
                {
                    canvasVisibility.ShowCanvas();
                    canvasVisibility.HideCanvas();
                }

                if (value < currentHealth)
                {
                    StartCoroutine(ChangeColorOnDamage());
                }

                currentHealth = value;

                if (currentHealth <= 0)
                {
                    currentHealth = 0;
                    stateMachine.SwitchState(stateMachine.deadState);
                }
            }
        }

        private void Start()
        {
            TryGetComponent(out stateMachine);
            TryGetComponent(out canvasVisibility);
            TryGetComponent(out spriteRenderer);

            currentHealth = initialHealth;
        }

        private IEnumerator ChangeColorOnDamage()
        {
            spriteRenderer.color = new Color(1, 0.5f, 0.5f);

            yield return new WaitForSeconds(0.3f);

            spriteRenderer.color = Color.white;
        }
    }
}