using Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class StaticClass : MonoBehaviour
    {

        public static StaticClass instance;

        public static int number;
        public int num;

        private void Awake()
        {
            

            instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}