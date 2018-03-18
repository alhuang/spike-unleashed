using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	private bool initial = true;
	private bool stopped = true;
	public string direction = "Right";

	public bool second = false;
	public float moveSpeed = 4; 
	public float waitTime = 1; 

	public GameObject hair = null;
	Direction direct;
	Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
		rigid = this.GetComponent<Rigidbody2D> ();
		StartCoroutine (Initial ());
	}
	
	// Update is called once per frame
	void Update () {
		if (!stopped) {
			Vector3 position = rigid.velocity;
			if (direction == "Right") {
				position = new Vector3 (moveSpeed, 0, 0);
			} else if (direction == "Left") {
				position = new Vector3 (-moveSpeed, 0, 0);
			} else if (direction == "Up") {
				position = new Vector3 (0, moveSpeed, 0);
			} else if (direction == "Down") {
				position = new Vector3 (0, -moveSpeed, 0);
			}

			print (position);
			rigid.velocity = position;
		}
		else {
			rigid.velocity = Vector3.zero;
		}

		if (hair.GetComponent<HairdryerAction> ().CanMove () && stopped && !second) {
			direction = "Right";
			stopped = false;
		}
	}

	IEnumerator Initial()
	{
		yield return new WaitForSeconds (6);
		stopped = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (LayerMask.LayerToName (other.gameObject.layer) == "Direction") {
			if ((other.gameObject.tag == "initial" && initial) ||
			    (other.gameObject.tag == "next" && !initial)) {
				if (second) {
					stopped = true;
					StartCoroutine (Wait ());
				}
				direct = other.gameObject.GetComponent<Direction> ();
				direction = direct.Direct ();
			}
		} else if (LayerMask.LayerToName (other.gameObject.layer) == "Stop") {
			if (!second) {
				initial = false;
			}
			stopped = true;
		} else if (LayerMask.LayerToName (other.gameObject.layer) == "Staircase") {
			Destroy (this.gameObject);
		}
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds (waitTime);
		stopped = false;
	}
}
