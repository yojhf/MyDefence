using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace MyDefence
{
    public class PauseUI : GameOverUI
    {
        public void Continue()
        {
            GameManager.instance.ResetPause();
        }
        public void Toggle()
        {
            
        }
    }
}
