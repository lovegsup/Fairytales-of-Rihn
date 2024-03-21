using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    [RequireComponent(typeof(Character))]

    public class State_Machine : MonoBehaviour
    {
        [HideInInspector] public Character character;

        [HideInInspector] public State currentState;
        [HideInInspector] public State_Fighting fightingState = new();
        [HideInInspector] public State_Dead deadState = new();
        [HideInInspector] public State_Default defaultState = new();

        [HideInInspector] public Speed currentSpeed;
        [HideInInspector] public Speed previousSpeed;
        [HideInInspector] public Attacking_Speed attackingSpeed = new();
        [HideInInspector] public Running_Speed runningSpeed = new();
        [HideInInspector] public Crouching_Speed crouchingSpeed = new();
        [HideInInspector] public Default_Speed defaultSpeed = new();

        private void Start()
        {
            TryGetComponent(out character);

            currentState = defaultState;
            currentState.EnterState(this);
            currentSpeed = defaultSpeed;
            currentSpeed.EnterSpeed(this);
        }

        public void SwitchState(State state)
        {
            if (!enabled)
            {
                return;
            }

            currentState.ExitState(this);
            currentState = state;
            currentState.EnterState(this);
        }

        public void SwitchSpeed(Speed speed)
        {
            if (!enabled)
            {
                return;
            }

            previousSpeed = currentSpeed;
            currentSpeed = speed;
            currentSpeed.EnterSpeed(this);
        }

        public void ReturnPreviousSpeed()
        {
            if (!enabled)
            {
                return;
            }

            currentSpeed = previousSpeed;
            currentSpeed.EnterSpeed(this);
        }
    }
}