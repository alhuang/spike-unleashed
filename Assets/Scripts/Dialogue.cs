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

		PanelController.instance.Human("Hello? ...");
		yield return new WaitForSeconds(1.5f);

		PanelController.instance.Human("Oh, you're interested in buying Spike?");
		yield return new WaitForSeconds(3f);
		PanelController.instance.Human("That's great! The puppy is playing in his pen right now.");
		yield return new WaitForSeconds(4f);

		PanelController.instance.Human("Yes, I'll see you in 5 minutes!");

	}
}
