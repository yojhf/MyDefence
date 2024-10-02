using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace MyDefence
{
    public class MainMenu : MonoBehaviour
    {
        public string playSecne = "TowerDefance";

        void Start()
        {
            SceneFade.Instance.FadeIn(null);
        }
        public void PlayScene()
        {
            SceneFade.Instance.FadeOut(playSecne);
        }

        void LoadPlayScene()
        {
            SceneManager.LoadScene(playSecne);
        }

        public void Quit()
        {
            SceneFade.Instance.FadeOut(null);

            Invoke("QuitGame", 1f);
        }
        public void ResetData()
        {
            PlayerPrefs.DeleteAll();
        }

        void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); // 어플리케이션 종료
#endif
        }
    }
}
