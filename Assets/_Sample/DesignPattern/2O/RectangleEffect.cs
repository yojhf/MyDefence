using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Solid
{
    public class RectangleEffect : AreaOfEffect
    {
        [Header("Shape")]
        [Tooltip("The width fo the rectangle")]
        [SerializeField] private float m_Width;
        [Tooltip("The height fo the rectangle")]
        [SerializeField] private float m_Height;

        public override float CalculateArea()
        {
            return m_Width * m_Height;
        }
    }
}
