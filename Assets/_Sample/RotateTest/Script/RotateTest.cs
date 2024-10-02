using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Sample
{
    public class RotateTest : MonoBehaviour
    {
        [SerializeField] private Transform target;

        public float speed = 200f;
        private float x = 0f;
        private float y = 90f;

        Vector3 dir;
        Quaternion targetRotation;

        // Start is called before the first frame update
        void Start()
        {
            //transform.rotation = Quaternion.Euler(90f, 0f, 0f);

            //transform.rotation = Quaternion.Euler(0f, -90f, 0f);

            //transform.rotation = Quaternion.Euler(0f, 0f, 90f);


        }

        // Update is called once per frame
        void Update()
        {
           

            x += 1f;

            //transform.rotation = Quaternion.Euler(0f, x, 0f);

            //transform.rotation = Quaternion.Euler(0f, -x, 0f);

            //transform.rotation = Quaternion.Euler(x, 0f, 0f);

            //transform.rotation = Quaternion.Euler(0f, 0f, x);

            // 이동함수
            //transform.Rotate(Vector3.back * Time.deltaTime * speed); // (0, speed, 0)

            // 지구공전 구현 함수
            target.RotateAround(transform.position, Vector3.up, Time.deltaTime * speed); // (0, speed, 0)

            dir = target.position - transform.position;

            targetRotation = Quaternion.LookRotation(dir);

            Vector3 yRot = targetRotation.eulerAngles;

            Quaternion targetRot = Quaternion.Euler(transform.rotation.x, yRot.y, transform.rotation.z);

            // Lerp 함수
            //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * speed);

            // Lerp 함수
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * speed);

            //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * speed);
        }
    }

}

/*
Lerp(a, b, t)
a = 0, b = 10
c = Lerp(a, b, 0.1) // c = 1
c = Lerp(a, b, 0.2) // 2
c = Lerp(a, b, 0.3) // 3
c = Lerp(a, b, 0.4) // 4
c = Lerp(a, b, 0.5) // 5
c = Lerp(a, b, 0.6) // 6
...
c = Lerp(a, b, 1) // 10

//
a = 0, b = 10
a = Lerp(a, b, 0.1) // a = 1
a = Lerp(a, b, 0.1) // a = 1.9
a = Lerp(a, b, 0.1) // a = 2.71
*/
