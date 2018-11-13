using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerController))]
    public class PlayerMovement : MonoBehaviour
    {

        private PlayerController controller;
        private void Start()
        {
            controller = GetComponent<PlayerController>();
        }

        public int moveSpeed = 50;
        private void FixedUpdate()
        {

            var moveDirection = Input.GetAxisRaw("Horizontal");
            controller.rb.velocity = new Vector2(moveDirection * moveSpeed, controller.rb.velocity.y);

            if (controller.isGrounded)
            {
                if (moveDirection != 0)
                {
                    controller.playerAnimator.SetBool("IsWalking", true);
                }
                else
                {
                    controller.playerAnimator.SetBool("IsWalking", false);
                }
            }

            if (facingRight == false && moveDirection > 0)
            {
                Flip();
            }
            else if (facingRight == true && moveDirection < 0)
            {
                Flip();

            }

        }

        private bool facingRight = true;
        private void Flip()
        {
            facingRight = !facingRight;
            var localScaler = transform.localScale;
            localScaler.x *= -1;
            transform.localScale = localScaler;
        }

    }
}