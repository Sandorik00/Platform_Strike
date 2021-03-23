using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {

	public float HP = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (HP <= 00)
			StartCoroutine (death());
	}
	IEnumerator death ()
	{
		yield return new WaitForSeconds (1);
		Destroy(this.gameObject);
	}
}
