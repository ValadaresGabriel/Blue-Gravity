using System;
using System.Collections;
using System.Collections.Generic;
using ClothGravity.Character;
using ClothGravity.Items;
using ClothGravity.UI;
using Unity.VisualScripting;
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
        private Vector3 originalPosition;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            originalPosition = inventoryGameObject.transform.position;

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

        public void OpenInventoryWithShop()
        {
            OpenInventory();
            inventoryGameObject.transform.position = new Vector3(inventoryGameObject.transform.position.x, -213, inventoryGameObject.transform.position.z);
        }

        public void CloseInventoryWithShop()
        {
            CloseInventory();
            inventoryGameObject.transform.position = originalPosition;
        }

        public void CloseInventory()
        {
            PlayerManager.Instance.IsOnInventory = false;
            inventoryGameObject.SetActive(false);
        }

        public static bool IsThereFreeItemSlots()
        {
            foreach (ItemSlot itemSlot in Instance.itemSlots)
            {
                if (itemSlot.Item == null)
                {
                    return true;
                }
            }

            return false;
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

            Debug.Log($"{itemSlot} -> {itemSlot.Item.itemType}");

            Item item = null;

            if (!AttemptToUnequipItemWithTheSameType(itemSlot)) return;

            foreach (ItemSlot equippedItemSlot in Instance.equippedItemsSlots)
            {
                if (equippedItemSlot.Item == null)
                {
                    item = itemSlot.Item;

                    equippedItemSlot.Item = itemSlot.Item;
                    equippedItemSlot.SetItemIcon();
                    itemSlot.RemoveItem();
                    break;
                }
            }

            if (item == null)
            {
                Debug.LogWarning("You cannot equip more items!");
                return;
            }

            PlayerManager.Instance.playerEquipItem.EquipItem(item);
        }

        private static bool AttemptToUnequipItemWithTheSameType(ItemSlot itemSlot)
        {
            if (itemSlot.Item.itemType == ItemType.Clothing && PlayerManager.Instance.playerEquipItem.isClothingEquipped)
            {
                return UnequipItem(ItemType.Clothing);
            }
            else if (itemSlot.Item.itemType == ItemType.Hair && PlayerManager.Instance.playerEquipItem.isHairEquipped)
            {
                return UnequipItem(ItemType.Hair);
            }
            else if (itemSlot.Item.itemType == ItemType.Hat && PlayerManager.Instance.playerEquipItem.isHatEquipped)
            {
                return UnequipItem(ItemType.Hat);
            }

            return true;
        }

        private static bool UnequipItem(ItemType itemType)
        {
            // Check if there is free item slots
            if (!IsThereFreeItemSlots())
            {
                Debug.LogWarning("There is no free item slots to unequip this item.");
                return false;
            }

            foreach (ItemSlot equippedItemSlot in Instance.equippedItemsSlots)
            {
                if (equippedItemSlot.Item == null) continue;

                if (equippedItemSlot.Item.itemType == itemType)
                {
                    Item item = equippedItemSlot.Item;

                    equippedItemSlot.Item = null;
                    equippedItemSlot.RemoveItem();
                    AddItemToItemSlot(item);
                    break;
                }
            }

            return true;
        }
    }
}
