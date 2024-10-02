using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SocialPlatforms;


namespace MyDefence
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        private static bool isGameOver = false;
        public static bool IsGameOver => isGameOver;

        [SerializeField] private int reward = 100000;
        [SerializeField] private Transform gameOverUI;
        [SerializeField] private Transform pauseUI;
        public Transform levelClearUI;

        private bool isPause = false;
        private bool isCeat = true;
        private float timeScale = 0;
        public bool isInfi = false;

        // ���� Ŭ���� �� unlock �Ǵ� ����
        [SerializeField ]private string keyName = "NowLevel";
        public int unlockLevel = 2;

        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            unlockLevel = PlayerPrefs.GetInt(keyName);

            isGameOver = false;
            SceneFade.Instance.FadeIn(null);
        }

        void Update()
        {
            GameOver();
            PauseUI();

            if (isCeat == true)
            {
                AddGold();
                CeatGameOverUI();
            }

        }

        void GameOver()
        {
            if (isGameOver)
            {
                return;
            }

            if (PlayerStats.Lives <= 0)
            {
                GameOverUI();
            }
        }

        void GameOverUI()
        {
            isGameOver = true;
 
            gameOverUI.gameObject.SetActive(true);

        
            Pause();
        }





        void AddGold()
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                PlayerStats.SaveGold(reward);
            }
        }

        void CeatGameOverUI()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                GameOverUI();
                
            }
            if (Input.GetKeyDown(KeyCode.P) && levelClearUI != null)
            {
                levelClearUI.gameObject.SetActive(true);
            }
        }

        void PauseUI()
        {
            if (isGameOver == false)
            {
                if (Input.GetKeyDown(KeyCode.Escape) && isPause == false)
                {
                    isPause = true;
                    pauseUI.gameObject.SetActive(true);
                    Pause();
                }
                else if (Input.GetKeyDown(KeyCode.Escape) && isPause == true)
                {
                    ResetPause();
                }

            }

        }


        public void ResetPause()
        {
            isPause = false;
            pauseUI.gameObject.SetActive(false);
            // �Ͻ����� ����
            Time.timeScale = 1.0f;
        }

        public void Pause()
        {
            Time.timeScale = timeScale;
        }


        public void LevelClear()
        {
            // LevelClear ���� ������ ó�� : ����, ����
            // ������ �÷��� ������ ����
            // ����� ������ ��������
            int nowlevel = PlayerPrefs.GetInt(keyName, unlockLevel);
            unlockLevel++;
            Debug.Log($"������ nowLevel {nowlevel}");
            Debug.Log(unlockLevel);

            if (unlockLevel > nowlevel)
            {

                PlayerPrefs.SetInt(keyName, unlockLevel);
                Debug.Log($"����� nowLevel {unlockLevel}");
            }
            else
            {
                Debug.Log($"����� Level {unlockLevel}");
            }

            // UIâ Ȱ��ȭ
            levelClearUI.gameObject.SetActive(true);


        }


    }
}
