using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClothGravity.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] SceneField gameScene;
        [SerializeField] GameObject mainGameObject;
        [SerializeField] GameObject audioGameObject;

        public void Play()
        {
            SceneManager.LoadScene(gameScene);
        }

        public void Audio()
        {
            mainGameObject.SetActive(false);
            audioGameObject.SetActive(true);
        }

        public void AudioDone()
        {
            mainGameObject.SetActive(true);
            audioGameObject.SetActive(false);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
