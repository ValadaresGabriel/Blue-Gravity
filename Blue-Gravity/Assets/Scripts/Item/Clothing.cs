using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace ClothGravity.Items
{
    [CreateAssetMenu(fileName = "New Clothing", menuName = "Items/Clothing")]
    public class Clothing : Item
    {
        public RuntimeAnimatorController animator;
    }
}
