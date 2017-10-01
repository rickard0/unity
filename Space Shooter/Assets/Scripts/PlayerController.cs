using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float Speed; 
	private Rigidbody rb; 
	public float tilt; 

	public Boundary boundary; 

	void Start() { 
		rb = GetComponent<Rigidbody> (); 
	}

	void FixedUpdate() { 
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVeritcal = Input.GetAxis ("Vertical"); 

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVeritcal); 
		rb.velocity = movement * Speed;

		rb.position = new Vector3
		(
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax) 
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt); 

	}
}
