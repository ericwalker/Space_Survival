using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 5f;
	public float rotSpeed = 180f;
	private Vector3 playerPos = new Vector3 (0, 0, 0);
	private Quaternion playerRot;

	float shipBoundaryRadius = 0.5f;

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
		Vector3 velocity = new Vector3(0, Input.GetAxis ("Vertical") * maxSpeed * Time.deltaTime, 0);
//		playerPos.y += Input.GetAxis ("Vertical") * maxSpeed * Time.deltaTime;
		playerPos += playerRot * velocity;


		// RESTRICT the player to the camera's boundaries.

		// Vertical bounds
		if(playerPos.y + shipBoundaryRadius > Camera.main.orthographicSize){
			playerPos.y = Camera.main.orthographicSize - shipBoundaryRadius;
		}
		if(playerPos.y - shipBoundaryRadius < -Camera.main.orthographicSize){
			playerPos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
		}
			
		// Calculate the orthographic width based on the screen ratio
		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		// Horizontal bounds
		if(playerPos.x + shipBoundaryRadius > widthOrtho){
			playerPos.x = widthOrtho - shipBoundaryRadius;
		}
		if(playerPos.x - shipBoundaryRadius < -widthOrtho){
			playerPos.x = -widthOrtho + shipBoundaryRadius;
		}
			
		transform.position = playerPos;
	}
}
