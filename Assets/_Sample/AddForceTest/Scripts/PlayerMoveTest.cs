using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class PlayerMoveTest : MonoBehaviour
    {
        private KeyCode w = KeyCode.W;
        private KeyCode a = KeyCode.A;
        private KeyCode s = KeyCode.S;
        private KeyCode d = KeyCode.D;

        public Transform target;
        public float speed = 3f;

        public Transform bullet;
        public Transform firePoint;

        private float ctime = 0f;
        public float cooltime = 1f;

        void Start()
        {
            
        }


        void Update()
        {
            // wasd 입력을 받아 이동
            // 항상 타겟을 바라보도록 구현(총구를 자동으로 타겟팅)
            Move();


            if (Input.GetKeyDown(KeyCode.Space))
            {
                ctime = cooltime;
            }



        }

        private void FixedUpdate()
        {
            if (ctime >= cooltime)
            {
                Attack();
                ctime = 0f;
            }

            ctime += Time.deltaTime;
        }

        void Move()
        {
            Vector3 dir = target.position - transform.position;

            if (Input.GetKey(w))
            {
                transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
            }
            if (Input.GetKey(a))
            {
                transform.Translate(-transform.right * Time.deltaTime * speed, Space.World);
            }
            if (Input.GetKey(s))
            {
                transform.Translate(-transform.forward * Time.deltaTime * speed, Space.World);
            }
            if (Input.GetKey(d))
            {
                transform.Translate(transform.right * Time.deltaTime * speed, Space.World);
            }

            transform.rotation = Quaternion.LookRotation(dir);
        }

        void Attack()
        {

            if (Input.GetKey(KeyCode.Space))
            {
                GameObject bul = Instantiate(bullet.gameObject, firePoint.position, firePoint.rotation);

                BulletTest b_test = bul.GetComponent<BulletTest>();

                if (b_test != null)
                {
                    b_test.MoveByForce();
                }

                if (bul != null)
                {
                    Destroy(bul, 3f);
                }
            }
        }
    }
}
