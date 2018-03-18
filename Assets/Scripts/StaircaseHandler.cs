using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaircaseHandler : MonoBehaviour {

    public Camera mainCamera;
    public Vector3 camPos;
    public Vector3 dogPos;
    public GameObject darkness;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Dog") && darkness.activeSelf) {
            Debug.Log("Dog entered door");
            StartCoroutine(MoveToFirstFloor(other));
        }
    }

    IEnumerator MoveToFirstFloor(Collider2D other) {
        yield return new WaitForSeconds(0.5f);
        other.gameObject.transform.position = dogPos;
        mainCamera.transform.position = camPos;
        yield return new WaitForSeconds(0.5f);
        PanelController.instance.SFX("*KNOCK*  *KNOCK*  *KNOCK*");
        yield return new WaitForSeconds(2.0f);
        PanelController.instance.Human("COMING!");
    }
}
