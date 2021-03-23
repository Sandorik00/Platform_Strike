using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour {

	private static GameObject animF;

	void Start() {
	 animF = GameObject.FindGameObjectWithTag("Player");
	}

	static GameObject NearTarget (Vector3 position, Collider2D[] array)
	{
		Collider2D current = null;
		float dist = Mathf.Infinity;

		foreach (Collider2D coll in array) {
			float curDist = Vector3.Distance (position, coll.transform.position);
			if (curDist < dist) 
			{
				current = coll;
				dist = curDist;
			}
		}
		return current.gameObject;
	}

	public static void Action(Vector2 point, float radius, int layerMask, float damage, bool allTargets , float timeAttack)
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll (point, radius, 1 << layerMask);
		//NormalAttack
		//if (!allTargets) {
			//GameObject obj = NearTarget (point, colliders);
			//if (obj.GetComponent<EnemyHP> ()) {
			//	obj.GetComponent<EnemyHP> ().HP -= damage;
			//	Debug.Log (obj.GetComponent<EnemyHP> ().HP);
			//}
			//return;
		//}

		//Parry
		if (!allTargets) {
			GameObject obj = NearTarget (point, colliders);
			if (obj.GetComponent<EnemyAI> () && obj.GetComponent<EnemyAI> ().StampE1 > timeAttack) {
				obj.GetComponent<EnemyAI> ().anim.SetBool ("ParryE", true);
				animF.GetComponent<Player> ().animP.SetTrigger ("Parrytt");
				obj.GetComponent<EnemyHP> ().HP -= 100;
				Debug.Log (obj.GetComponent<EnemyHP> ().HP);
			}
			return;
		}

		foreach (Collider2D hit in colliders) {
			if (hit.GetComponent<EnemyHP> ()) {
				hit.GetComponent<EnemyHP> ().HP -= damage;
				Debug.Log (hit.GetComponent<EnemyHP> ().HP);
			}
		}

	}


}
