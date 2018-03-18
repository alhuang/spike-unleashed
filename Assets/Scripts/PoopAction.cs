using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopAction : MonoBehaviour {

    private PlayerAction pa;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pa = collision.gameObject.GetComponent<PlayerAction>();
        if (pa != null)
        {
            pa.spaceClicked += poop;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerAction pa = collision.gameObject.GetComponent<PlayerAction>();
        if (pa != null)
        {
            pa.spaceClicked -= poop;
        }
    }

    private void poop()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = false;
        pa.spaceClicked -= poop;
        PanelController.instance.Dog("Heheh");
    }
}
