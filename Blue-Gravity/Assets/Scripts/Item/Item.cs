using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothGravity.Items
{
    public enum ItemType
    {
        Clothing,
        Hair,
        Hat,
    }

    public class Item : ScriptableObject
    {
        public ItemType itemType;
        public Sprite itemIcon;
        public string itemName;
        public string itemDescription;
        public int itemPrice;
    }
}
