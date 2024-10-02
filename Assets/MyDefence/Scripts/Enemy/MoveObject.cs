using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

namespace MyDefence
{
    public enum Type
    {
        SK,
        Cube,
        Learn,
        UpDateMove
    }

    public class MoveObject : MonoBehaviour
    {
        public Type type;

        public List<Transform> WayPoints = new List<Transform>();
        public Transform Way;
        public GameObject enemy;
        public bool isClear = false;

        private int w_index = 0;
        private Vector3 targetPosition;

        // Start is called before the first frame update
        void Start()
        {
            if (Way != null)
            {
                for (int i = 0; i < Way.childCount; i++)
                {
                    WayPoints.Add(Way.GetChild(i));
                }
            }

            switch (type)
            {
                case Type.SK:
                    StartCoroutine(MoveCube());
                    break;
                case Type.Cube:
                    Init();
                    StartCoroutine(MoveCube2());
                    break;
                case Type.Learn:               
                    //StartSetting();
                    break;
                case Type.UpDateMove:
                    Init();
                    break;
            }
        }

        private void Update()
        {
            switch (type)
            {
                case Type.Learn:
                    //MoveEnemy();
                    break;
                case Type.UpDateMove:
                    EnemyCon();
                    ObjectTurn();
                    break;

            }
        }
        void Init()
        {
            w_index = 0;

            targetPosition = WayPoints[w_index].position;
        }

        void EnemyCon()
        {
            float movepower = 1f;

            for (int i = 0; i < WayPoints.Count; i++)
            {
                //targetPosition = WayPoints[i].position;

                Vector3 dir = targetPosition - transform.position;

                transform.Translate(dir.normalized * Time.deltaTime * movepower);


                float distance = Vector3.Distance(transform.position, targetPosition);

                if (distance < 0.3f)
                {
                    SelectNewTarget();
                }

     
            }

        }

        void SelectNewTarget()  
        {
            if (w_index == WayPoints.Count - 1)
            {
                Destroy(gameObject);
                //Destroy(enemy);
                return;
            }
            else
            {
                w_index++;

                targetPosition = WayPoints[w_index].position;
            }

        }

        IEnumerator MoveCube2()
        {
            float mtime = 2f;
            float rtime = 0f;
            float movepower = 2f;

            for (int i = 0; i < WayPoints.Count; i++)
            {
                while (rtime < mtime)
                {

                    targetPosition = WayPoints[i].position;

                    transform.position = Vector3.Lerp(transform.position, new Vector3(WayPoints[i].position.x, transform.position.y, WayPoints[i].position.z), Time.deltaTime * movepower);

                    ObjectTurn();

                    rtime += Time.deltaTime;

                    //float distance = Vector3.Distance(transform.position, targetPosition);

                    //if (distance < 0.3f)
                    //{
                    //    SelectNewTarget();
                    //}


                    yield return null;
                }

                rtime = 0f;

            }

            if (enemy != null)
            {
                Destroy(enemy);
                Destroy(gameObject);
            }
        }


        IEnumerator MoveCube()
        {
            float mtime = 2f;
            float rtime = 0f;
            float movepower = 3f;

            Vector3 tmppos = Vector3.zero;

            while (isClear == false)
            {
                for (int i = 0; i < WayPoints.Count; i++)
                {
                    while (rtime < mtime)
                    {
                        if (WayPoints.Count <= 0)
                        {
                            isClear = true;

                            StopCoroutine(MoveCube());
                            yield return null;
                        }

                        if (isClear == false)
                        {
                            targetPosition = WayPoints[i].position;

                            transform.position = Vector3.Lerp(transform.position, new Vector3(WayPoints[i].position.x, transform.position.y, WayPoints[i].position.z), Time.deltaTime * movepower);

                            ObjectTurn();

                            rtime += Time.deltaTime;

                            i = 0;

                            yield return null;

                        }
                    }

                    rtime = 0f;
                }

            }

            if (enemy != null)
            {
                Destroy(enemy);
            }
        }

        void ObjectTurn()
        {
            //Debug.Log("타겟 : " + targetPosition);
            //Debug.Log("현재 위치 : " + transform.position);

            float movepower = 200f;


            //위치 정보를 바탕으로 방향 벡터를 구한다.
            Vector3 direction = targetPosition - transform.position;

            //위에서 구한 목표 방향(Vector3)을 사분위수로 전환하는 메서드
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            Vector3 yRot = targetRotation.eulerAngles;

            //(시작값, 목표값, 회전 속도)를 인자로 받아 회전 값을 연산해주는 메서드
            Quaternion rotateAmount = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.x, yRot.y, transform.rotation.z), Time.deltaTime * movepower);

            //회전값 적용
            transform.rotation = rotateAmount;

            


        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);

            for (int i = 0; i < WayPoints.Count; i++)
            {
                if (other.transform == WayPoints[i])
                {
                    WayPoints.Remove(other.transform);
                }
            }

            if(other.CompareTag("Bullet"))
            {
                Destroy(gameObject);
            }


        }

    }
}

/*
Time.deltaTime
20 프레임 : 0.05초

10 프레임 : Time.deltaTime = 0.1초
// 1초에 1unit 만큼 이동
transform.position += Vector3.right * Time.deltaTime; // 0.1초

Translate : transform 이동 함수

// dir : 이동할 방향
// Time.deltaTime : 이동시 동일한 시간에 동일한 거리를 이동하게 해준다
// speed : 속도 - 1초당 이동하는 거리
transform.Translate(Vector3.forward * Time.deltaTime * speed);

// dir : 목표지점 - 현재지점, 목표위치 - 현재위치
Vector3 dir = targetPos - transform.position;

// dir.normalized : 단위 벡터, 정규화된 벡터, 길이가 1인 벡터
// dir.magnitude : 길이, 크기

transform.Translate(dir.normalized * Time.deltaTime * speed);

transform.Translate(dir.normalized * Time.deltaTime * speed, Space.Self); // 로컬 축 기준으로 이동 => defult
transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World); // 글로벌 축 기준으로 이동







*/
