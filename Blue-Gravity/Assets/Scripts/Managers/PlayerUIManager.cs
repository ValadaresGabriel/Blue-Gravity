using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ClothGravity.UI
{
    public class PlayerUIManager : MonoBehaviour
    {
        private static PlayerUIManager Instance;

        [SerializeField] TextMeshProUGUI currencyText;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public static void SetCurrency(int currency)
        {
            Instance.currencyText.SetText($"{currency}g");
        }
    }
}
