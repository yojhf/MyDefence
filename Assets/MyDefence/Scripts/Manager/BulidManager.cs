using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace MyDefence
{
    // 터렛 건설을 관리하는 클래스
    public class BulidManager : MonoBehaviour
    {
        public static BulidManager instance;

        // 타일에 설치할 터렛의 정보 (프리펩, 가격정보)
        private TurretBlueprint turretToBuild;

        // 선택한 터렛이 있는지, 선택 안했으면 건설 못함
        public bool CannotBuild => turretToBuild == null;

        // 선택한 터렛을 건설한 비용을 가지고 있는지
        public bool HasBuildMoeny
        {
            get 
            { 
                if (turretToBuild == null)
                {
                    return false;
                  
                }

                return PlayerStats.HasMoney(turretToBuild.bulidcost);

            }
        }

        Color randomColor;

        public bool isSelect = false;

        public TileUI tileUI;
        private Tile selectTile;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        public TurretBlueprint GetTurretToBuild()
        {
            return turretToBuild;
        }

        public Color TileColor()
        {
            randomColor = Random.ColorHSV();

            return randomColor;
        }

        //public void ChangeTurret_D()
        //{
        //    isSelect = true;
        //    Debug.Log("기본 터렛을 선택 하였습니다!!");
        //    turretToBuild = defultTurret;
        //}
        //public void ChangeTurret_B()
        //{
        //    isSelect = true;
        //    Debug.Log("다른 터렛을 선택 하였습니다!!");
        //    turretToBuild = bigTurret;
        //}



        //public void SetTurret(Transform turret, int cost)
        //{
        //    isSelect = true;

        //    turretToBuild = turret;
        //    bulidCost = cost;
        //}

        public void SetTurret(TurretBlueprint turret)
        {
            isSelect = true;

            turretToBuild = turret;

            DeselectTile();
        }

        public void SelectTile(Tile tile)
        {
            // 같은 타일을 선택하면 HideUI
            if (selectTile == tile)
            {
                DeselectTile();
                return;
            }


            selectTile = tile;

            // 저장된 터렛 속성을 초기화
            turretToBuild = null;
            tileUI.ShowTileUI(tile);
        }

        // 선택 해제
        public void DeselectTile()
        {
            tileUI.HideTileUI();
            selectTile = null;
        }

    }
}