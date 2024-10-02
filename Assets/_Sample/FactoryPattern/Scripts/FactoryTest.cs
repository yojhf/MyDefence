using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Factory
{
    public class FactoryTest : MonoBehaviour
    {

        void Start()
        {
            // 슬라임 생성 => 슬라임 공격
            // 좀비 생성 => 좀비 공격
            Monster slm = MonType(MonsterType.M_Slime);
            slm.Attack();

            Monster zom = MonType(MonsterType.M_Zombie);
            zom.Attack();


            ///
            MonsterFactory monsterFactory = new MonsterFactory();
            Monster s = monsterFactory.MonType(MonsterType.M_Slime);
            s.Attack();

            Monster z = monsterFactory.MonType(MonsterType.M_Zombie);
            z.Attack();

            SlimeFactory slimeFactory = new SlimeFactory();
            Monster monsterS = slimeFactory.CreatMonster();
            monsterS.Attack();

            ZombieFactory zombieFactory = new ZombieFactory();
            Monster monsterZ = zombieFactory.CreatMonster();
            monsterZ.Attack();

            GoblinFactory goblinFactory = new GoblinFactory();
            Monster monsterG = goblinFactory.CreatMonster();
            monsterG.Attack();



        }


        void Update()
        {
            
        }

        Monster MonType(MonsterType type)
        {
            switch(type)
            {
                case MonsterType.M_Slime : 
                    return new Slime();
                case MonsterType.M_Zombie:
                    return new Zombie();

            }

            return null;       
        }
    }
}
