using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator anim;

	public float runSpeed = 40f;
	public float climbSpeed = 5f;

	float horizontalMove = 0f;
	bool jump = false;
	float fJumpPressedRemember = 0;
	float fJumpPressedRememberTime = 2f;
	float fGroundedRemember = 0;
	float fGroundedRememberTime = 2f;
	public float distance;
	public LayerMask whatIsLadder;
	private float inputVertical;
	private bool isWalking;
	
	private bool isClimbing;
	//private bool isDash;
	public IgorDash igorDash;
	public IgorHealth igorHealth;
	// Update is called once per frame

	void Update () {
		if (Time.timeScale == 0)
		{
			return;
		}
		if (igorHealth.isDead == true)
		{
			return;
		}
		if (igorDash.currentDashTime > 0f)
		{
			fGroundedRememberTime = 5f;
			fJumpPressedRememberTime = 5f;
			runSpeed = 80f;
			climbSpeed = 10f;
		} else
		{
			fGroundedRememberTime = 2f;
			fJumpPressedRememberTime = 2f;
			runSpeed = 40f;
			climbSpeed = 5f;
		}
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		anim.SetFloat("Speed", Mathf.Abs(horizontalMove));
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
		{
				//AudioManager.instance.Play("characWalk");
		} else if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
		{
			//AudioManager.instance.StopPlaying("characWalk");
		}

		fGroundedRemember -= Time.deltaTime;
		if (controller.m_Grounded)
		{
			fGroundedRemember = fGroundedRememberTime;
		}
		fJumpPressedRemember = -Time.deltaTime;
		if (Input.GetButtonDown("Jump"))
		{
			fJumpPressedRemember = fJumpPressedRememberTime;
		}
		if ((fJumpPressedRemember > 0) && (fGroundedRemember > 0))
		{
			fJumpPressedRemember = 0;
			fGroundedRemember = 0;
			jump = true;
			anim.SetBool("IsJumping", true);
		}

		if(jump == true)
		{
			AudioManager.instance.Play("characJump");
		}
		

	}

	public void OnLanding()
	{
		anim.SetBool("IsJumping", false);
	}
	


	void FixedUpdate ()
	{
		if(Time.timeScale == 0)
		{
			return;
		}
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
			/****/
			anim.SetBool("IsJumping", false);
			/***/
			anim.SetBool("IsClimbing", true);
		} else
		{
			anim.SetBool("IsClimbing", false);
			controller.m_Rigidbody2D.gravityScale = 4;
		}
	}
}
