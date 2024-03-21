using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    public class Spawn_Entities : MonoBehaviour
    {
        [SerializeField] private GameObject entity;
        [SerializeField] private float entitiesToSpawn;
        [SerializeField] private int minLevel = 1;
        [SerializeField] private int maxLevel = 5;

        private CircleCollider2D homeArea;

        private bool spawningEntity;

        private void Start()
        {
            TryGetComponent(out homeArea);
        }

        private void Update()
        {
            if (!spawningEntity && entitiesToSpawn > transform.childCount)
            {
                StartCoroutine(SpawnEntity());
            }
        }

        private IEnumerator SpawnEntity()
        {
            spawningEntity = true;
            yield return new WaitForSeconds(3);
            spawningEntity = false;

            Vector2 homeAreaCenter = homeArea.bounds.center;
            GameObject spawnedEntity = Instantiate(entity, homeAreaCenter + homeArea.radius * Random.insideUnitCircle, Quaternion.identity, transform);

            spawnedEntity.TryGetComponent(out Character entityCharacter);
            entityCharacter.levelSystem.level = Random.Range(minLevel, maxLevel);
        }
    }
}