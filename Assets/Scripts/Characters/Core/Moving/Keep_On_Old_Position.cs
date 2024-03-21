using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    [RequireComponent(typeof(Character))]
    [RequireComponent(typeof(Reach_Destination))]

    public class Keep_On_Old_Position : MonoBehaviour
    {
        private Character character;
        private Reach_Destination reachDestination;

        private Vector2 oldPosition;

        private void Start()
        {
            TryGetComponent(out character);
            TryGetComponent(out reachDestination);

            enabled = false;
        }

        private void Update()
        {
            if (reachDestination.destinationReached)
            {
                enabled = false;
                character.targetable = true;
            }
        }

        public void SetOldPosition()
        {
            oldPosition = transform.position;
        }

        public void ReturnToOldPosition()
        {
            enabled = true;
            character.targetable = false;
            reachDestination.wayPoint = oldPosition;
            reachDestination.distanceToReach = reachDestination.initialDistanceToReach;
        }
    }
}