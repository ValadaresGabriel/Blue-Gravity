using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothGravity.Character
{
    public enum CharacterAnimation
    {
        Idle_Up,
        Idle_Down,
        Idle_Left,
        Idle_Right,
        Walk_Up,
        Walk_Down,
        Walk_Left,
        Walk_Right,
    }

    public class CharacterAnimatorManager : MonoBehaviour
    {
        private CharacterAnimation characterAnimation;
        private Animator animator;
        private Dictionary<CharacterAnimation, string> animations = new()
        {
            { CharacterAnimation.Idle_Up, "Idle_Up" },
            { CharacterAnimation.Idle_Down, "Idle_Down" },
            { CharacterAnimation.Idle_Left, "Idle_Left" },
            { CharacterAnimation.Idle_Right, "Idle_Right" },
            { CharacterAnimation.Walk_Up, "Walk_Up" },
            { CharacterAnimation.Walk_Down, "Walk_Down" },
            { CharacterAnimation.Walk_Left, "Walk_Left" },
            { CharacterAnimation.Walk_Right, "Walk_Right" },
        };

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void ChangeCharacterAnimation(CharacterAnimation newAnimation)
        {
            if (newAnimation == characterAnimation) return;

            characterAnimation = newAnimation;

            animator.Play(animations[newAnimation]);
        }
    }
}
