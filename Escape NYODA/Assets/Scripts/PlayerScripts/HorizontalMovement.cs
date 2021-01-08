using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectNyodaToolkit
{
    public class HorizontalMovement : Abilities
    {
        [SerializeField] protected float timeTillMaxSpeed;
        [SerializeField] protected float maxSpeed;
        [SerializeField] protected float sprintMultiplier;
        [SerializeField] protected float crouchSpeedMultiplier;
        private float acceleration;
        private float currentSpeed;
        //stores either 1 or -1
        private float horizontalInput;
        //no. of seconds the player is moving
        private float runTime;

        //overriding Initialization of player script inherited from abilities
        protected override void Initialization()
        {
            base.Initialization();
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            MovementPressed();
        }

        //method for if a/d or left/right keys are pressed or not. If pressed store in horizontalInput
        protected virtual bool MovementPressed()
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                horizontalInput = Input.GetAxis("Horizontal");
                return true;
            } else
            {
                return false;
            }
        }

        //method for if sprinting when keys held
        

        //runs all movement
        protected virtual void FixedUpdate()
        {
            Movement();
        }

        //handles Movement on MovementPressed return value
        protected virtual void Movement()
        {
            if (MovementPressed())
            {
                anim.SetBool("Moving", true);
                acceleration = maxSpeed / timeTillMaxSpeed;
                //smoothing across all frames
                runTime += Time.deltaTime;
                currentSpeed = horizontalInput * acceleration * runTime;
                CheckDirection();
            } else
            {
                anim.SetBool("Moving", false);
                acceleration = 0;
                runTime = 0;
                currentSpeed = 0;
            }
            SpeedMultiplier();
            anim.SetFloat("CurrentSpeed", currentSpeed);
            //Add velocity to rigid body attached to player
            rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
        }

        //limits current speed to max speed and checks direction
        protected virtual void CheckDirection()
        {
            if (currentSpeed > 0)
            {
                if (player.isFacingLeft)
                {
                    player.isFacingLeft = false;
                    Flip();
                }
                if (currentSpeed > maxSpeed)
                {
                    currentSpeed = maxSpeed;
                }
            }
            if (currentSpeed < 0)
            {
                if (!player.isFacingLeft)
                {
                    player.isFacingLeft = true;
                    Flip();
                }
                if (currentSpeed < -maxSpeed)
                {
                    currentSpeed = -maxSpeed;
                }
            }
            
        }

        //method to multiply speed when sprinting
        protected virtual void SpeedMultiplier()
        {
            if (input.SprintingHeld())
            {
                currentSpeed *= sprintMultiplier;
            }
            if (player.isCrouching)
            {
                currentSpeed *= crouchSpeedMultiplier;
            }
        }
    }
}

