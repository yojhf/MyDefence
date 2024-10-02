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
            //Debug.Log("Ÿ�� : " + targetPosition);
            //Debug.Log("���� ��ġ : " + transform.position);

            float movepower = 200f;


            //��ġ ������ �������� ���� ���͸� ���Ѵ�.
            Vector3 direction = targetPosition - transform.position;

            //������ ���� ��ǥ ����(Vector3)�� ��������� ��ȯ�ϴ� �޼���
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            Vector3 yRot = targetRotation.eulerAngles;

            //(���۰�, ��ǥ��, ȸ�� �ӵ�)�� ���ڷ� �޾� ȸ�� ���� �������ִ� �޼���
            Quaternion rotateAmount = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.x, yRot.y, transform.rotation.z), Time.deltaTime * movepower);

            //ȸ���� ����
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
20 ������ : 0.05��

10 ������ : Time.deltaTime = 0.1��
// 1�ʿ� 1unit ��ŭ �̵�
transform.position += Vector3.right * Time.deltaTime; // 0.1��

Translate : transform �̵� �Լ�

// dir : �̵��� ����
// Time.deltaTime : �̵��� ������ �ð��� ������ �Ÿ��� �̵��ϰ� ���ش�
// speed : �ӵ� - 1�ʴ� �̵��ϴ� �Ÿ�
transform.Translate(Vector3.forward * Time.deltaTime * speed);

// dir : ��ǥ���� - ��������, ��ǥ��ġ - ������ġ
Vector3 dir = targetPos - transform.position;

// dir.normalized : ���� ����, ����ȭ�� ����, ���̰� 1�� ����
// dir.magnitude : ����, ũ��

transform.Translate(dir.normalized * Time.deltaTime * speed);

transform.Translate(dir.normalized * Time.deltaTime * speed, Space.Self); // ���� �� �������� �̵� => defult
transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World); // �۷ι� �� �������� �̵�







*/
