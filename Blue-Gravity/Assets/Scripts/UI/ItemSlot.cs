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
        public Item item;

        public void SetItemIcon()
        {
            if (!itemIcon.enabled)
            {
                itemIcon.enabled = true;
            }

            itemIcon.sprite = item.itemIcon;
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
