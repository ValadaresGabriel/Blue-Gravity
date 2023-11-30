using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothGravity.Character
{
    public class PlayerLocomotion : MonoBehaviour
    {
        [SerializeField] float movementSpeed = 6f;
        private Rigidbody2D rb;
        private CharacterAnimatorManager characterAnimatorManager;
        private CharacterAnimation lastMoveDirection = CharacterAnimation.Idle_Down;
        private Vector2 movementValue;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            characterAnimatorManager = GetComponent<CharacterAnimatorManager>();
        }

        private void Update()
        {
            movementValue = PlayerInputManager.Instance.MovementValue;
        }

        private void FixedUpdate()
        {
            if (PlayerInputManager.Instance == null) return;

            rb.velocity = movementSpeed * movementValue;

            SwapAnimation();
        }

        private void UpdateLastMoveDirection()
        {
            if (movementValue.x > 0) lastMoveDirection = CharacterAnimation.Idle_Right;
            else if (movementValue.x < 0) lastMoveDirection = CharacterAnimation.Idle_Left;
            else if (movementValue.y > 0) lastMoveDirection = CharacterAnimation.Idle_Up;
            else if (movementValue.y < 0) lastMoveDirection = CharacterAnimation.Idle_Down;
        }

        private void SwapAnimation()
        {
            if (movementValue == Vector2.zero)
            {
                characterAnimatorManager.ChangeCharacterAnimation(lastMoveDirection);
                return;
            }

            UpdateLastMoveDirection();

            if (movementValue.x == 1)
            {
                characterAnimatorManager.ChangeCharacterAnimation(CharacterAnimation.Walk_Right);
                return;
            }
            else if (movementValue.x == -1)
            {
                characterAnimatorManager.ChangeCharacterAnimation(CharacterAnimation.Walk_Left);
                return;
            }

            if (movementValue.y == 1)
            {
                characterAnimatorManager.ChangeCharacterAnimation(CharacterAnimation.Walk_Up);
            }
            else if (movementValue.y == -1)
            {
                characterAnimatorManager.ChangeCharacterAnimation(CharacterAnimation.Walk_Down);
            }
        }
    }
}
