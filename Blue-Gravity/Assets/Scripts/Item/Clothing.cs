using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothGravity.Item
{
    [CreateAssetMenu(fileName = "New Clothing", menuName = "Item/Clothing")]
    public class Clothing : Item
    {
        public Animator animator;
    }
}
