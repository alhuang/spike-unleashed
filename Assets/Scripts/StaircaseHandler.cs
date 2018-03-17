using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaircaseHandler : MonoBehaviour {

    public Camera mainCamera;
    public Vector3 firstFloorPosCam;
    public Vector3 firstFloorPosDog;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Dog")) {
            Debug.Log("Dog entered door");
            StartCoroutine(MoveToFirstFloor(other));
        }
    }

    IEnumerator MoveToFirstFloor(Collider2D other) {
        yield return new WaitForSeconds(0.5f);
        other.gameObject.transform.position = firstFloorPosDog;
        mainCamera.transform.position = firstFloorPosCam;
    }
}
