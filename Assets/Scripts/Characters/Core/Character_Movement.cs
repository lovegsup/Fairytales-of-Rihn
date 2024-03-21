using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    [RequireComponent(typeof(Character))]
    [RequireComponent(typeof(Character_Flip))]

    public class Character_Movement : MonoBehaviour
    {
        private Character character;
        private Character_Flip flipper;
        private Rigidbody2D characterRigidbody;

        private void Start()
        {
            TryGetComponent(out character);
            TryGetComponent(out flipper);
            TryGetComponent(out characterRigidbody);
        }

        private void FixedUpdate()
        {
            if (character.movement == Vector2.zero || !character.movementAllowed)
            {
                return;
            }
            characterRigidbody.MovePosition(characterRigidbody.position + character.moveSpeed * Time.fixedDeltaTime * character.movement);
            flipper.CheckFlip(character.movement);
        }
    }
}
