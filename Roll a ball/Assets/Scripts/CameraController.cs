using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player; 
	private Vector3 offset; 

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position; 	
	}
	
	// LateUpdate is guaranteed to run after all items have been run in Update
	// Setting the position in LastUpdate means we can be sure the object has moved.
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
