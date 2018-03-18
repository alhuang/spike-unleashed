using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour {

	public bool second = false;
	public bool three = false;
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
		} else if (three) {
			int val = Random.Range (0, 3);
			if (val == 0) {
				return direction;
			} else if( val == 1){
				return nextDirect;
			} else{
				return "Down";
			}
		}
		return direction;
	}
}
