using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	public GameObject bulletPrefab;

	public float fireDelay = 0.25f;
	float coolDownTimer = 0;

	
	// Update is called once per frame
	void Update () {
		coolDownTimer -= Time.deltaTime;

		// when the space is pressed down
		if (Input.GetButton ("Fire1") && coolDownTimer <= 0) {

			Debug.Log ("Pew!");
			// SHOOT the bullets
			coolDownTimer = fireDelay;

			Instantiate (bulletPrefab, transform.position, transform.rotation);
		}

	}
}
