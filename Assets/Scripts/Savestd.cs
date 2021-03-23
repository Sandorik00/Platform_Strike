using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Savestd : MonoBehaviour {
	private bool isDead;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		isDead = GetComponent<Player> ().isDead;
		if (isDead)
			SceneManager.LoadScene (0);
	}
}
