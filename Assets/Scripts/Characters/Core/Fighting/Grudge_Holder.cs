using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    [RequireComponent(typeof(State_Machine))]

    public class Grudge_Holder : MonoBehaviour
    {
        [HideInInspector] public readonly List<GameObject> grudgeList = new();

        private State_Machine stateMachine;

        private void Start()
        {
            TryGetComponent(out stateMachine);
        }

        public void AddGrudge(GameObject grudge)
        {
            if (grudgeList.Contains(grudge))
            {
                return;
            }

            grudge.TryGetComponent(out Grudge_Holder entityGrudger);
            entityGrudger.InternalAddGrudge(gameObject);
            InternalAddGrudge(grudge);
        }

        public void InternalAddGrudge(GameObject grudge)
        {
            grudgeList.Add(grudge);

            if (grudgeList.Count <= 0)
            {
                return;
            }
            stateMachine.SwitchState(stateMachine.fightingState);
        }

        public void RemoveGrudge(GameObject grudge)
        {
            if (!grudgeList.Contains(grudge))
            {
                return;
            }

            grudge.TryGetComponent(out Grudge_Holder entityGrudger);
            entityGrudger.InternalRemoveGrudge(gameObject);
            InternalRemoveGrudge(grudge);
        }

        public void InternalRemoveGrudge(GameObject grudge)
        {
            grudgeList.Remove(grudge);

            if (grudgeList.Count > 0)
            {
                return;
            }
            stateMachine.SwitchState(stateMachine.defaultState);
        }

        public void Clear()
        {
            foreach (GameObject entity in grudgeList)
            {
                entity.TryGetComponent(out Grudge_Holder entityGrudger);
                entityGrudger.InternalRemoveGrudge(gameObject);
            }
            grudgeList.Clear();

            stateMachine.SwitchState(stateMachine.defaultState);
        }
    }
}