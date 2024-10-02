using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyDefence
{
    // WayPoint�� �����ϴ� Ŭ����

    public class WayPoint : MonoBehaviour
    {
        //public static WayPoint instance;

        public static Transform[] points;

        private void Awake()
        {
            //instance = this;
            GetWayPoint();
        }

        public  void GetWayPoint()
        {
            points = new Transform[transform.childCount];

            for (int i = 0; i < transform.childCount; i++)
            {
                points[i] = transform.GetChild(i);
            }
        }
    }
}