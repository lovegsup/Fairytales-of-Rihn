using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    [RequireComponent(typeof(Character))]
    [RequireComponent(typeof(State_Machine))]

    public class On_Attack_Lock : MonoBehaviour
    {
        private Character character;
        private State_Machine stateMachine;

        private void Start()
        {
            TryGetComponent(out character);
            TryGetComponent(out stateMachine);
        }

        public void StartAttacking()
        {
            if (character.attacking)
            {
                return;
            }
            character.movementAllowed = false;
            character.attacking = true;
            stateMachine.SwitchSpeed(stateMachine.attackingSpeed);
        }

        public void StopAttacking()
        {
            if (!character.attacking)
            {
                return;
            }
            character.movementAllowed = true;
            character.attacking = false;
            stateMachine.ReturnPreviousSpeed();
        }
    }
}