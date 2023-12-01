using System.Collections;
using System.Collections.Generic;
using ClothGravity.Items;
using UnityEngine;

namespace ClothGravity.ShopSystem
{
    [CreateAssetMenu(fileName = "New Shop", menuName = "Shop")]
    public class Shop : ScriptableObject
    {
        public List<Item> itemsToSell;
    }
}
