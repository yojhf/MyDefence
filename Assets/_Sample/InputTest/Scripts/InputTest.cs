using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Linq;

namespace Sample
{
    public class InputTest : MonoBehaviour
    {
        public float speed = 100f;
        public float jumpPower = 50f;
        public TMP_Text xText;
        public TMP_Text yText;

        void Start()
        {
            Debug.Log($"Screen Width : {Screen.width}");
            Debug.Log($"Screen Height : {Screen.height}");
        }


        void Update()
        {
            KeyCon();
            KeyTest();
        }


        void KeyCon()
        {
            Vector3 movePos = Vector3.zero;

            if(Input.GetKey(KeyCode.W))
            {
                movePos = Vector3.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movePos = Vector3.back;
            }
            if (Input.GetKey(KeyCode.A))
            {
                movePos = Vector3.left;
         
            }
            if (Input.GetKey(KeyCode.D))
            {
                movePos = Vector3.right;
            }


            transform.position += movePos * speed * Time.deltaTime;
        }

        void KeyTest()
        {
            Vector3 movePos = Vector3.zero;

            //if (Input.GetButton("Jump"))
            //{
            //    Debug.Log("점프");
            //}
            if (Input.GetButtonDown("Jump"))
            {
                movePos = Vector3.up;
                Debug.Log("점프");
            }

            transform.position += movePos * jumpPower * Time.deltaTime;


            if(Input.GetButton("Horizontal"))
            {
                float hvalue = Input.GetAxis("Horizontal");
                float hrvalue = Input.GetAxisRaw("Horizontal");

                if (hvalue > 0 )
                {
                    Debug.Log("오른쪽 : " + hrvalue);
                }
                else if(hvalue < 0)
                {
                    Debug.Log("왼쪽 : " + hrvalue);
                }
            }


            if (Input.GetButton("Vertical"))
            {
                float vValue = Input.GetAxis("Vertical");
                float vrValue = Input.GetAxisRaw("Vertical");

                if (vValue > 0)
                {
                    Debug.Log("앞쪽 : " + vrValue);
                }
                else if (vValue < 0)
                {
                    Debug.Log("뒤쪽 : " + vrValue);
                }
            }

            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            xText.text = "X : " + ((int)mouseX).ToString() + " / " + "Y : " + ((int)mouseY).ToString();



            xText.rectTransform.position = new Vector2(mouseX, mouseY + 50f);
            //yText.rectTransform.position = new Vector2(mouseX, mouseY - 50f);




            Vector3 pos = Input.mousePosition;

            if (Input.GetMouseButton(0))
            {        
                Debug.Log(pos);
            }
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(pos);
            }
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log(pos);
            }


        }
    }
}
