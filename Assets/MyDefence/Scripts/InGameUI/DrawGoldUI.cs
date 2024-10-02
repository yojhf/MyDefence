using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyDefence
{
    public class DrawGoldUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text gold_text;

        void Start()
        {
            
        }


        void Update()
        {
            gold_text.text = "GOLD : " + PlayerStats.Gold.ToString();
        }
    }
}
