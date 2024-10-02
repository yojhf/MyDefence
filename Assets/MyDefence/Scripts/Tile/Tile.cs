using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Timeline;

namespace MyDefence
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private Transform buildEffect;
        [SerializeField] private Transform sellEffect;

        public Transform myTurret;

        public Material hovermaterial;
        private Material startMat;
        Renderer objectRender;
        MeshRenderer objectMeshRender;
        public Color hoverColor;
        Color startcolor;

        private int nextStage = 10;
        //private int stage02 = 30;
        //private int stage03 = 50;
        //private int stage04 = 70;
        //private int stage05 = 90;

        public float time = 2f;

        private bool isChange = false;

        private BulidManager bulidManager;

        public TurretBlueprint bluePrint;

        public Color notenoughColor = Color.red;

        public bool IsUpgrade {  get; private set; }
 

        //public bool isActive = false;

        // Start is called before the first frame update
        void Start()
        {
            objectRender = GetComponent<Renderer>();
 
            startMat = objectRender.material;

            startcolor = objectRender.material.color;

            GetComponent<MeshRenderer>().enabled = false;

            bulidManager = BulidManager.instance;

            IsUpgrade = false;

        }

        private void Update()
        {
            //NextStage();
        }

        public void NextStage()
        {
            int tmpCount = EnemyManager.instance.enemyCount;

            if (tmpCount == nextStage)
            {
                isChange = true;

                if(isChange == true)
                {
                    nextStage += 20;
                    StartCoroutine(ChangeStage(BulidManager.instance.TileColor()));
                    isChange = false;
                }

            }
            //else if (tmpCount == nextStage)
            //{
            //    StartCoroutine(ChangeStage(bulidManager.instance.TileColor()));
            //}
            //else if (tmpCount == nextStage)
            //{
            //    StartCoroutine(ChangeStage(bulidManager.instance.TileColor()));
            //}
            //else if (tmpCount == nextStage)   
            //{
            //    StartCoroutine(ChangeStage(bulidManager.instance.TileColor()));
            //}
            //else if (tmpCount == nextStage)
            //{
            //    StartCoroutine(ChangeStage(bulidManager.instance.TileColor()));
            //}
        }

        public Transform GetTransform()
        {
            Transform tile = transform ;

            return tile ;
        }

        IEnumerator ChangeStage(Color color)
        {

            float ctime = 0;

            while (ctime < time)
            {
                objectRender.material.color = Color.Lerp(objectRender.material.color, color, ctime / time);

                ctime += Time.deltaTime;

                yield return null;
            }

            objectRender.material.color = color;
        }

        void ResetColor()
        {
            objectRender.material = startMat;
            GetComponent<MeshRenderer>().enabled = false;
        }

        private void OnMouseEnter()
        {
            if(EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }


            if (bulidManager.CannotBuild)
            {
                return;
            }

            if (myTurret == null && bulidManager.isSelect == true)
            {
                objectRender.material = hovermaterial;
                GetComponent<MeshRenderer>().enabled = true;
            }
            else 
            {
                objectRender.material.color = notenoughColor;
            }
            

            // 선택한 터렛을 건설할 비용을 가지고 있는지 잔고 확인
            if (bulidManager.HasBuildMoeny == false)
            {
                objectRender.material.color = notenoughColor;
            }


            
        }

        private void OnMouseExit()
        {
            ResetColor();
        }

        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            
            if (myTurret != null)
            {
                //Debug.Log("타일 UI보여주기");
                bulidManager.SelectTile(this);
                return;
            }

            if(bulidManager.CannotBuild)
            {
                Debug.Log("터렛을 설치하지 못했습니다.!!");
                return;
            }

            BuildTurret();

        }

        void BuildTurret()
        {
            bluePrint = bulidManager.GetTurretToBuild();

            if (myTurret == null && bulidManager.isSelect == true)
            {
                if (PlayerStats.UseMoney(bluePrint.bulidcost))
                {
                    myTurret = Instantiate(bluePrint.TurretPrefab, GetBuildPos(), Quaternion.identity);

                    Transform effect = Instantiate(buildEffect, GetBuildPos(), Quaternion.identity); ;

                    Destroy(effect.gameObject, 2f);

                    ResetColor();
                }
            }
        }

        // 터렛 설치 위치
        public Vector3 GetBuildPos()
        {
            return transform.position + bluePrint.offset;
        }

        public void UpgradeTurret()
        {
            if (bluePrint == null)
            {
                Debug.Log("오류");
                return;
            }

            if (PlayerStats.UseMoney(bluePrint.upgradecost))
            {
                IsUpgrade = true;

                Destroy(myTurret.gameObject);

                myTurret = Instantiate(bluePrint.TurretUpgrade, GetBuildPos(), Quaternion.identity);

                Transform effect = Instantiate(buildEffect, GetBuildPos(), Quaternion.identity);

                Destroy(effect.gameObject, 2f);

                ResetColor();
            }
        }

        public void SellTurret()
        {
            int sellMoney;

            if (IsUpgrade == true)
            {
                sellMoney = bluePrint.GetSellCost_UP();
            }
            else
            {
                sellMoney = bluePrint.GetSellCost();
            }

            Transform effect = Instantiate(sellEffect, GetBuildPos(), Quaternion.identity);

            Destroy(myTurret.gameObject);
            Destroy(effect.gameObject, 2f);

            bluePrint = null;
            myTurret = null;
            IsUpgrade = false;

            PlayerStats.SaveGold(sellMoney);
        }
    }
}