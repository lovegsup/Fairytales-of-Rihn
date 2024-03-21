using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    public class Damage_Popup : MonoBehaviour
    {
        [HideInInspector] public Vector2 movement;

        private void FixedUpdate()
        {
            Vector2 popupPosition = transform.position;
            float moveSpeed = 5f;
            transform.position = popupPosition + moveSpeed * Time.fixedDeltaTime * movement;
        }

        public void OnFadeDestroy()
        {
            Destroy(gameObject);
        }
    }
}