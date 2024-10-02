using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace NewSample
{
    public class CameraCon : MonoBehaviour
    {
        private MyInputAction myinputAct;

        public float moveSpeed = 10f;

        Vector2 inputVector;

        Vector2 mousePos;

        public float border = 10f;
        public float zoomSpeed = 10f;

        void Awake()
        {
            myinputAct = new MyInputAction();
        }

        private void OnEnable()
        {
            myinputAct.CameraCon.Enable();
        }

        private void OnDisable()
        {
            myinputAct.CameraCon.Disable();
        }

        void Update()
        {
            // Camera move

            inputVector = myinputAct.CameraCon.Move.ReadValue<Vector2>();

            Vector3 dir = new Vector3(inputVector.x, 0f, inputVector.y);

            transform.Translate(dir * moveSpeed * Time.deltaTime, Space.World);


            // 마우스 위치 가져 오기
            mousePos = myinputAct.CameraCon.MousePos.ReadValue<Vector2>();

            Vector2 mPos = Mouse.current.position.ReadValue();

            if (mousePos.y >= (Screen.height - border) && mousePos.y < Screen.height)
            {
                mousePos = Vector3.forward;
                transform.Translate(mousePos * moveSpeed * Time.deltaTime);
            }
            if (mousePos.y >= 0 && mousePos.y < border)
            {
                mousePos = Vector3.back;
                transform.Translate(mousePos * moveSpeed * Time.deltaTime);
            }

            if (mousePos.x >= (Screen.width - border) && mousePos.x < Screen.width)
            {
                mousePos = Vector3.right;
                transform.Translate(mousePos * moveSpeed * Time.deltaTime);
            }
            if (mousePos.x >= 0 && mousePos.x < border)
            {
                mousePos = Vector3.left;
                transform.Translate(mousePos * moveSpeed * Time.deltaTime);
            }

            

            // 휠 스크롤
            Vector2 scroll = Mouse.current.scroll.ReadValue();

            Vector3 zoomMove = transform.position;

            //zoomMove.y -= (scroll * 100f) * Time.deltaTime * zoomSpeed;

            zoomMove.y = Mathf.Clamp(zoomMove.y, 20f, 70f);

            transform.position = new Vector3(0f, zoomMove.y, 0f);


        }


        // Unity Event 메서드 등록 실행
        public void CameraMove(InputAction.CallbackContext context)
        {
            inputVector = context.ReadValue<Vector2>();
        }

        public void CameraMouse(InputAction.CallbackContext context)
        {
            mousePos = context.ReadValue<Vector2>();
        }

        // SendMessage 이벤트 함수 이름 On + 기능 이름
        public void OnMove(InputValue value)
        {
            inputVector = value.Get<Vector2>();
        }

        public void OnMousePos(InputValue value)
        {
            mousePos = value.Get<Vector2>();
        }


    }
}
