using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : MonoBehaviour {

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
        PanelController.instance.Dog("Locked. *Woof*");
        yield return new WaitForSeconds(2f);
        PanelController.instance.Dog("I need to get this open somehow...");
        if (attached) {
            pa.spaceClicked -= InteractWithDoor;
        }
    }
}
