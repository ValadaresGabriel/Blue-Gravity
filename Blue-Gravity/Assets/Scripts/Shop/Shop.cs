using System.Collections;
using System.Collections.Generic;
using ClothGravity.Items;
using UnityEngine;

namespace ClothGravity.Shopping
{
    [CreateAssetMenu(fileName = "New Shop", menuName = "Shop")]
    public class Shop : ScriptableObject
    {
        [SerializeField] List<Item> itemsToSell;
    }
}
