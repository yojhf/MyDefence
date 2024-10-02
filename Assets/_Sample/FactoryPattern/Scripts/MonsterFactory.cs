using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Factory
{
    public class MonsterFactory
    {
        public Monster MonType(MonsterType type)
        {
            switch (type)
            {
                case MonsterType.M_Slime:
                    return new Slime();
                case MonsterType.M_Zombie:
                    return new Zombie();

            }

            return null;
        }
    }
}
