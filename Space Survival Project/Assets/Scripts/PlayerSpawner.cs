using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

	public GameObject playerPrefab;
	GameObject playerInstance;

	// Use this for initialization
	void Start () {
		playerInstance = (GameObject) Instantiate (playerPrefab, transform.position, Quaternion.identity);
	}

	void SpawnPlayer(){
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
