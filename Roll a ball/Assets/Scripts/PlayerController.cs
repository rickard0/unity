using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb; // Bad tutorial variable naming. This should be "player", no?
	public float speed; // This will show up in the inspector as an editable property

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); 
	}
	
	// FixedUpdate
	// Called before any physics calculations are performed
	// Physics code goes here.
	void FixedUpdate () 
	{ 
		// Gets keyboard inputs 
		float moveHorizontal = Input.GetAxis ("Horizontal"); 
		float moveVertical = Input.GetAxis ("Vertical"); 

		rb.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical) * speed); 
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);	
		}
	}
}
