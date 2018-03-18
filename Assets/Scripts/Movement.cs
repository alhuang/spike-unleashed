using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

	Rigidbody2D rigid;
	public float moveSpeed = 5;
	public GameObject space;
	bool canMove = false;


	// Use this for initialization
	void Awake () {
		rigid = this.GetComponent<Rigidbody2D> ();
	}

	void Start()
	{
		StartCoroutine(Wait());	
	}

	// Update is called once per frame
	void Update () {

		float xInput = Input.GetAxisRaw ("Horizontal");
		float yInput = Input.GetAxisRaw ("Vertical");

		if (canMove)
		{
			Vector2 velocity = new Vector2(xInput, yInput);
			velocity *= moveSpeed;

			rigid.velocity = velocity;
		}
		else
		{
			rigid.velocity = Vector2.zero;
		}
	}

	IEnumerator Wait()
	{
		canMove = false;
		yield return new WaitForSeconds(11f);
		canMove = true;
	}

	void OnCollisionEnter(Collision other)
	{
		print ("wth");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Trigger")
		{
			space.SetActive(true);

		}

	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Trigger")
			space.SetActive(false);
	}
}
