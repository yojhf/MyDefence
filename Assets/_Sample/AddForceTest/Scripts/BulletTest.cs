using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class BulletTest : MonoBehaviour
    {
        public float force = 140f;
        private Rigidbody rb;

        private void Start()
        {

        }

        public void MoveForward()
        {
            //transform.Translate(transform.forward * Time.deltaTime * 50f, Space.World);
        }

        public void MoveByForce()
        {
            rb = GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * force, ForceMode.Impulse);
        }
    }
}
