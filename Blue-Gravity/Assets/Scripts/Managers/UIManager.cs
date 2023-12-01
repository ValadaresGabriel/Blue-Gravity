using System.Collections;
using System.Collections.Generic;
using ClothGravity.Character;
using ClothGravity.Inventory;
using ClothGravity.Items;
using ClothGravity.ShopSystem;
using UnityEngine;

namespace ClothGravity.UI
{
    public enum Interaction
    {
        Inventory,
        Dialog,
        Shop,
    }

    public class UIManager : MonoBehaviour
    {
        private static UIManager Instance;

        [SerializeField] InventoryManager inventory;
        [SerializeField] DialogManager dialog;
        [SerializeField] ShopManager shop;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public static void Interact(Interaction interaction, NPC npc = null, List<Item> items = null)
        {
            if (PlayerManager.Instance.IsInteracting)
            {
                Debug.Log("The Player is already interacting!");
                return;
            }

            switch (interaction)
            {
                case Interaction.Inventory:
                    OpenInventory();
                    break;
                case Interaction.Dialog:
                    PlayerManager.Instance.EnableUIActions();
                    OpenDialog(npc);
                    break;
                case Interaction.Shop:
                    OpenShop(items);
                    break;
            }

            PlayerManager.Instance.IsInteracting = true;
        }

        public static void OpenInventory()
        {
            Instance.inventory.OpenInventory();
        }

        public static void CloseInventory()
        {
            Instance.inventory.CloseInventory();
        }

        public static void OpenDialog(NPC npc)
        {
            Instance.dialog.OpenDialog(npc);
        }

        public static void CloseDialog()
        {
            PlayerManager.Instance.EnablePlayerActions();
            Instance.dialog.CloseDialog();
        }

        public static void OpenShop(List<Item> items)
        {
            Instance.shop.OpenShop(items);
        }
    }
}
