using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothGravity
{
    public class PlayerInputManager : MonoBehaviour, Controls.IPlayerActionsActions, Controls.IUIActions
    {
        public static PlayerInputManager Instance { get; private set; }

        // Player Actions
        [Header("Player Actions")]
        public Vector2 MovementValue;
        public event Action MouseLeftButtonEvent;
        public event Action MouseRightButtonEvent;
        public event Action OpenInventoryEvent;

        // UI Actions
        public event Action NextDialogEvent;

        private Controls playerControls;

        private bool enablePlayerActions;
        private bool enableUIActions;

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

        private void Start()
        {
            playerControls = new Controls();
            playerControls.PlayerActions.SetCallbacks(this);

            playerControls.Enable();
        }

        private void Update()
        {
            if (enableUIActions)
            {
                enableUIActions = false;
                playerControls.PlayerActions.RemoveCallbacks(this);

                playerControls.UI.SetCallbacks(this);
            }

            if (enablePlayerActions)
            {
                enablePlayerActions = false;
                playerControls.UI.RemoveCallbacks(this);

                playerControls.PlayerActions.SetCallbacks(this);
            }
        }

        public void EnableUIActions()
        {
            enablePlayerActions = false;
            enableUIActions = true;
        }

        public void EnablePlayerActions()
        {
            enablePlayerActions = true;
            enableUIActions = false;
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

        public void OnOpenInventory(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OpenInventoryEvent?.Invoke();
            }
        }

        public void OnNextDialog(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                NextDialogEvent?.Invoke();
            }
        }
    }
}
