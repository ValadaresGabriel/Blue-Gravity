using System.Collections;
using System.Collections.Generic;
using ClothGravity.Character;
using ClothGravity.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ClothGravity.UI
{
    public class InventorySlotTrigger : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {
        [SerializeField] Canvas canvas;
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;

        private void Awake()
        {
            rectTransform = GetComponentInChildren<RectTransform>();
            canvasGroup = GetComponentInChildren<CanvasGroup>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (PlayerManager.Instance != null)
            {
                if (eventData.button == PointerEventData.InputButton.Right)
                {
                    GameObject pressedObject = eventData.pointerPress;

                    if (pressedObject == null)
                    {
                        Debug.LogWarning("PressedObject is Null!");
                        return;
                    }

                    if (PlayerManager.Instance.IsOnShop)
                    {
                        Debug.Log("Sell Item!");
                    }
                    else if (PlayerManager.Instance.IsOnInventory)
                    {
                        Debug.Log("Equip Item!");
                        InventoryManager.EquipItem(eventData.pointerPress.GetComponent<ItemSlot>());
                    }
                }
            }
            else
            {
                Debug.LogError("Player Manager is Null!");
            }
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

        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("Drop");
        }
    }
}
