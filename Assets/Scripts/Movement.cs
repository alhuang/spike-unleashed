using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

	Rigidbody2D rigid;
	public float moveSpeed = 5;
	public GameObject space;
	public AudioClip woofclip;
	public AudioClip phonering;
	bool canMove = false;
	bool woof = false;



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
		if (!woof)
		{
			AudioSource.PlayClipAtPoint(woofclip, Camera.main.transform.position);
			StartCoroutine(woofer());
		}

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

	IEnumerator woofer()
	{
		woof = true;
		yield return new WaitForSeconds(5f);
		woof = false;
	}

	IEnumerator Wait()
	{
		canMove = false;
		yield return new WaitForSeconds(1f);
		AudioSource.PlayClipAtPoint(phonering, Camera.main.transform.position);
		yield return new WaitForSeconds(10f);
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
