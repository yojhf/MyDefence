using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    public class MoneyTest : MonoBehaviour
    {
        [SerializeField] private TMP_Text gold_text;
        //[SerializeField] private Button p01_btn;
        //[SerializeField] private Button p02_btn;


        [SerializeField] private Transform btn_Par;
        public List<Button> btns = new List<Button>();
        List<int> cost = new List<int>();   

        private int p01_cost = 1000;
        private int p02_cost = 9000;

        private int gold;

        ColorBlock p01_color;
        ColorBlock p02_color;


        void Start()
        {
            for(int i = 0; i < btn_Par.childCount; i++)
            {
                btns.Add(btn_Par.GetChild(i).GetComponent<Button>());
            }

            p01_color = btns[0].colors;
            p02_color = btns[1].colors;

            gold = 1000;     
        }


        void Update()
        {
            gold_text.text = gold.ToString();
            BtnCon1();
            BtnCon2();
        }

        void BtnCon1()
        {
            if (!HasMoney(p01_cost))
            {
                btns[0].image.color = Color.red;

                //p01_color.normalColor = Color.red;
                //btns[0].colors = p01_color;
            }
            else
            {
                btns[0].image.color = Color.white;
                //p01_color.normalColor = Color.white;
                //btns[0].colors = p01_color;
            }

        }

        void BtnCon2()
        {
            if (gold < p02_cost)    
            {
                btns[1].image.color = Color.red;

                //p02_color.normalColor = Color.red;
                //btns[1].colors = p02_color;
            }
            else
            {
                btns[1].image.color = Color.white;

                //p02_color.normalColor = Color.white;
                //btns[1].colors = p02_color;
            }



        }

        public void SaveGold()
        {
            gold += 1000;
        }

        public void Purchase01()
        {
            bool isUser = UseMoney(p01_cost);

            if (isUser) { Debug.Log("구매완"); }
        }
        public void Purchase02()
        {
            if (UseMoney(p02_cost)) { Debug.Log("구매완"); }
        }
        
        public bool UseMoney(int amt)
        {
            if(!HasMoney(amt))
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

        bool HasMoney(int amount)
        {
            return gold >= amount;
        }



    }
}
