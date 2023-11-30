using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ClothGravity
{
    public class Interaction : MonoBehaviour, IPointerClickHandler
    {
        private bool isInTheInteractionArea = false;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (isInTheInteractionArea)
            {
                Debug.Log("Has Clicked on NPC!");
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                isInTheInteractionArea = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                isInTheInteractionArea = false;
            }
        }
    }
}
