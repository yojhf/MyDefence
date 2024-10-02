using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



namespace MyDefence
{
    // ���� �޴����� ���õǴ� �ͷ��� �Ӽ��� �����ϴ� Ŭ����
    [Serializable]
    public class TurretBlueprint
    {
        public Transform TurretPrefab; // �ͷ� ������
        public Transform TurretUpgrade;
        public int bulidcost; // ���� �ڽ�Ʈ      
        public int upgradecost; // ���� �ڽ�Ʈ      
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
