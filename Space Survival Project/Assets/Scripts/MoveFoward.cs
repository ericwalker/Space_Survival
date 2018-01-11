using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour {

	public float maxSpeed = 8f;
	
	// Update is called once per frame
	void Update () {
		// MOVE the player
		Vector3 playerPos = transform.position;

		Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
		//		playerPos.y += Input.GetAxis ("Vertical") * maxSpeed * Time.deltaTime;
		playerPos += transform.rotation * velocity;

		transform.position = playerPos;
	}
}
