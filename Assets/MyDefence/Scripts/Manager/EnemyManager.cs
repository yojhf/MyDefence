using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyDefence
{
    public class EnemyManager : MonoBehaviour
    {
        public static EnemyManager instance;

        [SerializeField] private Transform emenyPrefab;
        [SerializeField] private Transform enemyGroup;
        [SerializeField] private TMP_Text Count;
        [SerializeField] private TMP_Text enemyKillCount;
        public Transform hp_par;
        public Transform startPos;

        private float count = 5;
        public int spCount = 1;
        public float spMax;
        public float maxCount;

        public bool isStart = false;

        public float enemySpeed = 1f;
        public int enemyCount = 0;

        public int enemyAlive = 0;

        public Wave[] waves;
        public int waveCount = 0;   


        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            EnemySpawn(waves[waveCount].enemyPrefab);
            waveCount++;
            StartCoroutine(SpawnEmeny());
        }

        private void Update()
        {
            if (enemyAlive > 0)
            {
                return;
            }

            if (waveCount >= waves.Length && GameManager.instance.levelClearUI != null)
            {
                this.enabled = false;

                Debug.Log("게임 끝");
                GameManager.instance.LevelClear();
                return;
            }

            enemyKillCount.text = "SCORE : " + enemyCount.ToString();

            if (isStart == false)
            {
                count -= Time.deltaTime;

                count = Mathf.Clamp(count, 0f, maxCount);
                //Count.text = Mathf.Ceil(count).ToString();
                Count.text = "TIME : " + Mathf.Round(count).ToString();
            }
        }

        public void EnemySpeedCon()
        {
            enemySpeed += 1f;
        }
        public void EnemySpawnCount()
        {
            spMax++;
        }



        IEnumerator SpawnEmeny()
        {


            //Wave wave = waves[waveCount];  

            while (true)
            {
                //Count.text = int.Parse(count).ToString();
                //Count.text = Mathf.Ceil(count).ToString();

                if (count <= 0f)
                {
                    count = maxCount;
                    PlayerStats.Rounds++;

                    if (spCount >= spMax)
                    {

                    }
                    else
                    {
                        spCount++;
                        
                    }

                    //Mathf.Clamp(count, 1, 5);

                    // 맵상의 적이 살아 있으면   
                    if (count == maxCount)
                    {
                        isStart = true;

                        if (GameManager.instance.isInfi == true)
                        {
                            for (int i = 0; i < spCount; i++)
                            {
                                EnemySpawn(emenyPrefab.gameObject);

                                yield return new WaitForSeconds(0.3f);
                            }
                        }
                        else 
                        {

                            for (int i = 0; i < waves[waveCount].count; i++)
                            {
                                EnemySpawn(waves[waveCount].enemyPrefab);
                                yield return new WaitForSeconds(waves[waveCount].delayTime);
                            }

                            waveCount++;
                        }


                        isStart = false;



                    }
                }
                else
                {

                }


                yield return null;
            }
        }
        void EnemySpawn(GameObject prefab)
        {
            Instantiate(prefab, startPos.position, prefab.transform.rotation, enemyGroup);
            enemyAlive++;


        }
    }
}