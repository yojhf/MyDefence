using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���׸� Ŭ���� : ���� �Ű����� T�� ������ �������� Ŭ������ ����� ������ �����Ǵ� Ŭ����
namespace Sample
{
    // Ŭ���� �̸� <T>
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
