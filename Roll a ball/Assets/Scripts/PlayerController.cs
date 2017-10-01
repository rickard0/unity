using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerController : MonoBehaviour {

	private Rigidbody rb; // Bad tutorial variable naming. This should be "player", no?
	public float speed; // This will show up in the inspector as an editable property
	public Text winText;
	public Text countText;


	private int count; 

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); 
		count = 0; 
		setCountText (); 
		winText.text = "";
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
			count++; 
			setCountText (); 

			if (count >= 12) 
			{
				endGame ();
			}
		}
	}

	void setCountText() 
	{
		countText.text = "Score: " + count.ToString ();
	}

	void endGame()
	{
		speed = 0;
		rb.AddForce (new Vector3 (0, 0, 0));
		this.StopAllCoroutines ();
		winText.text = "You Win!";
	}
}
