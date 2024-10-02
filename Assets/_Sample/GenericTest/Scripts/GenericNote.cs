using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Sample
{
    public class GenericNote : MonoBehaviour
    {

        void Start()
        {
            // ���ڿ� �������� �����ϴ� �ν��Ͻ� ����
            Cup<string> s_cup = new Cup<string>();   

            s_cup.Content = "���ڿ�";

            Cup<int> i_cup = new Cup<int>();

            i_cup.Content = 10;

            Debug.Log(s_cup.Content);
            Debug.Log(i_cup.Content);


            // T : ���� Water ����

            Cup<Water> water_cup = new Cup<Water>();
            water_cup.Content = new Water();

            water_cup.Content.name = "water";

            Cup<Coffee> coffee_cup = new Cup<Coffee>();
            coffee_cup.Content = new Coffee();

            Debug.Log(water_cup.Content.name);
            Debug.Log(coffee_cup.Content.ToString());





            Debug.Log(SingletonTest2.Instance.num);         
        }
    }
}
