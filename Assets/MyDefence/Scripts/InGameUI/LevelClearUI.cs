using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace MyDefence
{
    public class LevelClearUI : MonoBehaviour
    {
        public string menuScene = "MainMenu";
        public string nextScene = "Level02";
        public void Continue()
        {
            SceneFade.Instance.FadeOut(nextScene);
        }


        public void Menu()
        {
            SceneFade.Instance.FadeOut(menuScene);
        }
    }
}
