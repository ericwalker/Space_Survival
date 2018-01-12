using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

	public GameObject bulletPrefab;
	int bulletLayer;

	public float fireDelay = 0.50f;
	float coolDownTimer = 0;

	void Start(){
		bulletLayer = gameObject.layer;
	}

	// Update is called once per frame
	void Update () {
		coolDownTimer -= Time.deltaTime;

		// when the space is pressed down
		if (coolDownTimer <= 0) {

			Debug.Log ("Pew!");
			// SHOOT the bullets
			coolDownTimer = fireDelay;

			Vector3 offset = transform.rotation * new Vector3 (0, 0.5f, 0);

			GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, transform.position + offset, transform.rotation);
//			bulletGO.layer = gameObject.layer; // that will make the bulletGO be in vulnerable layer
			bulletGO.layer = bulletLayer;
		}

	}
}
