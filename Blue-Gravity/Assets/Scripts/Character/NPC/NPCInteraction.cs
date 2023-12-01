using System.Collections;
using System.Collections.Generic;
using ClothGravity.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ClothGravity.Character
{
    public class NPCInteraction : Interaction
    {
        private NPC npc;

        private void Awake()
        {
            npc = GetComponent<NPCManager>().npc;

            if (npc == null)
            {
                Debug.LogError("The NPC does not have a NPC in the NPC Manager!");
            }
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);

            if (!isInTheInteractionArea) return;

            if (npc == null)
            {
                Debug.LogError($"The NPC does not have a NPC in the NPC Manager! NPC GameObject: {gameObject.name}");
                return;
            }

            if (PlayerManager.Instance.IsInteracting)
            {
                Debug.LogWarning("The Player is alredy interacting!");
                return;
            }

            UIManager.Interact(UI.Interaction.Dialog, npc: npc);
        }
    }
}
