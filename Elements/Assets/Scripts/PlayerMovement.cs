using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : BaseCharacterMovement 
{

	private Rigidbody2D myRigidbody;

	private Animator myAnimator;

	[SerializeField]
	private float movementSpeed = 5f;

	private bool facingRight;

	[SerializeField]
	public bool isGrounded = true;

	[SerializeField]
	private float initialJumpPower = 500f;

	void Start()
	{
		myRigidbody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal");
		HandleMovement(horizontal);

		Flip((myRigidbody.velocity.x) < 0f);

		if(Input.GetButtonDown("Jump"))
		{
			Jump();
		}
	}

	private void HandleMovement(float horizontal)
	{
		myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y); //x-1, y = 0;

		myAnimator.SetBool("Moving", Mathf.Abs(myRigidbody.velocity.x) > 0);
		myAnimator.SetBool("Jumping", !isGrounded);
		
	}

	private void Jump()
	{
		if(isGrounded == true)
		{
			myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0);
            myRigidbody.AddForce(Vector2.up * initialJumpPower);
		}
		
	}

	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "ground")
		{
		isGrounded = true;
		}

	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "ground")
		{
		isGrounded = false;
		}
	}



}