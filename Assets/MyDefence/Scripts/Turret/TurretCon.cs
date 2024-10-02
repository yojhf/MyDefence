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
        protected Transform target; // 공격할 타겟
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

            // 터렛이 1초마다 1발씩 쏘기
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

        // 공격할 target 적을 찾는 메서드
        protected void FindEnemy()
        {
            // 태그를 가진 오브젝트들 객체 가져오기
            gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

            // 가장 가까운 적 찾기
            float minDistance = float.MaxValue; // 최소 거리
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

            // 가장 가까운 적이 공격 범위 안에 있는지 체크
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