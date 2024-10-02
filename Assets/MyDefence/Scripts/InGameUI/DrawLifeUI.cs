using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



namespace MyDefence
{
    public class DrawLifeUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text life_text;
        [SerializeField] private TMP_Text enemyAilve;

        void Start()
        {
            
        }


        void Update()
        {
            life_text.text = PlayerStats.Lives.ToString();
            enemyAilve.text = EnemyManager.instance.enemyAlive.ToString();
        }
    }
}
