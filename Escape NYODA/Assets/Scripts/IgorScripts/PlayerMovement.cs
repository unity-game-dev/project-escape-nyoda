using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator anim;

	public float runSpeed = 40f;
	public float climbSpeed = 30f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	public float distance;
	public LayerMask whatIsLadder;
	private float inputVertical;

	private bool isClimbing;
	//private bool isDash;
	public IgorDash igorDash;
	// Update is called once per frame
	void Update () {
		if (igorDash.currentDashTime > 0f)
		{
			runSpeed = 80f;
		}
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		anim.SetFloat("Speed", Mathf.Abs(horizontalMove));
		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			anim.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}

	public void OnLanding()
	{
		anim.SetBool("IsJumping", false);
	}
	public void OnCrouching(bool isCrouching)
	{
		anim.SetBool("IsCrouching", isCrouching);
	}


	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;

		RaycastHit2D ladderHit = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
		if(ladderHit.collider != null)
		{
			if(Input.GetKeyDown(KeyCode.W))
			{
				isClimbing = true;
			}
		} else
		{
			if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
			{
				isClimbing = false;
			}
		}
		if (isClimbing == true && ladderHit.collider != null)
		{
			inputVertical = Input.GetAxisRaw("Vertical");
			controller.m_Rigidbody2D.velocity = new Vector2(controller.m_Rigidbody2D.velocity.x, inputVertical * climbSpeed);
			controller.m_Rigidbody2D.gravityScale = 0;
		} else
		{
			controller.m_Rigidbody2D.gravityScale = 4;
		}
	}
}
