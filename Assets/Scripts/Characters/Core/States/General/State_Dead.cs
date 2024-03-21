using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    public class State_Dead : State
    {
        private Transform transform;
        private Animator animator;

        public override void EnterState(State_Machine stateMachine)
        {
            stateMachine.SwitchSpeed(stateMachine.defaultSpeed);
            transform = stateMachine.transform;
            transform.TryGetComponent(out animator);

            SetComponentsState(false);

            SettleGrudges();

            stateMachine.StartCoroutine(Rotting());
        }

        public override void UpdateState(State_Machine stateMachine) { }

        public override void ExitState(State_Machine stateMachine)
        {
            SetComponentsState(true);
        }

        private void SetComponentsState(bool state)
        {
            animator.SetBool("Dead", !state);

            if (transform.TryGetComponent(out SpriteRenderer spriteRenderer))
            {
                spriteRenderer.sortingOrder = state ? 0 : -1;
            }

            Canvas canvas = transform.GetComponentInChildren<Canvas>();
            if (canvas)
            {
                canvas.enabled = state;
            }

            MonoBehaviour[] scripts = transform.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                if (!script
                    || script.GetType() == typeof(Level_Bar)
                    || script.GetType() == typeof(Health_Bar)
                    || script.GetType() == typeof(Experience_Bar)
                    || script.GetType() == typeof(Attack_Target)
                    || script.GetType() == typeof(Keep_On_Target))
                {
                    continue;
                }
                script.enabled = state;
            }

            if (transform.TryGetComponent(out CapsuleCollider2D capsuleCollider2D))
            {
                capsuleCollider2D.enabled = state;
            }
        }

        private void SettleGrudges()
        {
            transform.TryGetComponent(out Grudge_Holder grudger);
            foreach (GameObject entity in grudger.grudgeList)
            {
                entity.TryGetComponent(out Grudge_Holder entityGrudger);
                entityGrudger.InternalRemoveGrudge(transform.gameObject);
                entity.TryGetComponent(out Character entityCharacter);
                entityCharacter.levelSystem.AddExperience(25);
            }
        }

        private IEnumerator Rotting()
        {
            yield return new WaitForSeconds(10);

            animator.SetTrigger("Rotten");
        }
    }
}