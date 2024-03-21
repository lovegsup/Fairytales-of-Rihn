using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    public class Character : MonoBehaviour
    {
        public float initialMoveSpeed = 3f;

        [HideInInspector] public Level_System levelSystem = new();

        [HideInInspector] public float moveSpeed;
        [HideInInspector] public bool movementAllowed = true;
        [HideInInspector] public bool targetable = true;
        [HideInInspector] public bool attacking = false;

        [HideInInspector] public Vector2 movement;
        [HideInInspector] public Vector2 faceDirection;
        [HideInInspector] public Vector2 aimDirection;
    }
}