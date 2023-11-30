using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem.UI;
using UnityEngine.UIElements;

namespace ClothGravity.UI
{
    public class Tooltip : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI titleText;
        [SerializeField] TextMeshProUGUI descriptionText;
        [SerializeField] LayoutElement layoutElement;
        [SerializeField] int descriptionCharacterWrapLimit;
        [SerializeField] RectTransform rectTransform;
        [SerializeField] InputSystemUIInputModule inputModule;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            layoutElement.enabled = NeedsToBeWrapped();
        }

        private void Update()
        {
            Vector2 mousePosition = MouseManager.MousePosition;

            float pivotX = mousePosition.x / Screen.width;
            float pivotY = mousePosition.y / Screen.height;

            rectTransform.pivot = new Vector2(pivotX, pivotY);
            transform.position = mousePosition;
        }

        private bool NeedsToBeWrapped()
        {
            int titleLength = titleText.text.Length;
            int descriptionLength = descriptionText.text.Length;

            if (titleLength > descriptionCharacterWrapLimit || descriptionLength > descriptionCharacterWrapLimit)
            {
                return true;
            }

            return false;
        }
    }
}
