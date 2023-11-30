using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothGravity.UI
{
    public class TooltipManager : MonoBehaviour
    {
        private static TooltipManager Instance;

        [SerializeField] Tooltip tooltip;

        private void Awake()
        {
            Instance = this;
        }

        public static void ShowTooltip()
        {
            Instance.tooltip.gameObject.SetActive(true);
        }

        public static void HideTooltip()
        {
            Instance.tooltip.gameObject.SetActive(false);
        }
    }
}
