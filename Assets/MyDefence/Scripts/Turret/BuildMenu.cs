using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace MyDefence
{

    public class BuildMenu : MonoBehaviour
    {
        private BulidManager m_Manage;

        public TurretBlueprint defultTurret;
        public TurretBlueprint bigTurret;
        public TurretBlueprint missileTurret;
        public TurretBlueprint laserBeamer;

        private void Start()
        {
            Init();
        }

        void Init()
        {
            m_Manage = BulidManager.instance;
        }

        public void SelectBasicTurret()
        {
            m_Manage.SetTurret(defultTurret);
        }
        public void SelectAnotherTurret()
        {
            m_Manage.SetTurret(bigTurret);
        }
        public void SelectMissileTurret()
        {
            m_Manage.SetTurret(missileTurret);
        }

        public void SelectLaserBeamer()
        {
            m_Manage.SetTurret(laserBeamer);
        }

    }
}
