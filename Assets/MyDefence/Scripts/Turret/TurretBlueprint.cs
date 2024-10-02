using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



namespace MyDefence
{
    // 빌드 메뉴에서 선택되는 터렛의 속서을 관리하는 클래스
    [Serializable]
    public class TurretBlueprint
    {
        public Transform TurretPrefab; // 터렛 프리펩
        public Transform TurretUpgrade;
        public int bulidcost; // 빌드 코스트      
        public int upgradecost; // 빌드 코스트      
        public Vector3 offset;

        public int GetSellCost()
        {
            return bulidcost / 2;
        }

        public int GetSellCost_UP()
        {
            return (bulidcost + upgradecost) / 2;
        }
    }
}
