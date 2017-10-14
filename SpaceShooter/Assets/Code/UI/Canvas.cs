using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter.UI {
    public class Canvas : MonoBehaviour
    {
        //[SerializeField] Scene _scene;
        [SerializeField] private string _levelName;

        public void StartGame()
        {
            SceneManager.LoadScene(_levelName);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
