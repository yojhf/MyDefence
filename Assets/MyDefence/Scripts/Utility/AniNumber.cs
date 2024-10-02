using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;



namespace MyDefence
{
    public class AniNumber : MonoBehaviour
    {
        public int tNum = 10;
        public TMP_Text rounds;
        [SerializeField] private float delay = 0.05f;

        private void OnEnable()
        {
            if (rounds != null)
            {

                StartCoroutine(ShowRound(PlayerStats.Rounds));
            }
        }


        IEnumerator ShowRound(int targetNum)
        {
            int ctime = 0;

            rounds.text = ctime.ToString();

            yield return new WaitForSeconds(delay);

            while (ctime < targetNum)
            {
                ctime ++;
                rounds.text = ctime.ToString();
                Debug.Log(ctime);
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
