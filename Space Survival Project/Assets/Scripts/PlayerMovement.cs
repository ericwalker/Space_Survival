using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 5f;
	public float rotSpeed = 180f;
	private Vector3 playerPos = new Vector3 (0, 0, 0);
	private Quaternion playerRot;

	// Use this for initialization
	void Start () {
		
	}

	void Update () {
		// return a float from -1.0 to +1.0
		Input.GetAxis ("Vertical");

		// ROTATE the player

		// Grab our rotation quaternion
		playerRot = transform.rotation;

		// Grab the z euler angle
		float z = playerRot.eulerAngles.z;

		z -= Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime;
		playerRot = Quaternion.Euler (0, 0, z);
		transform.rotation = playerRot;


		// MOVE the player
		playerPos.y += Input.GetAxis ("Vertical") * maxSpeed * Time.deltaTime;
		transform.position = playerPos;
	}
}
