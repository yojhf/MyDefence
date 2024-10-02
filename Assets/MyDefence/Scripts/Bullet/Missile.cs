using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyDefence
{
    public class Missile : Bullet
    {
        public float damageRange = 3.5f;
        private string enemyTag = "Enemy";

        protected override void HitTarget()
        {
            GameObject be = Instantiate(b_Effect, target.position, Quaternion.identity);
            Destroy(be, 2f);

            // �ݰ� 3.5�ȿ� �ִ� ��� ������ ������ �԰� kill
            Explosion();

            Destroy(gameObject);  
        }

        void Explosion()
        {
            Collider[] hitEnmies = Physics.OverlapSphere(transform.position, damageRange);


            foreach (var enmies in hitEnmies)
            {

                IDamgeable damgeable = enmies.GetComponent<IDamgeable>();

                if (damgeable != null)
                {
                    Damage(enmies.transform);
                }
            }

        }

        private void OnDrawGizmosSelected()
        {
            if (transform == null)
            {
                return;
            }

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, damageRange);
        }
    }
}
