using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace MyDefence
{
    public class LootAtCamera : MonoBehaviour
    {
        private Camera mainCamera;



        void Start()
        {
            mainCamera = Camera.main;
        }


        void Update()
        {
            transform.LookAt(mainCamera.transform.position);
        }
    }
}
