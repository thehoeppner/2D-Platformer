using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerController))]
    public class PlayerJumping : MonoBehaviour
    {

        private PlayerController controller;
        void Start()
        {
            controller = GetComponent<PlayerController>(); 
            extraJumps = extraJumpsCount;
        }

        private void FixedUpdate()
        {
            Jumping();
        }


        public float jumpForce;
        private int extraJumps;
        public int extraJumpsCount = 1;
        private bool isJumping;
        private void Jumping()
        {
            if (controller.isGrounded)
            {
                extraJumps = extraJumpsCount;
                if (isJumping && controller.rb.velocity.y < jumpForce - 1)
                {
                    isJumping = false;
                    controller.playerAnimator.SetBool("IsJumping", false);
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
            {
                controller.rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
                controller.playerAnimator.SetBool("IsJumping", true);
                isJumping = true;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && controller.isGrounded)
            {
                controller.rb.velocity = Vector2.up * jumpForce;
                controller.playerAnimator.SetBool("IsJumping", true);
                isJumping = true;
            }
        }
    }
}