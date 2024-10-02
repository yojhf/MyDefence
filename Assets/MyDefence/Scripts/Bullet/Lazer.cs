using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace MyDefence
{
    public class Lazer : Bullet
    {

        private float damage;
        [SerializeField] private float s_damage = 10f;

        protected override void HitTarget()
        {

        }

        IEnumerator LazerAtk()
        {
            float ctime = 1.5f;
            float time = 0;

            while(time < ctime)
            {


                ctime += Time.deltaTime;

                yield return null;
            }


        }
    }
}
