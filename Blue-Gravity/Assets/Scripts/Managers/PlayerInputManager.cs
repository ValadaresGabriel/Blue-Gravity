using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothGravity
{
    public class PlayerInputManager : MonoBehaviour, Controls.IPlayerActionsActions
    {
        public static PlayerInputManager Instance { get; private set; }

        public Vector2 MovementValue;
        public event Action MouseLeftButtonEvent;
        public event Action MouseRightButtonEvent;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void OnMovement(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            MovementValue = context.ReadValue<Vector2>();
        }

        public void OnMouseLeftButton(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                MouseLeftButtonEvent?.Invoke();
            }
        }

        public void OnMouseRightButton(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                MouseRightButtonEvent?.Invoke();
            }
        }
    }
}
