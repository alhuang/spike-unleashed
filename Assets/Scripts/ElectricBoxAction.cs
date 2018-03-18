using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBoxAction : MonoBehaviour {

    public GameObject door;
    public Sprite brokenWire;
    public GameObject wire;

    private bool attached = false;

    private PlayerAction pa;

    private void OnTriggerEnter2D(Collider2D collision) {
        pa = collision.gameObject.GetComponent<PlayerAction>();
        if (!attached && pa != null) {
            pa.spaceClicked += RemoveDoor;
            attached = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        PlayerAction paa = collision.gameObject.GetComponent<PlayerAction>();
        if (attached && paa != null) {
            paa.spaceClicked -= RemoveDoor;
            attached = false;
        }
    }

    private void RemoveDoor() {
        StartCoroutine(BlinkyDoor());
    }

    IEnumerator BlinkyDoor() {
        wire.GetComponent<SpriteRenderer>().sprite = brokenWire;
        door.SetActive(true);
        yield return new WaitForSeconds(.2f);
        for (int i = 1; i < 4; i++) {
            door.SetActive(false);
            yield return new WaitForSeconds(0.2f * i);
            door.SetActive(true);
            yield return new WaitForSeconds(0.2f * i);
            door.SetActive(false);
        }
        if (attached) {
            pa.spaceClicked -= RemoveDoor;
        }
    }
}
