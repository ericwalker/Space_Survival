using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	public float fireDelay = 0.25f;
	float coolDownTimer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// when the space is pressed down
		if (Input.GetButton ("Fire1") && coolDownTimer <= 0) {
			// SHOOT the bullets
			coolDownTimer = fireDelay;
		}

	}
}
