using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    public class Hearing_Check : MonoBehaviour
    {
        private Character character;
        private Grudge_Holder grudger;

        private GameObject targetCharacter;
        private State_Machine targetStateMachine;

        private void Start()
        {
            transform.parent.TryGetComponent(out character);
            transform.parent.TryGetComponent(out grudger);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!collision.CompareTag("Player") || !character.targetable)
            {
                return;
            }
            CrouchingCheck(collision.gameObject);
        }

        private void CrouchingCheck(GameObject gameObject)
        {
            if (targetCharacter != gameObject)
            {
                targetCharacter = gameObject;
                gameObject.TryGetComponent(out targetStateMachine);
            }

            if (targetStateMachine.currentSpeed == targetStateMachine.crouchingSpeed)
            {
                return;
            }
            grudger.AddGrudge(gameObject);
        }
    }
}