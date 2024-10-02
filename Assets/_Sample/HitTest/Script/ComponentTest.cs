using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class ComponentTest : MonoBehaviour
    {
        [SerializeField] private Transform target;

        public TargetTest cTarget;
        public float moveSpeed = 5f;

        // Start is called before the first frame update
        void Start()
        {
            // ¹®¹ý
            //TargetTest tt = new TargetTest();
            //tt.b = 30;

            TargetTest tt = target.GetComponent<TargetTest>();
            
            Material mt = target.GetComponent<MeshRenderer>().material;
            Material mymt = transform.GetComponent<MeshRenderer>().material;

            mymt.color = Color.black;
            mt.color = Color.red;

            tt.b = 30;
            moveSpeed = tt.GetA();

            TargetTest gt2 = target.gameObject.GetComponent<TargetTest>();

           gt2.b = 100;

            Debug.Log(cTarget.GetA()); 



        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        void Move()
        {
            Vector3 dir = target.position - transform.position;

            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
        }
    }
}