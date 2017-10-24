﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion; 
	public GameObject playerExplosion;
	//public GameObject enemyExplosion;
	public int scoreValue; 

	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController"); 
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} else {
			Debug.Log ("Cannot find 'GameController' script");
		}
			
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag != "Boundary") {
			// Destroy happens at the end of the frame
			// so order does not matter
			Instantiate (explosion, transform.position, transform.rotation);
			if (other.tag == "Player") 
			{ 
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				gameController.GameOver ();
			}
			//gameController.AddScore (scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
