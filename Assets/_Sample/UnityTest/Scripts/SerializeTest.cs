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
Unity���� ����ȭ�� ����ϸ� �ν�����â���� ���� �����ϰ� �� �� �ִ� 

���� �� �ε�
�ν�����â
�����Ϳ��� ��ũ��Ʈ ��ε�
������
�ν��Ͻ�ȭ
��ũ���ͺ� ������Ʈ
 
*/
