using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	 
	public int playerNum; 
	public float moveSpeed;
	public float airSpeedModifier;
	public float hoverAirSpeed; 
	public float normalAirSpeed; 
	public float jumpSpeed;
	public float minimumJumpHeight;
	public float hoverGrav;
	public float normalGrav;
	public float hoverStop; 
	public bool grounded;
	public bool inAir;
	private bool canJump;
	public bool canHover;

	public float shotDirection = 1;
	public float shotSpeed;
	public float shotScale; 
	public float shotDuration; 
	public float shotDamage;
	public string shotColor;



	public bool idleAnim = true;
	public bool jumpingAnim;
	public bool fallingAnim;
	public bool floatingAnim;
	public bool dashingAnim;
	private bool dashing;

	public KeyCode left; 
	public KeyCode right;
	public KeyCode jump;
	public KeyCode fire;
	public GameObject hitbox;
	Animator anim;
//	RPSSystem rps;
//	TokenSpawner ts;
//	GameObject tokenSpawner;
	SpriteRenderer sr; 
	Rigidbody2D rb; 
//	StackUI sui;
//
	// Use this for initialization
	void Start () {

		sr = GetComponent<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();
//		rps = GetComponent<RPSSystem> ();
		grounded = true; 
//		tokenSpawner = GameObject.Find ("TokenSpawner"); 
//		ts = tokenSpawner.GetComponent<TokenSpawner> (); 
//		sui = GetComponent<StackUI> ();
		anim = GetComponent<Animator> (); 
		
	}
	
	// Update is called once per frame
	void Update () {
		playerMove (left, moveSpeed * -1); 
		playerMove (right, moveSpeed); 
		playerJump ();
		attack ();
		animationHandler ();
		//		jumpTimer = jumpValue * Time.deltaTime;

	}

	void playerMove(KeyCode key, float direction)
	{
		if (Input.GetKey(key)) 
		{
			if (inAir == false) 
			{
				rb.velocity = new Vector2 (direction, rb.velocity.y);
				dashing = true;
			}

			if (inAir == true) 
			{
				rb.velocity = new Vector2 ((direction * airSpeedModifier), rb.velocity.y);
			}

			if (key == left) 
			{
				sr.flipX = true; 
				shotDirection = -1;
			}
			if (key == right) 
			{
				sr.flipX = false;
				shotDirection = 1; 
			}

		}

		if (Input.GetKeyUp (key)) {
			rb.velocity = new Vector2 (0, rb.velocity.y);
			dashing = false;
		}

	}

	void playerJump ()
	{
		if (Input.GetKey (jump)) 
		{
			if (grounded == true && canJump == true)
			{
				rb.velocity = new Vector2 (rb.velocity.x, jumpSpeed); 
				grounded = false;
				inAir = true;
				canJump = false;
			}
		}

		if (Input.GetKeyUp (jump) && grounded == false && rb.velocity.y >= 0 && transform.position.y >= minimumJumpHeight)
		{
			rb.velocity = new Vector2 (rb.velocity.x, 0);
		}


		if (Input.GetKeyUp (jump) && grounded == true) 
		{
			canJump = true;
		}

		if (Input.GetKey (jump) && inAir == true && canHover == true) 
		{
			airSpeedModifier = hoverAirSpeed; 
			rb.gravityScale = hoverGrav;
			rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y * hoverStop);
			floatingAnim = true;

		}

		if (Input.GetKeyUp (jump) && inAir == true) 
		{
			airSpeedModifier = normalAirSpeed;
			rb.gravityScale = normalGrav;
			canHover = true;
			floatingAnim = false; 
		}
	
	}

	void attack ()
	{
		if (Input.GetKeyDown(fire))
		{
			GetComponent<Weapon> ().fire (shotDirection, 
				new Vector3 (shotDirection, 0, 0), 
				new Vector3 (shotScale, shotScale, shotScale), 
				shotSpeed, 
				shotDuration,
				shotDamage,
				shotColor);
		}
	}

	void OnCollisionEnter2D(Collision2D touched)
	{
		if (touched.gameObject.tag == "Floor" || touched.gameObject.tag == "Player" || touched.gameObject.tag == "Block") {
			grounded = true;
			inAir = false;
			canHover = false;
			floatingAnim = false;
			airSpeedModifier = normalAirSpeed;
			rb.gravityScale = normalGrav; 
			if (!Input.GetKey (jump)) {
				canJump = true;
			}
		}
	}

//	void OnTriggerEnter2D (Collider2D touched)
//	{
//		if (touched.gameObject.tag == "Paper Token")   
//		{
//			rps.addToStack ("Paper");
//			sui.thirdSlotCheck ();
////			ts.paperGone = true;
//			Destroy (touched.gameObject); 
//		}
//
//		if (touched.gameObject.tag == "Rock Token") 
//		{
//			rps.addToStack ("Rock");
//			sui.thirdSlotCheck ();
//			ts.rockGone = true;
//			Destroy (touched.gameObject); 
//		}
//
//		if (touched.gameObject.tag == "Scissors Token") 
//		{
//			rps.addToStack ("Scissors");
//			sui.thirdSlotCheck ();
//			ts.scissorsGone = true;
//			Destroy (touched.gameObject); 
//		}
//
//	}

	void animationHandler ()
	{
		anim.SetBool ("Idle", idleAnim);
		anim.SetBool ("Dashing", dashingAnim);
		anim.SetBool ("Jumping", jumpingAnim);
		anim.SetBool ("Floating", floatingAnim);

		if (inAir == false && grounded == true && dashing == false) {
			idleAnim = true; 
		} else {
			idleAnim = false;
		}

		if (inAir == false && rb.velocity.x != 0 && dashing == true) {
			dashingAnim = true;
		} else {
			dashingAnim = false;
		}
		if (inAir == true && rb.velocity.y >= 0) {
			jumpingAnim = true;
		} else {
			jumpingAnim = false;
		}

		if (idleAnim == true) 
		{
			jumpingAnim = false;
			fallingAnim = false;
			floatingAnim = false;
			dashingAnim = false;
		}

		if (grounded == true) 
		{
			fallingAnim = false;
			floatingAnim = false;
			jumpingAnim = false;
		}

	}


}
