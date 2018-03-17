using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	private bool initial = true;
	private bool stopped = true;
	public string direction = "Right";
	public float moveSpeed = 4; 

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
				position = new Vector3(moveSpeed, 0, 0);
			} else if(direction == "Left") {
				position = new Vector3(-moveSpeed, 0, 0);
			} else if(direction == "Up") {
				position = new Vector3(0, moveSpeed, 0);
			} else if(direction == "Down") {
				position = new Vector3(0, -moveSpeed, 0);
			}

			rigid.velocity = position;
		}
	}

	IEnumerator Initial()
	{
		yield return new WaitForSeconds (2);
		stopped = false;
	}

	void OnTriggerEnter(Collider other)
	{
		print ("here");
		if (LayerMask.LayerToName (other.gameObject.layer) == "Direction") {
			direct = other.gameObject.GetComponent<Direction> ();
			direction = direct.Direct ();
		} else if (LayerMask.LayerToName (other.gameObject.layer) == "Stop") {
			stopped = true;
		}
	}


}
