using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace ClothGravity.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] AudioMixerGroup master;
        [SerializeField] AudioMixerGroup effects;
        [SerializeField] AudioMixerGroup music;

        [SerializeField] Slider masterSlider;
        [SerializeField] Slider effectsSlider;
        [SerializeField] Slider musicSlider;

        [Header("Audio Sources")]
        [SerializeField] AudioSource effectsAudioSource;
        [SerializeField] AudioSource musicAudioSource;

        private const string MasterVolume = "Master Volume";
        private const string EffectsVolume = "Effects Volume";
        private const string MusicVolume = "Music Volume";

        private void Start()
        {
            master.audioMixer.GetFloat(MasterVolume, out float masterVolume);
            masterSlider.value = masterVolume;

            effects.audioMixer.GetFloat(EffectsVolume, out float effectsVolume);
            effectsSlider.value = effectsVolume;

            music.audioMixer.GetFloat(MusicVolume, out float musicVolume);
            musicSlider.value = musicVolume;
        }

        public void PlayEffectsAudio(AudioClip audioClip)
        {
            effectsAudioSource.PlayOneShot(audioClip);
        }

        public void PlayMusicAudio(AudioClip audioClip)
        {
            musicAudioSource.clip = audioClip;
            musicAudioSource.loop = true;
            musicAudioSource.Play();
        }

        public void SetMasterVolume(float value)
        {
            master.audioMixer.SetFloat(MasterVolume, value);
        }

        public void SetEffectsVolume(float value)
        {
            effects.audioMixer.SetFloat(EffectsVolume, value);
        }

        public void SetMusicVolume(float value)
        {
            music.audioMixer.SetFloat(MusicVolume, value);
        }
    }
}
