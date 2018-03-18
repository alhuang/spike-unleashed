using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAction : MonoBehaviour {
    public GameObject fenceClosed;
    public GameObject fenceOpen;

    private bool attached = false;

    private PlayerAction pa;
    public Sprite brokenWire;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pa = collision.gameObject.GetComponent<PlayerAction>();
        if (!attached && pa != null)
        {
            pa.spaceClicked += PhaseFence;
            attached = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerAction paa = collision.gameObject.GetComponent<PlayerAction>();
        if (attached && paa != null)
        {
            paa.spaceClicked -= PhaseFence;
            attached = false;
        }
    }

    private void PhaseFence()
    {
        StartCoroutine(BlinkyFence());

    }
    
    IEnumerator BlinkyFence()
    {
        PanelController.instance.Dog("*Woof* ...???");
        GetComponentInChildren<SpriteRenderer>().sprite = brokenWire;
        fenceClosed.SetActive(false);
        fenceOpen.SetActive(true);
        yield return new WaitForSeconds(.2f);
        for (int i = 1; i < 5; i++)
        {
            fenceClosed.SetActive(true);
            fenceOpen.SetActive(false);
            yield return new WaitForSeconds(0.1f * i);
            fenceClosed.SetActive(false);
            fenceOpen.SetActive(true);
            yield return new WaitForSeconds(0.1f * i);
        }
        if (attached)
        {
            pa.spaceClicked -= PhaseFence;
        }
        PanelController.instance.Dog("*Woof* Freedom!! *Woof*");
        gameObject.SetActive(false);
    }
}
