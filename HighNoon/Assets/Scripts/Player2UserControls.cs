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
        public Animator animate;
        private hatThrow hatThrow;

        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool m_Throw;

        public AudioSource source;
        public AudioClip jumpSFX;

        private float attackTimer;

        public Transform FirePoint;

        private void Start()
        {
            
        }

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            animate = gameObject.GetComponent<Animator>();
            FirePoint = m_Character.m_FirePoint;
            hatThrow = FindObjectOfType<hatThrow>();
            source.clip = jumpSFX;
            source.enabled = true;
        }

        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = Input.ButtonIsDown(PlayerInput.Button.A);
                if(m_Jump)
                {
                    source.Play();
                }
                //Debug.Log("JUMP AM: " + Input.controllerNumber);
            }
            attackTimer += Time.deltaTime;
            m_Throw = Input.ButtonIsDown(PlayerInput.Button.B);
            if (m_Throw)
            {      

                if(hatThrow.UpdateHatThrow(PlayerNumber))
                {
                    animate.SetBool("isAttacking", true);
                    attackTimer = 0;
                }
            }
            if (attackTimer >= 0.25f)
            {
                attackTimer = 0;
                animate.SetBool("isAttacking", false);
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            //bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = Input.Horizontal;
            if (h != 0)
            {
                animate.SetBool("run", true);
            }
            else
            {
                animate.SetBool("run", false);
            }
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
