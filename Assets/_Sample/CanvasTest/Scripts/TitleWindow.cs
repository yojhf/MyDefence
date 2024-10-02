using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Sample
{
    public class TitleWindow : MonoBehaviour
    {
        public Vector2 range = new Vector2(0f, 0f);
        public float dur = 5f;

        private Transform m_Trans;
        private Quaternion m_Start;
        private Vector2 m_Rot;

        void Start()
        {
            m_Trans = transform;
            m_Start = m_Trans.localRotation;

        }


        void Update()
        {
            UICon();
        }

        void UICon()
        {
            Vector3 pos = Input.mousePosition;

            float halfWidth = Screen.width * 0.5f;
            float halfHeight = Screen.height * 0.5f;

            float x = Mathf.Clamp((pos.x - halfWidth) / halfWidth, -1f, 1f);
            float y = Mathf.Clamp((pos.y - halfHeight) / halfHeight, -1f, 1f);

            m_Rot = Vector2.Lerp(m_Rot, new Vector2(x,y), Time.deltaTime * dur);

            m_Trans.localRotation = m_Start * Quaternion.Euler( -m_Rot.y * range.y, m_Rot.x * range.x, 0f);

        }
    }
}
