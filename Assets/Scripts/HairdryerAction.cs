using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairdryerAction : MonoBehaviour {

    public GameObject destinationObj;
	public GameObject sparks;
    private bool act = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (act)
        {
			if (gameObject.transform.position == destinationObj.transform.position)
			{
				act = false;
				Instantiate(sparks, destinationObj.transform.position, Quaternion.identity);
			}
			else
				transform.position = Vector3.Lerp(transform.position, new Vector3(destinationObj.transform.position.x, destinationObj.transform.position.y) , 6 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerAction pa = collision.gameObject.GetComponent<PlayerAction>();
        if (pa != null)
        {
            pa.spaceClicked += moveToDestination;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerAction pa = collision.gameObject.GetComponent<PlayerAction>();
        if (pa != null)
        {
            pa.spaceClicked -= moveToDestination;
        }
    }

    private void moveToDestination()
    {
        act = true;
    }

}
