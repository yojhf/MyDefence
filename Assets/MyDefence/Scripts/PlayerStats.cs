using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



namespace MyDefence
{
    // 플레이어의 속성을 관리하는 클래스
    public class PlayerStats : MonoBehaviour
    {
        private static int gold;
        public static int Gold
        { 
            get { return gold; }
        }

        [SerializeField] private Transform btn_Par;

        public List<Button> btns = new List<Button>();


        [SerializeField] public int startgold = 400;

        private static int lives;

        public static int Lives
        {
            get { return lives; }
        }

        [SerializeField] public int startlives = 10;

        private static int rounds;
        public static int Rounds
        {
            get { return rounds; }
            set { rounds = value; }
        }

        [SerializeField] public int startrounds = 1;

        void Start()
        {
            for (int i = 0; i < btn_Par.childCount; i++)
            {
                btns.Add(btn_Par.GetChild(i).GetComponent<Button>());
            }

            gold = startgold;
            lives = startlives;
            rounds = startrounds;
        }
            

        void Update()
        {

        }

        public static void SaveGold(int reward)
        {
            gold += reward;
        }

        public static bool UseMoney(int amt)
        {
            if (!HasMoney(amt))
            {
                Debug.Log("잔액 부족");
                return false;
            }
            else
            {
                gold -= amt;
                return true;
            }
        }

        public static bool HasMoney(int amount)
        {
            return gold >= amount;
        }

        // 라이프 추가
        public static void AddLives(int amount)
        {
            lives += amount;
        }

        // 라이프 사용
        public static void RemoveLives(int amount)
        {
            lives -= amount;

            if (lives <= 0)
            {
                lives = 0;
            }
        }

    }
}
