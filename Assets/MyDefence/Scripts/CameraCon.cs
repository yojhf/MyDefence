using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyDefence
{
    public class CameraCon : MonoBehaviour
    {
        public float speed = 100f;

        // 경계범위 
        public float border = 10f;

        private bool isLock = false;

        public float ZoomSpeed = 10f;

        public float minZoom = 30f;
        public float maxZoom = 125f;

        void Start()
        {
            
        }


        void Update()
        {
            if(GameManager.IsGameOver)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isLock = !isLock;
            }


            if (isLock)
            {
                return;
            }

            //if (isLock == false && Input.GetKeyDown(KeyCode.Escape))
            //{
            //    isLock = true;
            //}
            //else if (isLock == true && Input.GetKeyDown(KeyCode.Escape))
            //{
            //    isLock = false;
            //}

            if (isLock == false)
            {
                KeyCon();
                CameraZoom();
                Zoom();
            }

        }


        void KeyCon()
        {
            Vector3 movePos = Vector3.zero;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                movePos = Vector3.forward;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                movePos = Vector3.back;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                movePos = Vector3.left;

            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                movePos = Vector3.right;
            }

            // 마우스 위치값을 받아와서 맵 스크롤
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            if (mouseY >= (Screen.height - border) && mouseY < Screen.height)
            {
                movePos = Vector3.forward;
            }            
            if (mouseY >= 0 && mouseY < border)
            {
                movePos = Vector3.back;
            }

            if (mouseX >= (Screen.width - border) && mouseX < Screen.width)
            {
                movePos = Vector3.right;
            }
            if (mouseX >= 0 && mouseX < border)
            {
                movePos = Vector3.left;
            }

            transform.position += movePos * speed * Time.deltaTime;

        }

        void Zoom()
        {
            float wheel = Input.GetAxisRaw("Mouse ScrollWheel");

            if(wheel > 0)
            {
                ZoomOut();

            }
            else if(wheel < 0)
            {
                ZoomIn();
            }
            
        }


        private void CameraZoom()
        {        
            if (Input.GetKey(KeyCode.Z))
            {
                ZoomIn();
            }
            else if (Input.GetKey(KeyCode.X))
            {
                ZoomOut();
            }
        }

        public void ZoomIn()
        {
            Camera.main.fieldOfView += ZoomSpeed * Time.deltaTime;
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minZoom, maxZoom);
        }
        public void ZoomOut()
        {
            Camera.main.fieldOfView -= ZoomSpeed * Time.deltaTime;
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minZoom, maxZoom);
        }
    }
}
