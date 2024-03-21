using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    [RequireComponent(typeof(Reach_Destination))]
    [RequireComponent(typeof(Grudge_Holder))]

    public class Keep_On_Target : MonoBehaviour
    {
        [SerializeField] private float attackDistance = 1f;
        [SerializeField] private float offsetDistance = 30f;

        private Reach_Destination reachDestination;
        private Grudge_Holder grudger;
        private CircleCollider2D homeArea;

        private void Start()
        {
            TryGetComponent(out reachDestination);
            TryGetComponent(out grudger);
            transform.parent.TryGetComponent(out homeArea);

            enabled = false;
        }

        private void Update()
        {
            reachDestination.wayPoint = grudger.grudgeList[0].transform.position;
            reachDestination.distanceToReach = attackDistance;
            CheckDistanceToHome();
        }

        private void CheckDistanceToHome()
        {
            float distanceOldPosition = Vector2.Distance(transform.position, homeArea.bounds.center);
            if (distanceOldPosition < offsetDistance)
            {
                return;
            }
            grudger.Clear();
        }
    }
}