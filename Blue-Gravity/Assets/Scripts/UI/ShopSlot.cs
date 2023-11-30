using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ClothGravity.UI
{
    public class ShopSlot : ItemSlot
    {
        [SerializeField] TextMeshProUGUI itemNameText;
        [SerializeField] TextMeshProUGUI itemPriceText;

        public void SetTitleAndPriceText(string title, string price)
        {
            itemNameText.SetText(title);
            itemPriceText.SetText(price);
        }
    }
}
