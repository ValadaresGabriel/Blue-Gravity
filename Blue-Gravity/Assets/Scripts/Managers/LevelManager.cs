using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothGravity
{
    public class LevelManager : MonoBehaviour
    {
        private static LevelManager Instance;

        [SerializeField] AudioClip levelMusic;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
    }
}
