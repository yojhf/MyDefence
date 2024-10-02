using UnityEngine;
using UnityEngine.UI;


namespace MyDefence
{
    public class Enemy : MonoBehaviour, IDamgeable
    {
        [SerializeField] private int reward = 50;

        // 체력
        [SerializeField] private float start_hp = 100f;
        [SerializeField] private Transform hp_Prefab;
        [SerializeField] private Transform p_deathEffect;
        public Transform hp_bar;
        private Transform deathEffect;


        private float health;
        private float height = 1.3f;


        private EnemyMove e_move;

        Transform target;

        Vector3 hpbarPos;

        // HealthBar
        public Image hpBar;

        void Start()
        {
            Init();
        }

        void Update()
        {
            e_move.MoveEnemy();
            DieEnemy();

            //HpbarPos();
        }

        void Init()
        {
            target = transform;

            e_move = GetComponent<EnemyMove>();

            e_move.StartSetting();

            health = start_hp;

            //CreatHp();
        }

        void CreatHp()
        {       
            hp_bar = Instantiate(hp_Prefab, hpbarPos, Quaternion.identity, EnemyManager.instance.hp_par);

            hp_bar.GetComponent<InGameUI_HP>().enemyobject = target;
        }

        void HpbarPos()
        {
            hpbarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, transform.position.z));
            hp_bar.position = hpbarPos;
        }

        public void TakeDamage(float damage)
        {
            health -= damage;

            hpBar.fillAmount = health / start_hp;
        }

        void DieEnemy()
        {
            if (Die())
            {
                // 타겟에 데미지를 준다
                DeathEffect();
                EnemyManager.instance.enemyCount++;
                EnemyManager.instance.enemyAlive--;
                PlayerStats.SaveGold(reward);
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


        public float GetHealth() { return health; }
        public float GetStartHealth() { return start_hp; }

    }
}
