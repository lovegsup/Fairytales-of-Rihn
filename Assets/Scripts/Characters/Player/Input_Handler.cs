using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SublimeFury
{
    [RequireComponent(typeof(Character))]
    [RequireComponent(typeof(Character_Flip))]
    [RequireComponent(typeof(Character_Chatting))]
    [RequireComponent(typeof(State_Machine))]

    public class Input_Handler : MonoBehaviour
    {
        private Character character;
        private Character_Flip flipper;
        private Character_Chatting chatter;
        private State_Machine stateMachine;
        private Animator animator;
        
        private bool aimingAllowed;
        private bool toggleCrouch;
        private bool toggleSprint;

        private void Start()
        {
            TryGetComponent(out character);
            TryGetComponent(out flipper);
            TryGetComponent(out chatter);
            TryGetComponent(out stateMachine);
            TryGetComponent(out animator);
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            character.movement = context.ReadValue<Vector2>().normalized;
        }

        public void OnFace(InputAction.CallbackContext context)
        {
            Vector2 faceInput = context.ReadValue<Vector2>().normalized;
            if (faceInput == Vector2.zero)
            {
                return;
            }
            flipper.CheckFlip(faceInput);
        }

        public void OnAim(InputAction.CallbackContext context)
        {
            if (!aimingAllowed)
            {
                return;
            }
            character.aimDirection = (Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>()) - transform.position).normalized;
            flipper.CheckFlip(character.aimDirection);
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            if (character.attacking)
            {
                return;
            }

            if (context.started && character.movement == Vector2.zero)
            {
                aimingAllowed = true;
            }

            if (!context.canceled)
            {
                return;
            }
            aimingAllowed = false;

            character.aimDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position) * 10;
            flipper.CheckFlip(character.aimDirection);

            animator.SetTrigger("Attack");
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            if (toggleSprint)
            {
                return;
            }

            if (context.started)
            {
                stateMachine.SwitchSpeed(stateMachine.runningSpeed);
            }

            if (context.canceled)
            {
                stateMachine.SwitchSpeed(stateMachine.defaultSpeed);
            }
        }

        public void OnContinuousSprint()
        {
            toggleSprint = !toggleSprint;
            stateMachine.SwitchSpeed(toggleSprint ? stateMachine.runningSpeed : stateMachine.defaultSpeed);
        }

        public void OnCrouch(InputAction.CallbackContext context)
        {
            if (toggleCrouch)
            {
                return;
            }

            if (context.started)
            {
                stateMachine.SwitchSpeed(stateMachine.crouchingSpeed);
            }

            if (context.canceled)
            {
                stateMachine.SwitchSpeed(stateMachine.defaultSpeed);
            }
        }

        public void OnContinuousCrouch()
        {
            toggleCrouch = !toggleCrouch;
            stateMachine.SwitchSpeed(toggleCrouch ? stateMachine.crouchingSpeed : stateMachine.defaultSpeed);
        }

        public void OnChat()
        {
            chatter.PrintText();
        }
    }
}