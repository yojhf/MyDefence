using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace MyDefence
{
    public class Monster : MonoBehaviour, IDamgeable
    {
        [SerializeField] private float start_hp = 100f;
        [SerializeField] private Transform p_deathEffect;
        private Transform deathEffect;
        private float health;
        private float height = 1.3f;


        private EnemyMove e_move;

        Transform target;

        Vector3 hpbarPos;

        void Start()
        {
            Init();
        }

        void Update()
        {
            //e_move.MoveEnemy();

            //hpbarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, transform.position.z));
        }

        void Init()
        {
            //target = transform;

            //e_move = GetComponent<EnemyMove>();

            //e_move.StartSetting();

            health = start_hp;
        }

        public void TakeDamage(float damage)
        {
            health -= damage;

            if (Die())
            {
                // 타겟에 데미지를 준다
                DeathEffect();
                //EnemyManager.instance.enemyCount++;
                //PlayerStats.SaveGold(50);
                Destroy(gameObject);
            }
        }

        public bool Die()
        {
            return health <= 0;
        }

        public void DeathEffect()
        {
            deathEffect = Instantiate(p_deathEffect, transform.position, Quaternion.identity);
            Destroy(deathEffect.gameObject, 2f);
        }
    }
}
