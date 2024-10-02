using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Factory
{
    public interface IMonsterFactory
    {
       public Monster CreatMonster();
    }

    public class SlimeFactory : IMonsterFactory
    {
        public Monster CreatMonster()
        {
            return new Slime();
        }
    }
    public class ZombieFactory : IMonsterFactory
    {
        public Monster CreatMonster()
        {
            return new Zombie();
        }
    }
    public class GoblinFactory : IMonsterFactory
    {
        public Monster CreatMonster()
        {
            return new Goblin();
        }
    }
}
