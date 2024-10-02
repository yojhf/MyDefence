using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    // 사각형 데이터를 관리하는 구조체
    public class BoxData
    {
        public float x; // box의 x 좌표
        public float y; // box의 y 좌표
        public float width; // box의 width
        public float height; // box의 height

    }

    // 원 데이터를 관리하는 구조체
    public class CircleData
    {
        public float x; // circle의 x 좌표
        public float y; // circle의 y 좌표
        public float radius; // circle의 반지름
    }

    public class HitTest : MonoBehaviour
    {
        [SerializeField] private Transform target;
        private float speed = 300f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // 이동

            // 충돌 체크 판정
            if(CheckPassPostition(target))
            {
                // 충돌 처리
                Debug.Log("충돌");
            }
        }

        // 타겟까지의 거리가 일정 거리안에 있으면 충돌이라고 판정
        bool CheckArrivePostition(Transform target)
        {
            // 타겟 까지의 거리
            float dis = Vector3.Distance(transform.position, target.position);

            if(dis < 0.5f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 타겟까지 이동할 남은 거리가 이번(한) 프레임에 이동하는 거리보다 작을 때 충돌이라고 판정
        bool CheckPassPostition(Transform target)
        {
            // 타겟까지 이동할 남은 거리
            float dis = Vector3.Distance(transform.position, target.position);
            // 이번 프레임에 이동하는 거리
            float x = speed * Time.deltaTime;

            if(dis < x)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // 매개변수로 받은 두개의 box가 충돌 했는지 체크
        // 충돌하면 true, 충돌하지 않으면 false
        public bool CheckHitBox(BoxData a, BoxData b)
        {
            // 충돌하지 않는 4가지 위치 판정

            // [1]
            if((a.x + a.width / 2) < (b.x - b.width / 2))
            {
                return false;
            }

            // [2]
            if ((a.x - a.width / 2) > (b.x + b.width / 2))
            {
                return false;
            }

            // [3]
            if ((a.y + a.height / 2) > (b.y - b.height / 2))
            {
                return false;
            }

            // [4]
            if ((a.y - a.height / 2) < (b.y + b.height / 2))
            {
                return false;
            }

            // 충돌하지 않는 4가지 위치를 제외한 경우에는 충돌 판정
            return true;
        }

        public bool CheckHitBox(CircleData a, CircleData b)
        {
            float disX = a.x - b.x;
            float disY = a.y - b.y;

            float distance = Mathf.Sqrt(disX * disX + disY * disY);

            // 두 원의 거리가 두원의 반지름의 합보다 작으면 충돌
            if(distance <= a.radius + b.radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}
