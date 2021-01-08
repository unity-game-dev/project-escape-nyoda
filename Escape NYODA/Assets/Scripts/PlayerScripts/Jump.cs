using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectNyodaToolkit
{

    public class Jump : Abilities
    {
        [SerializeField]
        protected float jumpForce;
        [SerializeField]
        protected float distanceToCollider;
        [SerializeField]
        protected LayerMask collisionLayer;

        private bool isJumping;

        // Update is called once per frame
        protected virtual void Update()
        {
            checkForJump();
        }

        protected virtual bool checkForJump()
        {
            if (input.JumpPressed())
            {
                isJumping = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        protected virtual void FixedUpdate()
        {
            Jumping();
            GroundCheck();
        }

        protected virtual void Jumping()
        {
            if (!player.isGrounded)
            {
                isJumping = false;
                //anim.SetBool("Jumping", false);
                return;
            }
            if (isJumping)
            {
                rb.AddForce(Vector2.up * jumpForce);
                anim.SetBool("Jumping", true);
                
            }
            if (!isJumping)
            {
                anim.SetBool("Jumping", false);
            }
        }

        protected virtual void GroundCheck()
        {
            if(CollisionCheck(Vector2.down, distanceToCollider, collisionLayer))
            {
                player.isGrounded = true;
            } else
            {
                player.isGrounded = false;
            }
        }
    }
}
