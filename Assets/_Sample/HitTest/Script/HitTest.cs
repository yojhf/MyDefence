using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    // �簢�� �����͸� �����ϴ� ����ü
    public class BoxData
    {
        public float x; // box�� x ��ǥ
        public float y; // box�� y ��ǥ
        public float width; // box�� width
        public float height; // box�� height

    }

    // �� �����͸� �����ϴ� ����ü
    public class CircleData
    {
        public float x; // circle�� x ��ǥ
        public float y; // circle�� y ��ǥ
        public float radius; // circle�� ������
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
            // �̵�

            // �浹 üũ ����
            if(CheckPassPostition(target))
            {
                // �浹 ó��
                Debug.Log("�浹");
            }
        }

        // Ÿ�ٱ����� �Ÿ��� ���� �Ÿ��ȿ� ������ �浹�̶�� ����
        bool CheckArrivePostition(Transform target)
        {
            // Ÿ�� ������ �Ÿ�
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

        // Ÿ�ٱ��� �̵��� ���� �Ÿ��� �̹�(��) �����ӿ� �̵��ϴ� �Ÿ����� ���� �� �浹�̶�� ����
        bool CheckPassPostition(Transform target)
        {
            // Ÿ�ٱ��� �̵��� ���� �Ÿ�
            float dis = Vector3.Distance(transform.position, target.position);
            // �̹� �����ӿ� �̵��ϴ� �Ÿ�
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

        // �Ű������� ���� �ΰ��� box�� �浹 �ߴ��� üũ
        // �浹�ϸ� true, �浹���� ������ false
        public bool CheckHitBox(BoxData a, BoxData b)
        {
            // �浹���� �ʴ� 4���� ��ġ ����

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

            // �浹���� �ʴ� 4���� ��ġ�� ������ ��쿡�� �浹 ����
            return true;
        }

        public bool CheckHitBox(CircleData a, CircleData b)
        {
            float disX = a.x - b.x;
            float disY = a.y - b.y;

            float distance = Mathf.Sqrt(disX * disX + disY * disY);

            // �� ���� �Ÿ��� �ο��� �������� �պ��� ������ �浹
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
