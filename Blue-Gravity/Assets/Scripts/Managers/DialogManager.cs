using System.Collections;
using System.Collections.Generic;
using ClothGravity.Character.Dialog;
using UnityEngine;
using TMPro;

namespace ClothGravity.UI
{
    public class DialogManager : MonoBehaviour
    {
        [SerializeField] GameObject dialogGameObject;
        [SerializeField] TextMeshProUGUI ownerText;
        [SerializeField] TextMeshProUGUI messageText;
        [SerializeField] float letterDelayTime = 0.01f;

        public void InitializeDialog(Dialog dialog)
        {
            dialogGameObject.SetActive(true);
        }

        private IEnumerator TypeMessage(string message)
        {
            foreach (char letter in message.ToCharArray())
            {
                messageText.SetText(messageText.text + letter);
                yield return new WaitForSeconds(letterDelayTime);
            }
        }
    }
}
