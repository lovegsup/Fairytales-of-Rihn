using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    [RequireComponent(typeof(Character))]

    public class Reach_Destination : MonoBehaviour
    {
        private Character character;

        public float initialDistanceToReach = 0.1f;

        [HideInInspector] public float distanceToReach;
        [HideInInspector] public bool destinationReached;
        [HideInInspector] public Vector2 wayPoint;

        private void Start()
        {
            TryGetComponent(out character);
        }

        private void Update()
        {
            if (wayPoint == Vector2.zero)
            {
                return;
            }

            float distanceWayPoint = Vector2.Distance(transform.position, wayPoint);
            if (distanceWayPoint <= distanceToReach)
            {
                character.movement = Vector2.zero;
                destinationReached = true;
            }
            else
            {
                Vector2 characterPosition = transform.position;
                character.movement = (wayPoint - characterPosition).normalized;
                destinationReached = false;
            }
        }
    }
}