using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacesPlayer : MonoBehaviour {

	public float rotSpeed = 90f;

	Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) { // when the player is died or not yet exist
			// Find the player's ship
			GameObject go = GameObject.FindGameObjectWithTag("Player");

			if (go != null) {
				player = go.transform;
			}
		}

		// At this point, we either found the position of the player,
		// or the player doesn't exist right now.

		if (player == null) {
			return; // try again next frame. Look for the player in every frame
		}

		// Here, we are sure we have a player
		Vector3 dir = player.position - transform.position; // a distance vector
		dir.Normalize();

		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90; // because 0 angle toward to right
	
//		transform.rotation = Quaternion.Euler (0, 0, zAngle);
		Quaternion desiredRot = Quaternion.Euler (0, 0, zAngle);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);

	}
}
