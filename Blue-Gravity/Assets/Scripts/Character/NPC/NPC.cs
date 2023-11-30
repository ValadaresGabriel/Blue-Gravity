using System.Collections;
using System.Collections.Generic;
using ClothGravity.Shopping;
using UnityEngine;

namespace ClothGravity.Character
{
    [CreateAssetMenu(fileName = "New NPC", menuName = "Character/NPC")]
    public class NPC : ScriptableObject
    {
        public string npcName;
        public Shop npcShop;
    }
}
