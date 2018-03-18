using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour {

	public bool second = false;
	public string direction = "Right";
	public string nextDirect = "Down";

	public string Direct()
	{
		if (second) {
			int val = Random.Range (0, 2);
			if (val == 0) {
				return direction;
			} else {
				return nextDirect;
			}
		}
		return direction;
	}
}
