using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class MoveS : MonoBehaviour
    {
        public float moveSpeed = 1.0f;

        void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        }
    }
}
