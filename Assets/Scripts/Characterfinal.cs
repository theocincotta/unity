﻿using UnityEngine;
using System.Collections;

public class Characterfinal : MonoBehaviour
{
	public 	float speed = 10f;
	public 	bool jump = false;				// Condition for whether the player should jump.	
	public 	float jumpForce = 1000f;		// Amount of force added when the player jumps.
	public 	bool gamestarted = false;		// Is the player currently running?
	private bool grounded = false;			// Whether or not the player is grounded.
	private Rigidbody2D rigidBody;			// Reference to the player's rigidbody

	private Animator anim;					// Reference to the player's animator component.

	void Awake()
	{
		anim = GetComponent<Animator>();
	}

	//the moment our character hits the ground we set the grounded to true 
	void OnCollisionEnter2D(Collision2D hit)
	{
		grounded = true;
	}
	
	void Start()
	{
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{

		if(Input.GetButtonDown("Fire1"))
		{		

			// If the jump button is pressed and the player is grounded and the character is running forward then the player should jump.
	     	if( (grounded == true) && (gamestarted == true))						
			{
				jump = true;
				grounded = false;
				anim.SetTrigger("Jump");
			}
		    // if the game is set now to start the character will start to run forward in the FixedUpdate
			else
			{
				gamestarted = true;
				anim.SetTrigger("Start");
			}
			
		}

		anim.SetBool("Grounded", grounded);
	}


	//everything in the physics we set in the fixupdate 
	void FixedUpdate ()
	{
		// if game is started we move character forward and update the animator...
		if (gamestarted == true) 
		{
			rigidBody.velocity = new Vector2( speed , rigidBody.velocity.y  );
		}

		// If jump is set to true we are now adding quickly aforce to push the character up
		if(jump == true)
		{
		
			// Add a vertical force to the player.
			rigidBody.AddForce(new Vector2(0f, jumpForce));

			// We set to false otherwise the ridig2D addforce would keep adding force
			jump = false;


		}

	}
	
}
