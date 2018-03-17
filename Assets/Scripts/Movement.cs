using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	Rigidbody2D rigid;
	public float moveSpeed = 5;

	// Use this for initialization
	void Awake () {
		rigid = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		float xInput = Input.GetAxisRaw ("Horizontal");
		float yInput = Input.GetAxisRaw ("Vertical");

		Vector2 velocity = new Vector2 (xInput, yInput);
		velocity *= moveSpeed;

		rigid.velocity = velocity;
	}

	void OnCollisionEnter(Collision other)
	{
		print ("wth");
	}
}
