﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBoxAction : MonoBehaviour {

    public GameObject door;
    public Sprite brokenWire;
    public GameObject wire;
	public AudioClip buzz;

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
		GetComponent<BoxCollider2D>().enabled = false;
    }

    IEnumerator BlinkyDoor() {
        PanelController.instance.Dog("The door unlocked! I can go outside!");
        wire.GetComponent<SpriteRenderer>().sprite = brokenWire;
        door.SetActive(true);
        yield return new WaitForSeconds(.1f);
		AudioSource.PlayClipAtPoint(buzz, Camera.main.transform.position);
        for (int i = 1; i < 3; i++) {
            door.SetActive(false);
            yield return new WaitForSeconds(0.1f * i);
            door.SetActive(true);
            yield return new WaitForSeconds(0.1f * i);
            door.SetActive(false);
        }
        if (attached) {
            pa.spaceClicked -= RemoveDoor;
        }
    }
}
