using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace MyDefence
{
    public class TurretCon : MonoBehaviour
    {
        public List<GameObject> targetEnemy = new List<GameObject>();
        public GameObject[] gameObjects;

        [SerializeField] protected Transform bullet;
        [SerializeField] protected Transform firePoint;
        protected Transform target; // ������ Ÿ��
        protected Transform rotObject;

        public float attackRange;
        public float count = 0;
        public float attackCool = 1f;
        public float speed;

        // Start is called before the first frame update
        protected virtual void Start()
        {
            rotObject = transform.GetChild(0);

            //StartCoroutine(CoolTime());

            InvokeRepeating("FindEnemy", 0f, 0.5f);
        }

        // Update is called once per frame
        void Update()
        {
            if (target != null)
            {
                SearchTarget();
            }
            else
            {
                return;
            }

            // �ͷ��� 1�ʸ��� 1�߾� ���
            count += Time.deltaTime;

            if (count >= attackCool)
            {          
                Shoot();
                count = 0;
            }


        }

        protected IEnumerator CoolTime()
        {
            while (true)
            {
                FindEnemy();
                yield return new WaitForSeconds(0.5f);
            }
        }

        // ������ target ���� ã�� �޼���
        protected void FindEnemy()
        {
            // �±׸� ���� ������Ʈ�� ��ü ��������
            gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

            // ���� ����� �� ã��
            float minDistance = float.MaxValue; // �ּ� �Ÿ�
            GameObject mainTarget = null;

            foreach(var obj in gameObjects)
            {
                float distance = Vector3.Distance(transform.position, obj.transform.position);

                if(distance < minDistance)
                {
                    minDistance = distance;
                    mainTarget = obj;
                }
            }

            // ���� ����� ���� ���� ���� �ȿ� �ִ��� üũ
            if (mainTarget != null && minDistance < attackRange)
            {
                target = mainTarget.transform;           
            }
            else
            {
                target = null;
            }

        }


        protected void SearchTarget()
        {
            Vector3 dir = target.position - rotObject.position;

            Quaternion targetRotation = Quaternion.LookRotation(dir);

            Vector3 yRot = targetRotation.eulerAngles;

            Quaternion targetRot = Quaternion.Euler(rotObject.rotation.x, yRot.y, rotObject.rotation.z);

            rotObject.rotation = Quaternion.Lerp(rotObject.rotation, targetRot, Time.deltaTime * speed);

        }

        protected void Shoot()
        {
           GameObject _bullet = Instantiate(bullet.gameObject, firePoint.position, firePoint.rotation, transform.GetChild(0).GetChild(1));

            _bullet.GetComponent<Bullet>().SetTarget(target);

        }

         
        private void OnDrawGizmosSelected()
        {
            if (transform == null)
            {
                return;
            }

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }

    }
}