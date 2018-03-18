using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour {

	public GameObject dog;
	bool lerp = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (lerp)
		{
			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(20f, -35f, -5f), .1f);
		}
	}

    void OnTriggerEnter2D(Collider2D collision) {
        StartCoroutine(Win());
    }

    IEnumerator Win() {
        yield return new WaitForSeconds(0.5f);
		dog.GetComponent<Movement>().canMove = false;
		lerp = true;
        PanelController.instance.Dog("I'm out! *Woof* Yay, freedom!!! *Woof*");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("TitleScreen");
    }
}
