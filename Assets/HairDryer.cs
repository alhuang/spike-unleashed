using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairDryer : MonoBehaviour {

	//public GameObject hairdryer;
	public GameObject tub;
	bool yes = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (yes)
		{
			transform.position = Vector2.Lerp(transform.position, tub.transform.position, .1f);
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		Debug.Log("collision");
		if (other.tag == "Spike")
		{
			if (Input.GetKey(KeyCode.Space)) {
				yes = true;
			}

		}

	}
}
