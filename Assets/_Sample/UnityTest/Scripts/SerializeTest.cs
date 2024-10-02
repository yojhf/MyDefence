using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Sample
{
    public class TestClass
    {
        public int value1;
        public float value2;
    }

    public class SerializeTest : MonoBehaviour
    {
        [SerializeField] private int speed = 10;
        [SerializeField] private float attackRange = 7f;

        public TestClass testClass;

        void Start()
        {
            
        }


        void Update()
        {
            
        }
    }
}

/*
Unity에서 직렬화를 사용하면 인스펙터창에서 편집 가능하게 할 수 있다 

저장 및 로드
인스펙터창
에디터에서 스크립트 재로드
프리팹
인스턴스화
스크립터블 오브젝트
 
*/
