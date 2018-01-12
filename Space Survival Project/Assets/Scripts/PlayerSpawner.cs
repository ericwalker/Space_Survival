﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

	public GameObject playerPrefab;
	GameObject playerInstance;

	public int numLives = 4;

	float respawnTimer;

	// Use this for initialization
	void Start () {
		SpawnPlayer ();
	}

	void SpawnPlayer(){
		numLives--;
		respawnTimer = 1f;
		playerInstance = (GameObject) Instantiate (playerPrefab, transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInstance == null) {
			respawnTimer -= Time.deltaTime;

			if (respawnTimer <= 0) {
				SpawnPlayer ();
			}
		}
	}

	void OnGUI(){
		
	}
}
