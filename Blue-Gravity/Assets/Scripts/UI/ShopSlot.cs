using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using ClothGravity.Character;
using ClothGravity.Inventory;
using ClothGravity.Items;

namespace ClothGravity.UI
{
    public class ShopSlot : ItemSlot, IPointerClickHandler
    {
        [SerializeField] TextMeshProUGUI itemNameText;
        [SerializeField] TextMeshProUGUI itemPriceText;

        public void SetTitleAndPriceText()
        {
            itemNameText.SetText(Item.itemName);
            itemPriceText.SetText($"{Item.itemPrice}g");
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            // If the player has enough money -> buy, reduce money, add to inventory
            if (PlayerManager.Instance == null) return;

            if (PlayerManager.Instance.playerCurrency.Currency >= Item.itemPrice)
            {
                PlayerManager.Instance.playerCurrency.Currency -= Item.itemPrice;

                InventoryManager.AddItemToItemSlot(Item);
            }
        }
    }
}
