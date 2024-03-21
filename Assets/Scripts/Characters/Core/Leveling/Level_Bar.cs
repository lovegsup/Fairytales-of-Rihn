using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SublimeFury
{
    [RequireComponent(typeof(Character))]

    public class Level_Bar : MonoBehaviour
    {
        [SerializeField] private Transform levelBarTransform;

        private Character character;
        private Canvas canvas;
        private TextMeshPro textMesh;

        private void Start()
        {
            TryGetComponent(out character);
            canvas = levelBarTransform.parent.GetComponentInChildren<Canvas>();
            textMesh = levelBarTransform.GetComponentInChildren<TextMeshPro>();
        }

        private void Update()
        {
            textMesh.enabled = canvas.enabled;
            textMesh.text = $"lvl\n{character.levelSystem.level}";
        }
    }
}