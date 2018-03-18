using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimalInteraction : MonoBehaviour {

    public string text1;
    public float timeInbetween;
    public string text2;

    private bool attached = false;

    private PlayerAction pa;

    private void OnTriggerEnter2D(Collider2D collision) {
        pa = collision.gameObject.GetComponent<PlayerAction>();
        if (!attached && pa != null) {
            pa.spaceClicked += InteractWithDoor;
            attached = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        PlayerAction paa = collision.gameObject.GetComponent<PlayerAction>();
        if (attached && paa != null) {
            paa.spaceClicked -= InteractWithDoor;
            attached = false;
        }
    }

    private void InteractWithDoor() {
        StartCoroutine(DoorDialogue());
    }

    IEnumerator DoorDialogue() {
        PanelController.instance.Dog(text1);
        yield return new WaitForSeconds(timeInbetween);
        PanelController.instance.Dog(text2);
        if (attached) {
            pa.spaceClicked -= InteractWithDoor;
        }
    }
}
