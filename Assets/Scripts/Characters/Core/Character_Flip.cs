using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    [RequireComponent(typeof(Character))]

    public class Character_Flip : MonoBehaviour
    {
        private Character character;
        private Canvas canvas;

        private bool facingRight = true;

        private void Start()
        {
            TryGetComponent(out character);
            canvas = GetComponentInChildren<Canvas>();
        }

        public void CheckFlip(Vector2 checkDirection)
        {
            character.faceDirection = checkDirection;
            if (checkDirection.x >= 0 && facingRight || checkDirection.x <= 0 && !facingRight)
            {
                return;
            }
            FlipScale(transform);
            facingRight = !facingRight;

            if (!canvas)
            {
                return;
            }
            FlipScale(canvas.transform);
        }

        private void FlipScale(Transform objectTransform)
        {
            Vector3 objectScale = objectTransform.localScale;
            objectScale.x *= -1;
            objectTransform.localScale = objectScale;
        }
    }
}