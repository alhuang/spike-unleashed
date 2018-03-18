using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Intro());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Intro() {
		yield return new WaitForEndOfFrame();

		PanelController.instance.Dog("*woof* This place sucks! *woof*");

		yield return new WaitForSeconds(3.5f);

		PanelController.instance.Human("Hello?...");
		yield return new WaitForSeconds(1.5f);

		PanelController.instance.Human("You want to buy Spike?");
		yield return new WaitForSeconds(2f);
		PanelController.instance.Human("Great! I'll finish the paperwork.");
		yield return new WaitForSeconds(2.25f);

		PanelController.instance.Human("You can come by in 30 minutes.");

	}
}
