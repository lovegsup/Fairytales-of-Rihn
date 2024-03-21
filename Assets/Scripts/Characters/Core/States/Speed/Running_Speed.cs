using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    public class Running_Speed : Speed
    {
        private Character character;

        public override void EnterSpeed(State_Machine stateMachine)
        {
            character = stateMachine.character;

            if (character.attacking)
            {
                return;
            }
            character.moveSpeed = character.initialMoveSpeed * 2;
        }
    }
}