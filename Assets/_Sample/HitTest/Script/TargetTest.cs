using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class TargetTest : MonoBehaviour
    {
        private int a = 10;     // 
        public int b = 20;      // 


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
           
        }

        // private a�� public �޼���� ��ȯ
        public int GetA()
        {
            return a; 
        }
    }
}