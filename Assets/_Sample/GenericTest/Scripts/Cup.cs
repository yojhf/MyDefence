using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 제네릭 클래스 : 형식 매개변수 T에 지정한 형식으로 클래스와 멤버의 성질을 결정되는 클래스
namespace Sample
{
    // 클래스 이름 <T>
    public class Cup <T>
    {
        public T Content { get; set; }

        public void PrintData(T content)
        {
            Debug.Log(content);
        }
    }

    public class  Water
    {
        public string name;
    }

    public class Coffee
    {

    }



}
