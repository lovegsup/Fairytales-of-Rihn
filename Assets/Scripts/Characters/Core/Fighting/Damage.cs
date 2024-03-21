using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SublimeFury
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] private float initialKnockback = 500f;
        [SerializeField] private float initialDamage = 10f;

        private Grudge_Holder grudger;
        private Transform damagePopup;
        private TextMeshPro damagePopupText;
        private Damage_Popup damagePopupScript;

        private bool isPlayer;

        private void Start()
        {
            damagePopup = Game_Assets.DamagePopup;
            damagePopup.TryGetComponent(out damagePopupText);
            damagePopup.TryGetComponent(out damagePopupScript);
            transform.parent.TryGetComponent(out grudger);

            isPlayer = transform.parent.CompareTag("Player");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.TryGetComponent(out Character targetCharacter);
            if (!targetCharacter.targetable)
            {
                return;
            }
            collision.TryGetComponent(out Health targetHealth);

            grudger.AddGrudge(collision.gameObject);

            Vector2 characterPosition = transform.parent.position;
            Vector2 targetPosition = collision.transform.position;

            Vector2 forceDirection = (targetPosition - characterPosition).normalized;
            Vector2 knockback = initialKnockback * forceDirection;
            float totalDamage = initialDamage;

            collision.attachedRigidbody.AddForce(knockback);
            targetHealth.HealthValue -= totalDamage;

            CreateDamagePopup(targetPosition, forceDirection, totalDamage);
        }

        private void CreateDamagePopup(Vector2 targetPosition, Vector2 forceDirection, float totalDamage)
        {
            damagePopupText.text = totalDamage.ToString();
            damagePopupText.color = isPlayer ? new Color(1, 0.75f, 0.1f) : new Color(0.6f, 0, 0);
            damagePopupScript.movement = forceDirection;
            Instantiate(damagePopup, targetPosition + new Vector2(0, 0.5f), Quaternion.identity);
        }
    }
}