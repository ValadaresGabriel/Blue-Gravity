using System.Collections;
using System.Collections.Generic;
using ClothGravity.Items;
using ClothGravity.UI;
using UnityEngine;

namespace ClothGravity.Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        private static InventoryManager Instance;

        [SerializeField] GameObject inventoryGameObject;
        [SerializeField] Transform itemsGroupTransform;

        private List<ItemSlot> itemSlots = new();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            foreach (Transform itemSlotTransform in itemsGroupTransform)
            {
                itemSlots.Add(itemSlotTransform.GetComponent<ItemSlot>());
            }
        }

        public void OpenInventory()
        {
            inventoryGameObject.SetActive(true);

            foreach (ItemSlot itemSlot in itemSlots)
            {
                itemSlot.SetItemIcon();
            }
        }

        public void AddItemToItemSlot(Item item)
        {
            foreach (ItemSlot itemSlot in itemSlots)
            {
                if (itemSlot.item == null)
                {
                    itemSlot.item = item;
                    break;
                }
            }
        }
    }
}
