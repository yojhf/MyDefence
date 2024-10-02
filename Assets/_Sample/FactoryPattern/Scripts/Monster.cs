using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Factory
{
    // ���� Ÿ��
    public enum MonsterType
    {
        M_Slime,
        M_Zombie,
        M_Goblin,
    }

    public abstract class Monster
    {
        // ���� ���� ��� ����
        public abstract void Attack();
    }

    public class Slime : Monster 
    {
        public override void Attack() { Debug.Log("atk slime"); }
    }

    public class Zombie : Monster
    {
        public override void Attack() { Debug.Log("atk zombie"); }
    }

    public class Goblin : Monster
    {
        public override void Attack() { Debug.Log("atk Goblin"); }
    }

}
