using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothGravity.Character
{
    public class PlayerCurrency : MonoBehaviour
    {
        [SerializeField] int currency = 100;

        public int Currency
        {
            get => currency;

            set => currency = value;
        }
    }
}
