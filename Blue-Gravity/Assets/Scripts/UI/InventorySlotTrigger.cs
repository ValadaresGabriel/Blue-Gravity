using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ClothGravity.UI
{
    public class InventorySlotTrigger : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {
        [SerializeField] Canvas canvas;
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;

        private void Awake()
        {
            rectTransform = GetComponentInChildren<RectTransform>();
            canvasGroup = GetComponentInChildren<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            //
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            //
        }

        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("Drop");
        }
    }
}
