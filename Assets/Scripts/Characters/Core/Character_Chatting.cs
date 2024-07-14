using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SublimeFury
{
    public class Character_Chatting : MonoBehaviour
    {
        [SerializeField] private Transform chatInputTransform;
        [SerializeField] private Transform chatBubbleTransform;

        private TMP_InputField inputField;
        private TextMeshProUGUI textMesh;
        private RectTransform rectTransform;
        private Image chatBackground;
        private Coroutine textRemoval;

        private readonly float initialChatCount = 6;

        [HideInInspector] public float chatCount;

        private void Start()
        {
            inputField = chatInputTransform.GetComponent<TMP_InputField>();
            textMesh = chatBubbleTransform.GetComponentInChildren<TextMeshProUGUI>();
            rectTransform = chatBubbleTransform.GetComponent<RectTransform>();
            chatBackground = chatBubbleTransform.GetComponent<Image>();

            chatCount = initialChatCount;
        }

        public void PrintText()
        {
            if (inputField.text == "")
            {
                return;
            }

            if (textRemoval != null)
            {
                StopCoroutine(textRemoval);
            }

            chatBubbleTransform.gameObject.SetActive(true);
            chatBackground.color = Color.white;
            textMesh.color = Color.white;

            textMesh.SetText(inputField.text);
            textMesh.ForceMeshUpdate();
            inputField.text = "";

            Vector2 textSize = textMesh.GetRenderedValues(false) + new Vector2(30f, 30f);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, textSize.x);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, textSize.y);

            textRemoval = StartCoroutine(RemoveText());
        }

        private IEnumerator RemoveText()
        {
            yield return new WaitForSeconds(chatCount * 0.7f);

            float alphaValue = 1;
            while (textMesh.color.a > 0)
            {
                alphaValue -= 0.1f;
                chatBackground.color = new(chatBackground.color.r, chatBackground.color.g, chatBackground.color.b, alphaValue);
                textMesh.color = new(textMesh.color.r, textMesh.color.g, textMesh.color.b, alphaValue);

                yield return new WaitForSeconds(chatCount * 0.3f / 10);
            }

            textMesh.SetText("");
            chatBubbleTransform.gameObject.SetActive(false);
        }
    }
}
