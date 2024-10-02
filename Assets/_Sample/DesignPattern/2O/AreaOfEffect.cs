using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid
{
    public abstract class AreaOfEffect : MonoBehaviour
    {
        public float TotalArea => CalculateArea();

        public abstract float CalculateArea();

        public void PlayEffect()
        {
            //...
        }

        private void PlayParticleEffect()
        {
            //...
        }
    }
}
