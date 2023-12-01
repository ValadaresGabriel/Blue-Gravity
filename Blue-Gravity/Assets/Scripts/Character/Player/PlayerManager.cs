using System.Collections;
using System.Collections.Generic;
using ClothGravity.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClothGravity.Character
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;

        private bool isOnShop;
        private bool isOnInventory;
        private bool isInteracting = false;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            PlayerInputManager.Instance.OpenInventoryEvent += OpenInventory;
        }

        public void EnableUIActions()
        {
            PlayerInputManager.Instance.EnableUIActions();
        }

        public void EnablePlayerActions()
        {
            PlayerInputManager.Instance.EnablePlayerActions();
        }

        private void OpenInventory()
        {
            if (!IsOnShop)
            {
                IsInteracting = true;
                UIManager.OpenInventory();
                return;
            }

            UIManager.CloseInventory();
            IsInteracting = false;
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

        public bool IsInteracting
        {
            get => isInteracting;
            set => isInteracting = value;
        }
    }
}
