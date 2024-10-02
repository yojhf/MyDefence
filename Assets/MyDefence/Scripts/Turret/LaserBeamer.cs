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
        
        // Light SerializeField ��� �ȵ�
        public Light lazelight;

        [SerializeField]private float lazerDamage = 30f;
        private float lazerTimer = 1f;
        private float lazerCount = 0f;

        Enemy enemy;

        // Enemy �ӵ� 40% ����
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
                // �������� �׸��� �ʴ´�
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

            // ���η������� �׸��� ����
            if (lazer.enabled == false)
            {
                lazer.enabled = true;
   
                impactEffect.Play();
            }

            // ���η����� �׸��� - ��������, ������ ����
            lazer.SetPosition(0, firePoint.position);
            lazer.SetPosition(1, target.position);

            Vector3 dir = firePoint.position - target.position;

            impactEffect.transform.rotation = Quaternion.LookRotation(dir);


            impactEffect.transform.position = target.position + dir.normalized * 0.5f;

            lazelight.enabled = true;

        }

        // ������ Ÿ�� ������ �߰� - 1�ʴ� 30 ������
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
