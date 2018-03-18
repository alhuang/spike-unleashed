using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchDog : MonoBehaviour {

    bool dogCaught = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (dogCaught) {
            GetComponentInParent<EnemyMove>().moveSpeed = 0;
        }
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Dog")) {
            if (!dogCaught) {
                StartCoroutine(ResetDog(other));
            }
            dogCaught = true;
        }
    }

    IEnumerator ResetDog(Collider2D other) {
        PanelController.instance.Human("Spike! How did you get out of your pen?");
        yield return new WaitForSeconds(3f);
        PanelController.instance.Human("Nevermind that. Let's get you back.");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Main");
    }
}
