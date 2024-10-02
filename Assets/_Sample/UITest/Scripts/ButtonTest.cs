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
            Debug.Log("�߻� �Ͽ����ϴ�");
        }
        void JumpTest()
        {
            Debug.Log("�÷��̾ �����Ͽ����ϴ�"); 
        }
    }
}
