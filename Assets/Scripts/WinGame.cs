using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        PanelController.instance.Dog("I'm out! *Woof* Yay, freedom!!! *Woof*");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("TitleScreen");
    }
}
