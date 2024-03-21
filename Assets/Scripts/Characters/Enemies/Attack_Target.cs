using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    [RequireComponent(typeof(Character))]
    [RequireComponent(typeof(Character_Flip))]
    [RequireComponent(typeof(Reach_Destination))]

    public class Attack_Target : MonoBehaviour
    {
        private Character character;
        private Character_Flip flipper;
        private Reach_Destination reachDestination;
        private Animator animator;

        private void Start()
        {
            TryGetComponent(out character);
            TryGetComponent(out flipper);
            TryGetComponent(out reachDestination);
            TryGetComponent(out animator);

            enabled = false;
        }

        private void Update()
        {
            float distanceToTarget = Vector2.Distance(transform.position, reachDestination.wayPoint);
            if (distanceToTarget > reachDestination.distanceToReach)
            {
                return;
            }
            TriggerAttack();
        }

        private void TriggerAttack()
        {
            if (character.attacking)
            {
                return;
            }

            Vector2 characterPosition = transform.position;
            character.aimDirection = (reachDestination.wayPoint - characterPosition).normalized;
            flipper.CheckFlip(character.aimDirection);

            animator.SetTrigger("Attack");
        }
    }
}