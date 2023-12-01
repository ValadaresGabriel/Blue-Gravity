using System.Collections;
using System.Collections.Generic;
using ClothGravity.Items;
using UnityEngine;
using UnityEngine.UI;

namespace ClothGravity.UI
{
    public class ItemSlot : MonoBehaviour, ITooltip
    {
        [SerializeField] Image itemIcon;
        private Item item;
        private bool isEquipped;

        public void SetItemIcon()
        {
            if (!itemIcon.enabled)
            {
                itemIcon.enabled = true;
            }

            itemIcon.sprite = item.itemIcon;
        }

        public void AddItem(Item newItem)
        {
            item = newItem;
            SetItemIcon();
        }

        public void RemoveItem()
        {
            item = null;
            itemIcon.enabled = false;
        }

        public Item Item
        {
            get => item;
            set => item = value;
        }

        public bool IsEquipped
        {
            get => isEquipped;
            set => isEquipped = value;
        }

        public string GetTooltipTitle()
        {
            if (item != null)
            {
                return item.itemName;
            }

            return "";
        }

        public string GetTooltipDescription()
        {
            if (item != null)
            {
                return item.itemDescription;
            }

            return "";
        }

        public string GetTooltipPrice()
        {
            if (item != null)
            {
                return item.itemPrice.ToString();
            }

            return "";
        }
    }
}
