using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectNyodaToolkit
{
    [RequireComponent (typeof(BoxCollider2D))]
    public class Crouch : Abilities
    {
        [SerializeField] [Range(0, 1)] protected float colliderMultiplier;
        private BoxCollider2D playerCollider;
        private Vector2 originalCollider;
        private Vector2 crouchingColliderSize;
        private Vector2 originalOffset;
        private Vector2 crouchingOffset;
        // Start is called before the first frame update

        protected override void Initialization()
        {
            base.Initialization();
            playerCollider = GetComponent<BoxCollider2D>();
            originalCollider = playerCollider.size;
            crouchingColliderSize = new Vector2(playerCollider.size.x, (playerCollider.size.y * colliderMultiplier));
            originalOffset = playerCollider.offset;
            crouchingOffset = new Vector2(originalOffset.x, crouchingColliderSize.y*-.5f);
        }

        protected virtual void FixedUpdate()
        {
            
            Crouching();
        }

        

        protected virtual void Crouching()
        {
            if(input.CrouchHeld() && player.isGrounded)
            {
                player.isCrouching = true;
                anim.SetBool("Crouching", true);
                playerCollider.size = crouchingColliderSize;
                playerCollider.offset = crouchingOffset;
            } else
            {
                if (player.isCrouching)
                {
                    StartCoroutine(CrouchDisabled());
                }
            }
        }

        protected virtual IEnumerator CrouchDisabled()
        {
            playerCollider.offset = originalOffset;
            yield return new WaitForSeconds(.01f);
            playerCollider.size = originalCollider;
            yield return new WaitForSeconds(.15f);
            player.isCrouching = false;
            anim.SetBool("Crouching", false);
        }
    }
}

