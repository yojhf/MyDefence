using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid
{
    public class Player : MonoBehaviour
    {

        PlayerInput m_PlayerInput;
        PlayerMove m_PlayerMovement;
        PlayerAudio m_PlayerAudio;
        PlayerFX m_PlayerFX;

        private void Awake()
        {
            Initialize();
        }

        void Start()
        {

        }


        void Update()
        {

        }

        // Sets up component references.
        private void Initialize()
        {
            m_PlayerInput = GetComponent<PlayerInput>();
            m_PlayerMovement = GetComponent<PlayerMove>();
            m_PlayerAudio = GetComponent<PlayerAudio>();
            m_PlayerFX = GetComponent<PlayerFX>();
        }
    }
}
