using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



namespace Sample
{
    public class ImageTest : MonoBehaviour
    {
        public Image skbtn_image;
        public Button skbtn;

        [SerializeField] private float cool = 5f;
        private float countdown = 0f;

        private bool isCooldown = false;

        #region Test
        //private bool isCharge;

        //private void Start()
        //{
        //    isCharge = true;
        //}
        //private void Update()
        //{
        //    if (isCharge)
        //    {
        //        return;
        //    }


        //    countdown += Time.deltaTime;

        //    if (countdown >= cool)
        //    {
        //        isCharge = true;
        //        skbtn.interactable = true;

        //        countdown = 0;
        //    }

        //    skbtn_image.fillAmount = countdown / cool;
        //}

        //public void SkillUse()
        //{
        //    isCharge = false;
        //    skbtn.interactable = false;           
        //}
        #endregion

        public void UseSkill()
        {
            StartCoroutine(Skill());
        }

        IEnumerator Skill()
        {
            if (isCooldown == false)
            {
                isCooldown = true;

                Debug.Log("스킬사용");

                while (countdown < cool)
                {
                    countdown += Time.deltaTime;

                    skbtn.interactable = false;
                    skbtn_image.fillAmount = countdown / cool;


                    yield return null;
                }

                countdown = 0f;
                skbtn.interactable = true;
                isCooldown = false;
            }
        }



    }
}
