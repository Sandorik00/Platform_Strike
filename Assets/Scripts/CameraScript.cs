using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	GameObject Player;
	private Vector3 offset;
	private float x;

	// Use this for initialization
	void Start () {
		offset = transform.position - Player.transform.position;
		x = transform.position.x;
	}

	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3(x, Player.transform.position.y, Player.transform.position.z) + offset;

	}
}
