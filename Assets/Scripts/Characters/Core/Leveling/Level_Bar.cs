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
        private TextMeshProUGUI textMesh;

        private void Start()
        {
            TryGetComponent(out character);
            textMesh = levelBarTransform.GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Update()
        {
            textMesh.SetText($"lvl\n{character.levelSystem.level}");
        }
    }
}