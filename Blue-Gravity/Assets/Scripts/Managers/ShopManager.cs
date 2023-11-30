using System.Collections;
using System.Collections.Generic;
using ClothGravity.Items;
using ClothGravity.UI;
using UnityEngine;

namespace ClothGravity.Shop
{
    public class ShopManager : MonoBehaviour
    {
        private static ShopManager Instance;

        [SerializeField] GameObject shopGameObject;
        [SerializeField] Transform itemsGroupTransform;
        [SerializeField] GameObject shopSlotPrefab;

        private List<ItemSlot> itemSlots = new();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void OpenShop(List<Item> items)
        {
            foreach (Item item in items)
            {
                GameObject itemSlotInstance = Instantiate(shopSlotPrefab, itemsGroupTransform);
                ItemSlot itemSlot = itemSlotInstance.GetComponent<ItemSlot>();

                itemSlot.item = item;
                itemSlot.SetItemIcon();
            }
        }
    }
}
