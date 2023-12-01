using System.Collections;
using System.Collections.Generic;
using ClothGravity.Character;
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
        [SerializeField] ItemSlot[] equippedItemsSlots;

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
            if (PlayerManager.Instance != null)
            {
                PlayerManager.Instance.IsOnInventory = true;
            }
            else
            {
                Debug.LogError("Player Manager is Null!");
                return;
            }

            inventoryGameObject.SetActive(true);

            foreach (ItemSlot itemSlot in itemSlots)
            {
                if (itemSlot.Item == null) continue;

                itemSlot.SetItemIcon();
            }
        }

        public void CloseInventory()
        {
            PlayerManager.Instance.IsOnInventory = false;
            inventoryGameObject.SetActive(false);
        }

        public static void AddItemToItemSlot(Item item)
        {
            foreach (ItemSlot itemSlot in Instance.itemSlots)
            {
                if (itemSlot.Item == null)
                {
                    itemSlot.AddItem(item);
                    return;
                }
            }

            Debug.LogWarning("There is not free Inventory Slot, so the item cannot be added!");
        }

        public static void EquipItem(ItemSlot itemSlot)
        {
            if (itemSlot.Item == null)
            {
                Debug.LogWarning("The Item from ItemSlot is Null, so it cannot be Equipped!");
                return;
            }

            foreach (ItemSlot equippedItemSlot in Instance.equippedItemsSlots)
            {
                if (equippedItemSlot.Item == null)
                {
                    equippedItemSlot.Item = itemSlot.Item;
                    itemSlot.RemoveItem();
                    break;
                }
            }
        }
    }
}
