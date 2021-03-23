using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Vector2 speed = new Vector2 (5,0);
	private Vector2 mov;
	private Rigidbody2D rb;
	public float Jump = 1000;
	//private Animator anim;
	public Animator animP;
	private bool isFacingRight = true;

	private bool isGrounded = false;
	public Transform groundCheck;
	private float groundRadius = 0.3f;
	public LayerMask WhatIsGround;

	public float PlayerHP = 100;
	public float MaxPHP = 100;
	public bool isDead;

	public float playerAttack_time;

	public Transform Attack_1;
	public float Attack_1radius = 0.2f;

	public bool aa;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		animP = GetComponent<Animator> ();
	}
	

	void Update () {
		if (isGrounded && Input.GetKeyDown (KeyCode.Space)) 
		{
			animP.SetBool("Ground", false);
			rb.AddForce(new Vector2(0, 600));
		}

		if (PlayerHP <= 0)
			isDead = true;
	}

	void FixedUpdate () 
	{
		
		

		float InputX = Input.GetAxis ("Horizontal");
		animP.SetFloat ("Speed", Mathf.Abs (InputX));
		mov = new Vector2 (
			speed.x * InputX,
			rb.velocity.y
		);
			
		rb.velocity = mov;

		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, WhatIsGround);
		animP.SetBool ("Ground", isGrounded);
		animP.SetFloat ("vSpeed", rb.velocity.y);
		if (!isGrounded)
			return;
			





		if (Input.GetKeyDown (KeyCode.F)) {
			playerAttack_time = Time.time; 
			Fighting.Action (Attack_1.position, Attack_1radius, 8, 30, false, playerAttack_time);

			//StartCoroutine (WaitAttack ());
		}



		if (InputX > 00 && !isFacingRight)
			Flip ();
		else if (InputX < 00 && isFacingRight)
			Flip ();


	}
	private void Flip ()
	{
		isFacingRight = !isFacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	//This for touching damage
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.layer == 10) {
			PlayerHP -= 100;

		}
	}



	//IEnumerator WaitAttack()
			//{
				//yield return new WaitForSeconds (3);
		      //  Fighting.Action (Attack_1.position, Attack_1radius, 8, 30, false, playerAttack_time);
		//		Debug.Log ("waitsucces");
		//	}
}
