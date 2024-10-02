using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Sample
{
    public class ButtonTest : MonoBehaviour
    {
        [SerializeField] private Button Fire;
        [SerializeField] private Button Jump;

        private void Start()
        {
            Fire.onClick.AddListener(BtnTest);
            Jump.onClick.AddListener(JumpTest);
        }

        void BtnTest()
        {
            Debug.Log("발사 하였습니다");
        }
        void JumpTest()
        {
            Debug.Log("플레이어가 점프하였습니다"); 
        }
    }
}
