using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour {

	public int health = 1;

	public float invulnPeriod = 0;
	float invulnTimer = 0; // use to countdown for the invulnerable time
	int correctLayer;

	SpriteRenderer spriteRend; 


	// This only get the renderer on the parent object.
	// That is, it doesn't work for children. i.e. "enemy01"
	void Start(){
		correctLayer = gameObject.layer;

		spriteRend = GetComponent<SpriteRenderer> ();

		if (spriteRend == null) { // if the gameObject is the enemy, then it should not be null
			spriteRend = transform.GetComponentInChildren<SpriteRenderer> ();

			if (spriteRend == null) {
				Debug.LogError ("Object '" + gameObject.name + "' has no sprite renderer.");
			}
		}
	}


	// be shoot by enemy or bump into enemy
	void OnTriggerEnter2D(){
		Debug.Log ("Trigger");

		health--;
		invulnTimer = 2f;

		gameObject.layer = 10; // set the playerShip to be invulnerable
	}

	void Update(){

		invulnTimer -= Time.deltaTime;

		if (invulnTimer <= 0) {
			gameObject.layer = correctLayer;
			if (spriteRend != null) {
				spriteRend.enabled = true;
			}
		} else {
			if (spriteRend != null) {
				spriteRend.enabled = !spriteRend.enabled;
			}
		}

		if (health <= 0) {
			Die ();
		}
	}

	void Die(){
	
		Destroy (gameObject);
	}
}
