using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Solid
{
    public class CircleEffect : AreaOfEffect
    {
        [Header("Shape")]
        [Tooltip("The radius of the circle")]
        [SerializeField] float m_Radius;

        public float Radius { get => m_Radius; set => m_Radius = value; }

        public override float CalculateArea()
        {
            return Radius * Radius * Mathf.PI;
        }

    }
}
