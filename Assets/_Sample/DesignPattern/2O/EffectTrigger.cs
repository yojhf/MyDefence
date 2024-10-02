using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Solid
{
    public class EffectTrigger : MonoBehaviour
    {
        public AreaOfEffect m_Effect;

        private void Start()
        {
            Debug.Log(m_Effect.CalculateArea());
        }

        private void OnTriggerEnter(Collider other)
        {
            // ¿Ã∆Â∆Æ Ω««‡
            PlayEffect(other);
        }

        private void PlayEffect(Collider other)
        {
           if(other.CompareTag("Player"))
            {
                m_Effect.PlayEffect();
            }
        }
    }
}
