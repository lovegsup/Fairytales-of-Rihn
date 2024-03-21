using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    public class Sight_Check : MonoBehaviour
    {
        private Character character;
        private Grudge_Holder grudger;
        private CircleCollider2D sightArea;

        private LayerMask playerLayer;

        private void Start()
        {
            TryGetComponent(out sightArea);
            transform.parent.TryGetComponent(out character);
            transform.parent.TryGetComponent(out grudger);

            playerLayer = LayerMask.GetMask("Players");
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!collision.CompareTag("Player") || !character.targetable)
            {
                return;
            }
            LineOfSightCheck();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.CompareTag("Player") || !character.targetable)
            {
                return;
            }
            grudger.RemoveGrudge(collision.gameObject);
        }

        private void LineOfSightCheck()
        {
            int left = -1;
            int right = 1;
            SearchPlayer(left);
            SearchPlayer(right);
        }

        private void SearchPlayer(int side)
        {
            if (grudger.grudgeList.Count > 0)
            {
                return;
            }

            Vector2 characterPosition = transform.position;
            for (int i = 1; i < 8; i += 2)
            {
                float radians = i * 10 * side * Mathf.Deg2Rad;
                RaycastHit2D playerInSight = Physics2D.Raycast(characterPosition, RotatedVector(radians), sightArea.radius, playerLayer);
                if (!playerInSight)
                {
                    continue;
                }
                grudger.AddGrudge(playerInSight.transform.gameObject);

                break;
            }
        }

        private Vector2 RotatedVector(float radians)
        {
            float xCos = character.faceDirection.x * Mathf.Cos(radians);
            float ySin = character.faceDirection.y * Mathf.Sin(radians);
            float xSin = character.faceDirection.x * Mathf.Sin(radians);
            float yCos = character.faceDirection.y * Mathf.Cos(radians);
            return new Vector2(xCos - ySin, xSin + yCos);
        }
    }
}