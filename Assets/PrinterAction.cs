using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterAction : MonoBehaviour {

	public GameObject smoke;
	public GameObject pee;
	PlayerAction pa;

	bool yes = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		pa = collision.gameObject.GetComponent<PlayerAction>();
		if (pa != null)
		{
			pa.spaceClicked += blowup;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		pa = collision.gameObject.GetComponent<PlayerAction>();
		if (pa != null)
		{
			pa.spaceClicked -= blowup;
		}
	}

	private void blowup()
	{
		if (!yes)
		{
			Instantiate(smoke, new Vector3(-5.2f, -1f), Quaternion.Euler(-90f, 0f, 0f));
			Instantiate(pee, new Vector3(-3.5f, -2f), Quaternion.identity);
			pa.spaceClicked -= blowup;
			GetComponent<BoxCollider2D>().enabled = false;
			yes = true;
		}
	}

}
