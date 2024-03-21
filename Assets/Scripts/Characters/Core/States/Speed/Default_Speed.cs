using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    public class Default_Speed : Speed
    {
        private Character character;

        public override void EnterSpeed(State_Machine stateMachine)
        {
            character = stateMachine.character;

            character.moveSpeed = character.initialMoveSpeed;
        }
    }
}