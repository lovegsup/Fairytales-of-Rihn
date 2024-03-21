using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    [RequireComponent(typeof(Character))]

    public class Character_Animator : MonoBehaviour
    {
        private Character character;
        private Animator animator;

        private void Start()
        {
            TryGetComponent(out character);
            TryGetComponent(out animator);

            character.faceDirection = new Vector2(0, -1);
        }

        private void Update()
        {
            animator.SetFloat("MoveSpeed", character.movement.sqrMagnitude);
            animator.SetFloat("MoveDirectionX", character.movement.x);
            animator.SetFloat("MoveDirectionY", character.movement.y);
            animator.SetFloat("AimDirectionX", character.aimDirection.x);
            animator.SetFloat("AimDirectionY", character.aimDirection.y);
            animator.SetFloat("FaceDirectionX", character.faceDirection.x);
            animator.SetFloat("FaceDirectionY", character.faceDirection.y);

            if (character.movement == Vector2.zero)
            {
                animator.speed = 0.1f;
            }
            else
            {
                animator.speed = character.moveSpeed / 24;
            }
        }
    }
}