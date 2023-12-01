using System.Collections;
using System.Collections.Generic;
using ClothGravity.Audio;
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

        private void Start()
        {
            PlayLevelMusic();
        }

        private void PlayLevelMusic()
        {
            AudioManager.Instance.PlayMusicAudio(levelMusic);
        }
    }
}
