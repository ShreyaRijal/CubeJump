using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        public int coinScore = 0;
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        public float h = 0f;
        public float speed = 40f;



        private void Update()
        {
            h= Input.GetAxisRaw("Horizontal") * speed;
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump")||Input.GetKeyDown(KeyCode.Space);
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.

            // Pass all parameters to the character control script.
            m_Character.Move(h * Time.fixedDeltaTime, false, m_Jump);
            m_Jump = false;
        }
    }
}
