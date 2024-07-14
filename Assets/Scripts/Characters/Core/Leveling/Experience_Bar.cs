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
        private Slider experienceSlider;
        private TextMeshProUGUI textMesh;

        private void Start()
        {
            TryGetComponent(out character);
            experienceSlider = experienceBarTransform.GetComponent<Slider>();
            textMesh = experienceSlider.GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Update()
        {
            experienceSlider.value = (float)character.levelSystem.experience / character.levelSystem.experienceThreshold;
            textMesh.SetText($"{character.levelSystem.experience}/{character.levelSystem.experienceThreshold}");
        }
    }
}