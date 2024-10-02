using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


namespace MyDefence
{
    public class TileUI : MonoBehaviour
    {
        public Transform tileUI;

        public TMP_Text cost_Text;
        public TMP_Text sellcost_Text;

        private Tile targetTile;

        private BulidManager bulidManager;

        public Button upgrade_btn;

        private void Start()
        {
            bulidManager = BulidManager.instance;

           
        }

        //private void Update()
        //{
        //    transform.LookAt(Camera.main.transform.position);
        //}

        public void ShowTileUI(Tile tile)
        {
            targetTile = tile;

            // 터렛이 설치된 위치에서 보여준다
            transform.position = targetTile.GetBuildPos();

            tileUI.gameObject.SetActive(true);

            tileUI.GetComponent<Animator>().Play("TileUIOpenAnime");

            if (targetTile.IsUpgrade == true)
            {
                cost_Text.text = "UPGRADE\n" + "DONE";
                sellcost_Text.text = "SELL\n" + targetTile.bluePrint.GetSellCost_UP().ToString() + "G";
                upgrade_btn.interactable = false;
            }
            else
            {
                cost_Text.text = "UPGRADE\n" + targetTile.bluePrint.upgradecost.ToString() + "G";
                sellcost_Text.text = "SELL\n" + targetTile.bluePrint.GetSellCost().ToString() + "G";
                upgrade_btn.interactable = true;
            }




        }

        public void HideTileUI()
        {
            targetTile = null;
            tileUI.gameObject.SetActive(false);
        }

        public void Upgrade()
        {
            targetTile.UpgradeTurret();
            bulidManager.DeselectTile();
            HideTileUI();
        }
        public void Sell()
        {
            targetTile.SellTurret();
            HideTileUI();
            bulidManager.DeselectTile();
        }
    }
}
