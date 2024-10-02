using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class GameOverUI : MonoBehaviour
    {
        public TMP_Text rounds;
        public string firstScene = "Level01";
        public string menuScene = "MainMenu";

        private void Start()
        {
            //rounds.text = PlayerStats.Rounds.ToString();


            
        }

        private void OnEnable()
        {
            if(rounds != null)
            {
                rounds.text = PlayerStats.Rounds.ToString();

            }

            //animator = GetComponent<Animator>();
            //animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        }

        public void Retry()
        {

            SceneFade.Instance.FadeOut(firstScene);
            // 일시정시 원복
            Time.timeScale = 1.0f;
            //SceneManager.LoadScene(firstScene);
        }
        public void Menu()
        {

            SceneFade.Instance.FadeOut(menuScene);
            Time.timeScale = 1.0f;
            //SceneManager.LoadScene(menuScene);
        }

        public void GameOverAni()
        {
            transform.GetComponent<Animator>().enabled = false;
        }

    }
}
