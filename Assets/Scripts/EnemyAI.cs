using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	public float speedBe;
	public Vector2 movE;
	private Rigidbody2D rb;
	private bool isFacingRight = true;
	public float StampE1 = 1;
	public Animator anim;

	public Transform Attack_enemy;
	private bool isPlayer = false;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		movE = new Vector2 (speedBe, rb.velocity.y);
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		movE.y = rb.velocity.y;

		if (anim.GetBool ("ParryE") == true) {
			return;
		}

		isPlayer = Physics2D.OverlapCircle (Attack_enemy.position, 0.2f, 1 << 0);
		if (isPlayer && Time.time > StampE1) {
			StampE1 = Time.time + 1;
			StartCoroutine (FightE ());
		}

		if (Time.time < StampE1) {
			anim.SetBool ("Runn", false);
			return;
		}

		rb.velocity = movE;
		if (anim.GetBool ("Runn") == false)
		anim.SetBool ("Runn", true);
			
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.right,1,1 << 9);
		if (hit.collider != null && isFacingRight) {
			Flip ();
			movE.x = -speedBe;
			Debug.Log (hit.point + "right");
		}
		RaycastHit2D hitb = Physics2D.Raycast (transform.position, Vector2.left, 1,1 << 9);
		if (hitb.collider != null && !isFacingRight) {
			Flip ();
			movE.x = speedBe;
			Debug.Log (hitb.point + "left");
		}

	}
	IEnumerator FightE() {
		anim.SetBool ("AttackEe", true);
		yield return new WaitForSeconds (1);
		if (anim.GetBool ("ParryE") == true) {
			yield break;
		}
		anim.SetBool("AttackEe" ,false);
		Collider2D imp = Physics2D.OverlapCircle (Attack_enemy.position, 0.2f, 1 << 0);
		GameObject objp = Target(Attack_enemy.position,imp);
		if (objp != null && objp.GetComponent<Player> ()) {
			objp.GetComponent<Player> ().PlayerHP -= 50;
			Debug.Log (objp.GetComponent<Player> ().PlayerHP);
		}
	}
	static GameObject Target (Vector3 position,Collider2D im) {
		Collider2D coll = im;
		return coll.gameObject;
	}
	private void Flip ()
	{
		isFacingRight = !isFacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
