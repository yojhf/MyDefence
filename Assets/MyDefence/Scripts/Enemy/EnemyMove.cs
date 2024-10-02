using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace MyDefence
{
    // Enemy�� �̵��� �����ϴ� Ŭ����
    public class EnemyMove : MonoBehaviour
    {
        // �ʵ�
        private Transform target;
        private Transform rotObject;

        [SerializeField] private int wayPointsIndex = 0; // WayPoint ���� �迭�� �����ϴ� �ε���
        private float speed;
        public float startSpeed;

        public void StartSetting()
        {
            wayPointsIndex = 0;

            //WayPoint.instance.GetWayPoint();

            target = WayPoint.points[wayPointsIndex];

            speed = startSpeed;
            rotObject = transform.GetChild(0);
        }

        public void MoveEnemy()
        {
            // ����(dir), Time.deltaTime, speed
            //Vector3 dir = target.position - transform.position;

            //transform.Translate(dir.normalized * Time.deltaTime * speed);

            Vector3 dir = target.position - transform.position;

            transform.Translate(dir.normalized * Time.deltaTime * (speed + EnemyManager.instance.enemySpeed));

            float distance = Vector3.Distance(transform.position, target.position);

            if (distance < 0.3f)
            {

                SetNextTartget();
            }

            rotObject.rotation = Quaternion.Lerp(rotObject.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);

            //rotObject.LookAt(target.position );

            speed = startSpeed;
        }

        void SetNextTartget()
        {

            if (wayPointsIndex == WayPoint.points.Length - 1)
            {
                Arrive();
                return;
            }
            else
            {
                wayPointsIndex++;

                target = WayPoint.points[wayPointsIndex];

            }

        }

        void Arrive()
        {
            Destroy(gameObject);
            EnemyManager.instance.enemyAlive--;
            PlayerStats.RemoveLives(1);
        }

        public void Slow(float rate)
        {
            speed = startSpeed * (1 - rate);
        }

    }
}
