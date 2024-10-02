using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    public class Bullet : MonoBehaviour
    {
        protected Transform target;
        [SerializeField] protected GameObject b_Effect;
        public float bulletSpeed = 70f;

        private float damage;
        [SerializeField] private float s_damage = 50f;

        Enemy enemy;

        private void Start()
        {
            damage = s_damage;
        }

        // Update is called once per frame
        void Update()
        {
            ShootBullet();

            //if(CheckPassPostition(target))
            //{
            //    Destroy(gameObject);
            //    Destroy(target.gameObject);
            //}
        }

        public void SetTarget(Transform _target)
        {
            target = _target;
        }
    
        void ShootBullet()
        {
            if(target != null)
            {
                Vector3 dir = target.position - transform.position;
                float disFrame = bulletSpeed * Time.deltaTime;
               
                // dir.magnitude == Vector3.Distance(transform.position, target.position)
                // 두 오브젝트간 사이의 거리를 구하는 것과 동일
                if (dir.magnitude < disFrame)
                {
                    HitTarget();
        
                    return;
                }

                transform.Translate(dir.normalized * disFrame, Space.World);

                // 타겟을 방향으로 바라본다(회전한다)
                transform.LookAt(target);
            }
            else
            {
                Destroy(gameObject);
                return;
            }

        }
        protected virtual void HitTarget()
        {
            GameObject be = Instantiate(b_Effect, target.position, Quaternion.identity);
            Destroy(be, 2f);

            // 불릿
            Destroy(gameObject);

            Damage(target);
           
            //EnemyManager.instance.enemyCount++;
        }

        

        bool CheckPassPostition(Transform target)
        {
            // 타겟까지 이동할 남은 거리
            float dis = Vector3.Distance(transform.position, target.position);
            // 이번 프레임에 이동하는 거리
            float x = bulletSpeed * Time.deltaTime;

            if (dis < x)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void Damage(Transform target)
        {
            
            IDamgeable damgeable = target.GetComponent<IDamgeable>();

            if (damgeable != null)
            {
                damgeable.TakeDamage(damage);
            }


            //Damgeable damgeable1 = target.GetComponent<Damgeable>();

            //if (damgeable1 != null)
            //{
            //    damgeable1.TakeDamage(damage);
            //}
        }

    }
}