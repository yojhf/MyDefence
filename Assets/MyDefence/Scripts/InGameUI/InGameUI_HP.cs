using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



namespace MyDefence
{
    public class InGameUI_HP : MonoBehaviour
    {
        [SerializeField] private Slider hp_bar;
        public Transform enemyobject;
        private float imsi;

        Enemy enemy;

        void Start()
        {
            //enemyobject = transform.parent;

            enemy = enemyobject.GetComponent<Enemy>();
        }

        void Update()
        {
            //EnemyHp();
        }

        void EnemyHp()
        {
            imsi = enemy.GetHealth() / enemy.GetStartHealth();

            hp_bar.value = Mathf.Lerp(hp_bar.value, imsi, Time.deltaTime * 10);

            if(enemyobject == null)
            {
                Destroy(gameObject);
            }
        }
    }
}
