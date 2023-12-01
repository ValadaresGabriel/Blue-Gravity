using System.Collections;
using System.Collections.Generic;
using ClothGravity.Character.DialogSystem;
using ClothGravity.ShopSystem;
using UnityEngine;

namespace ClothGravity.Character
{
    [CreateAssetMenu(fileName = "New NPC", menuName = "Character/NPC")]
    public class NPC : ScriptableObject
    {
        public string npcName;
        public bool hasShop;
        public Shop npcShop;
        public Dialog dialog;
    }
}
