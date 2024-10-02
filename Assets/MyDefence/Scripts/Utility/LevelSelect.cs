using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



namespace MyDefence
{
    public class LevelSelect : MonoBehaviour
    {
        [SerializeField] private Transform content;
        [SerializeField] private TMP_Text stageName;
        [SerializeField] private string firstScene = "TowerDefance";
        [SerializeField] private List<Transform> levelSelect = new List<Transform>();
        [SerializeField] private List<Button> levelSelectButton = new List<Button>();

        // ����� ���� ��������
        [SerializeField] private string keyName = "NowLevel";

        public Scrollbar scrollbar;
        public RectTransform scrollView;
        public RectTransform contentRect;
        void Start()
        {


            if (PlayerPrefs.GetInt(keyName) == 0)
            {
                PlayerPrefs.GetInt(keyName, 1);
                PlayerPrefs.SetInt(keyName, 1);
            }
            else
            {
                // ����� ������ ��������
                PlayerPrefs.GetInt(keyName);
                Debug.Log($"������ nowLevel {PlayerPrefs.GetInt(keyName)}");
            }




            SceneFade.Instance.FadeIn(null);

            for (int i = 0; i < content.childCount; i++)
            {
                int stage = i + 1;

                levelSelect.Add(content.GetChild(i));
                levelSelectButton.Add(content.GetChild(i).GetComponent<Button>());

                levelSelect[i].GetChild(0).GetComponent<TMP_Text>().text = stage.ToString();

                if(i < PlayerPrefs.GetInt(keyName))
                {
                    levelSelectButton[i].interactable = true;
                }
            }

            // ���ڷ� ���� 
            float cellsize = content.GetComponent<GridLayoutGroup>().cellSize.y;
            float spacing = content.GetComponent<GridLayoutGroup>().spacing.y;
            float contentHeight = cellsize + (int)((levelSelectButton.Count - 1) / 5) * (cellsize + spacing);
            float scrollHeight = contentHeight - scrollView.rect.height;
            

            if(scrollHeight > 0)
            {
                float levelHeight = (int)(PlayerPrefs.GetInt(keyName) - 1) / 5 * (cellsize + spacing);
                scrollbar.value = 1 - levelHeight / scrollHeight;

                if (scrollbar.value < 0f)
                {
                    scrollbar.value = 0f;
                }
            }
        }


        void Update()
        {
            
        }

        public void SelectLevel(string level)
        {

            
            //index = int.Parse(transform.GetChild(0).GetComponent<TMP_Text>().text);

            //Debug.Log(index);
            SceneFade.Instance.FadeOut(level);
        }
        public void Back()
        {
            SceneFade.Instance.FadeOut("MainMenu");
        }

        public void Infi()
        {
            SceneFade.Instance.FadeOut(firstScene);
        }
    }
}

/*
// ���ӵ����� Save / Load
- ����(����̽�) : ����
- ���� : DataBase

PlayerPrefs
- PlayerPrefs.SetInt(string Keyname, int Value); // Keyname���� value �� �����ϱ� (save)
- PlayerPrefs.GetInt(string Keyname) // Keyname���� value �� �ҷ����� (Load)

- PlayerPrefs.SetFloat(string Keyname, float Value); 
- PlayerPrefs.GetFloat(string Keyname) 

- PlayerPrefs.SetString(string Keyname, string Value); 
- PlayerPrefs.GetString(string Keyname) 

*/
