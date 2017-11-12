using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour 
{
	public float dodge;
	public float tilt;
	public float smoothing;
	public Vector2 startWait;  		// This will be a range that we'll pull a random from
	public Vector2 maneuverTime; 	// This will be the duration of the maneuver
	public Vector2 maneuverWait;	// This will be the time we allow for the maneuver to complete
	public Boundary boundary;

	private float currentSpeed; 
	private float targetManeuver; 
	private Rigidbody rb; 

	void Start () 
	{
		rb = GetComponent<Rigidbody> (); 
		currentSpeed = rb.velocity.z;
		StartCoroutine (Evade ()); 
	}

	IEnumerator Evade()
	{
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));

		while (true) 
		{
			targetManeuver = Random.Range (1, dodge) * -Mathf.Sign(transform.position.x); 
			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y)); 
			targetManeuver = 0; 
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y)); 
		}

	}

	void FixedUpdate () 
	{
		float newManeuver = Mathf.MoveTowards (rb.velocity.x, targetManeuver, Time.deltaTime * smoothing); 
		rb.velocity = new Vector3 (newManeuver, 0.0f, currentSpeed); 

		// Clamp the enemy within the screen as wel
		rb.position = new Vector3
		(
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax) 
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt); 
	}
}
