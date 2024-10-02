using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid
{
    public class UnrefactoredPlayer : MonoBehaviour
    {


        [Header("Movement")]
        [Tooltip("Horizontal speed")]
        [SerializeField] private float moveSpeed = 5f;
        [Tooltip("Rate of change for move speed")]
        [SerializeField] private float acceleration = 10f;
        [Tooltip("Deceleration rate when no input is provided")]
        [SerializeField] private float deceleration = 5f;

        [Header("Controls")]
        [Tooltip("Use WASD keys to move")]
        [SerializeField] private KeyCode forwardKey = KeyCode.W;
        [SerializeField] private KeyCode backwardKey = KeyCode.S;
        [SerializeField] private KeyCode leftKey = KeyCode.A;
        [SerializeField] private KeyCode rightKey = KeyCode.D;

        private Vector3 inputVector;
        private float currentSpeed = 0f;
        private CharacterController charController;
        private float initialYPosition;

        void Awake()
        {
            charController = GetComponent<CharacterController>();
            initialYPosition = transform.position.y;
        }


        void Update()
        {
            HandleInput();
            Move(inputVector);
        }

        private void HandleInput()
        {
            // Reset input vector
            float xInput = 0;
            float zInput = 0;

            if (Input.GetKey(forwardKey))
                zInput++;
            if (Input.GetKey(backwardKey))
                zInput--;
            if (Input.GetKey(leftKey))
                xInput--;
            if (Input.GetKey(rightKey))
                xInput++;

            inputVector = new Vector3(xInput, 0, zInput);
        }

        private void Move(Vector3 inputVector)
        {
            if (inputVector == Vector3.zero)
            {
                if (currentSpeed > 0)
                {
                    currentSpeed -= deceleration * Time.deltaTime;
                    currentSpeed = Mathf.Max(currentSpeed, 0);
                }
            }
            else
            {
                currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed, Time.deltaTime * acceleration);
            }

            Vector3 movement = inputVector.normalized * currentSpeed * Time.deltaTime;
            charController.Move(movement);
            transform.position = new Vector3(transform.position.x, initialYPosition, transform.position.z);
        }

        public void PlayRandomAudioClip()
        {
            //......
        }

        public void PlayEffect()
        {
            //..... 
        }
    }
}
