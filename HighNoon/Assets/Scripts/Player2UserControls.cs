using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Player2UserControls : MonoBehaviour
    {
        public PlayerControl player { get; private set; }
        public int PlayerNumber { get; private set; }
        public PlayerInput Input { get; private set;}

        private PlatformerCharacter2D m_Character;
        private bool m_Jump;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = Input.ButtonIsDown(PlayerInput.Button.A);
                //Debug.Log("JUMP AM: " + Input.controllerNumber);
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            //bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = Input.Horizontal;
            // Pass all parameters to the character control script.
            m_Character.Move(h, m_Jump);
            m_Jump = false;
        }

        public void SetPlayer(PlayerControl player)
        {
            this.player = player;
            PlayerNumber = player.PlayerNumber;
            Input = player.GetComponent<PlayerInput>();

            // If a text or indicator was wanted Place it in children
            //if(GetComponentInChildren<player>)
        }
    }
}
