using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    [RequireComponent(typeof(Character))]
    [RequireComponent(typeof(Reach_Destination))]

    public class Roam_Area : MonoBehaviour
    {
        private Character character;
        private Reach_Destination reachDestination;
        private CircleCollider2D homeArea;

        private void Start()
        {
            TryGetComponent(out character);
            TryGetComponent(out reachDestination);
            transform.parent.TryGetComponent(out homeArea);
        }

        private void Update()
        {
            if (character.movement != Vector2.zero)
            {
                return;
            }
            StartCoroutine(SetDestination());
        }

        private IEnumerator SetDestination()
        {
            yield return new WaitForSeconds(5);

            if (character.movement != Vector2.zero)
            {
                yield break;
            }
            Vector2 homeAreaCenter = homeArea.bounds.center;
            reachDestination.wayPoint = homeAreaCenter + homeArea.radius * Random.insideUnitCircle;
            reachDestination.distanceToReach = reachDestination.initialDistanceToReach;
        }
    }
}