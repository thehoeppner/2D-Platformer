using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
    public class PlayerController : MonoBehaviour {

        [HideInInspector]
        public Rigidbody2D rb;
        public Animator playerAnimator;
        void Start() {
            rb = GetComponent<Rigidbody2D>();
        }

        public bool isGrounded;
        public Transform groundCheck;
        public float groundCheckRadius;
        public LayerMask groundMask;
        private void GroundCheck()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
        }

        private void FixedUpdate()
        {
            GroundCheck();
        }

    }
}