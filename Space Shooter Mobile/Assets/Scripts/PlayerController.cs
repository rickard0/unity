﻿using System.Collections;
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

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	public Boundary boundary; 

	void Start() { 
		rb = GetComponent<Rigidbody> (); 
	}

	void FixedUpdate() 
	{ 
		//float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVeritcal = Input.GetAxis ("Vertical"); 

		Vector3 acceleration = Input.acceleration; // Get from accelerometer 
		Vector3 movement = new Vector3 (acceleration.x, 0.0f, acceleration.y); 

		rb.velocity = movement * Speed;

		rb.position = new Vector3
		(
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax) 
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt); 

	}

	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
}
