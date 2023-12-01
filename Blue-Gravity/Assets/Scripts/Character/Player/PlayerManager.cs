using System.Collections;
using System.Collections.Generic;
using ClothGravity.UI;
using UnityEngine;

namespace ClothGravity.Character
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;

        private bool isOnShop;
        private bool isOnInventory;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            PlayerInputManager.Instance.OpenInventoryEvent += OpenInventory;
        }

        private void OpenInventory()
        {
            UIManager.OpenInventory();
        }

        private void OnDestroy()
        {
            PlayerInputManager.Instance.OpenInventoryEvent -= OpenInventory;
        }

        public bool IsOnShop
        {
            get => isOnShop;
            set => isOnShop = value;
        }

        public bool IsOnInventory
        {
            get => isOnInventory;
            set => isOnInventory = value;
        }
    }
}
