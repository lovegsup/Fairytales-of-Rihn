using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SublimeFury
{
    [RequireComponent(typeof(Character))]

    public class Experience_Bar : MonoBehaviour
    {
        [SerializeField] private Transform experienceBarTransform;

        private Character character;
        private Canvas canvas;
        private Slider experienceSlider;
        private TextMeshPro textMesh;

        private void Start()
        {
            TryGetComponent(out character);
            canvas = experienceBarTransform.parent.GetComponentInChildren<Canvas>();
            experienceSlider = experienceBarTransform.GetComponentInChildren<Slider>();
            textMesh = experienceSlider.GetComponentInChildren<TextMeshPro>();
        }

        private void Update()
        {
            textMesh.enabled = canvas.enabled;
            experienceSlider.value = (float)character.levelSystem.experience / character.levelSystem.experienceThreshold;
            textMesh.text = $"{character.levelSystem.experience}/{character.levelSystem.experienceThreshold}";
        }
    }
}