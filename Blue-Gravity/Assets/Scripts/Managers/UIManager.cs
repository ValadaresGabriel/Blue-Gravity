using System.Collections;
using System.Collections.Generic;
using ClothGravity.Inventory;
using ClothGravity.Items;
using ClothGravity.Shopping;
using UnityEngine;

namespace ClothGravity.UI
{
    public class UIManager : MonoBehaviour
    {
        private static UIManager Instance;

        [SerializeField] InventoryManager inventory;
        [SerializeField] ShopManager shop;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public static void OpenInventory()
        {
            Instance.inventory.OpenInventory();
        }

        public static void OpenShop(List<Item> items)
        {
            Instance.shop.OpenShop(items);
        }
    }
}
