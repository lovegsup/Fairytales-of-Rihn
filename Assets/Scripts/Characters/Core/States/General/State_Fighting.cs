using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    public class State_Fighting : State
    {
        private Transform transform;
        private Canvas_Visibility canvasVisibility;
        private Keep_On_Old_Position KeepOnOldPosition;

        private bool isPlayer;

        public override void EnterState(State_Machine stateMachine)
        {
            transform = stateMachine.transform;
            transform.TryGetComponent(out canvasVisibility);
            transform.TryGetComponent(out KeepOnOldPosition);

            isPlayer = transform.CompareTag("Player");

            if (!isPlayer)
            {
                stateMachine.SwitchSpeed(stateMachine.runningSpeed);
            }
            if (canvasVisibility)
            {
                canvasVisibility.ShowCanvas();
            }
            if (KeepOnOldPosition)
            {
                KeepOnOldPosition.SetOldPosition();
            }

            SetComponentsState(true);
        }

        public override void UpdateState(State_Machine stateMachine) { }

        public override void ExitState(State_Machine stateMachine)
        {
            if (!isPlayer)
            {
                stateMachine.SwitchSpeed(stateMachine.defaultSpeed);
            }
            if (canvasVisibility)
            {
                canvasVisibility.HideCanvas();
            }
            if (KeepOnOldPosition)
            {
                KeepOnOldPosition.ReturnToOldPosition();
            }

            SetComponentsState(false);
        }

        private void SetComponentsState(bool state)
        {
            if (transform.TryGetComponent(out Health_Increaser healthIncreaser))
            {
                healthIncreaser.enabled = !state;
            }
            if (transform.TryGetComponent(out Roam_Area roamArea))
            {
                roamArea.enabled = !state;
            }
            if (transform.TryGetComponent(out Sight_Check sightCheck))
            {
                sightCheck.enabled = !state;
            }
            if (transform.TryGetComponent(out Hearing_Check hearingCheck))
            {
                hearingCheck.enabled = !state;
            }
            if (transform.TryGetComponent(out Keep_On_Target keepOnTarget))
            {
                keepOnTarget.enabled = state;
            }
            if (transform.TryGetComponent(out Attack_Target attackTarget))
            {
                attackTarget.enabled = state;
            }
        }
    }
}