using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyDefence
{
    public class LaserBeamer : TurretCon
    {
        private LineRenderer lazer;
        public ParticleSystem impactEffect;

        private float damage;
        [SerializeField] private float l_damage = 10f;
        
        // Light SerializeField 사용 안됨
        public Light lazelight;

        [SerializeField]private float lazerDamage = 30f;
        private float lazerTimer = 1f;
        private float lazerCount = 0f;

        Enemy enemy;

        // Enemy 속도 40% 감속
        [SerializeField] private float slowRate = 0.4f;


        protected override void Start()
        {
            lazer = GetComponent<LineRenderer>();
            rotObject = transform.GetChild(0);
            impactEffect.Stop();
            lazelight.enabled = false;

            base.Start();
            //StartCoroutine(CoolTime());
        }

        private void Update()
        {
            if (target != null)
            {
                SearchTarget();
                Lazer();
            }
            else
            {
                // 레이저를 그리지 않는다
                if(lazer.enabled)
                {
                    lazer.enabled = false;
                    impactEffect.Stop();
                    lazelight.enabled = false;
                }
                
                return;
            }
        }

        void Lazer()
        {
            LazerAtk();
            EnemySpeedDown();

            // 라인랜더러를 그리기 시작
            if (lazer.enabled == false)
            {
                lazer.enabled = true;
   
                impactEffect.Play();
            }

            // 라인렌더러 그리기 - 시작지점, 끝지점 지정
            lazer.SetPosition(0, firePoint.position);
            lazer.SetPosition(1, target.position);

            Vector3 dir = firePoint.position - target.position;

            impactEffect.transform.rotation = Quaternion.LookRotation(dir);


            impactEffect.transform.position = target.position + dir.normalized * 0.5f;

            lazelight.enabled = true;

        }

        // 레이저 타격 데미지 추가 - 1초당 30 데미지
        void LazerAtk()
        {
            float damage = Time.deltaTime * lazerDamage;

            enemy = target.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        void EnemySpeedDown()
        {
            EnemyMove enemymove = target.GetComponent<EnemyMove>();


            if(enemymove != null)
            {
                enemymove.Slow(slowRate);
            }


        }


    }
}
