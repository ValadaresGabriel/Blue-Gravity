using System.Collections;
using System.Collections.Generic;
using ClothGravity.Inventory;
using UnityEngine;

namespace ClothGravity.UI
{
    public class UIManager : MonoBehaviour
    {
        private static UIManager Instance;

        [SerializeField] InventoryManager inventory;

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
    }
}
