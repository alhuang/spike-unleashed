using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision) {
        StartCoroutine(Win());
    }

    IEnumerator Win() {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Spike successfully escaped!");
    }
}
