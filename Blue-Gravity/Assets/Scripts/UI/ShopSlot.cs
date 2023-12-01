using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

namespace ClothGravity.UI
{
    public class ShopSlot : ItemSlot, IPointerClickHandler
    {
        [SerializeField] TextMeshProUGUI itemNameText;
        [SerializeField] TextMeshProUGUI itemPriceText;
        private float itemPrice;

        public void SetTitleAndPriceText(string title, string price, float itemPrice)
        {
            itemNameText.SetText(title);
            itemPriceText.SetText($"{price}g");
            this.itemPrice = itemPrice;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            // If the player has enough money -> buy, reduce money, add to inventory
        }

        public float ItemPrice
        {
            get => itemPrice;
        }
    }
}
