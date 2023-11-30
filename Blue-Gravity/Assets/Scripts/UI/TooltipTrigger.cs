using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ClothGravity.UI
{
    public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            TooltipManager.ShowTooltip();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            TooltipManager.HideTooltip();
        }
    }
}
