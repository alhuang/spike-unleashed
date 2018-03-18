using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairdryerAction : MonoBehaviour {

    public GameObject destinationObj;
	public GameObject sparks;
	public GameObject lights;
	public AudioClip electrocution;

	private bool canMove = false;
    private bool act = false;
	public float flickertime = 0.1f;

    private PlayerAction pa;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

	IEnumerator HairDryer()
	{
        PanelController.instance.SFX("Bzzt...        Bzzt...        BZZT");
		while (act)
		{
			if (gameObject.transform.position == destinationObj.transform.position)
			{
				act = false;
				Instantiate(sparks, destinationObj.transform.position, Quaternion.identity);
			}
			else
				transform.position = Vector3.Lerp(transform.position, destinationObj.transform.position, 6 * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
		AudioSource.PlayClipAtPoint(electrocution, Camera.main.transform.position);
		lights.SetActive(true);
		yield return new WaitForSeconds(flickertime);
		lights.SetActive(false);
		yield return new WaitForSeconds(flickertime);
		lights.SetActive(true);
		yield return new WaitForSeconds(flickertime);
		lights.SetActive(false);
        PanelController.instance.Human("Oh no... I didn't save... *sigh* time to get the breaker");
		yield return new WaitForSeconds(flickertime);
		lights.SetActive(true);
		yield return new WaitForSeconds(flickertime);
		lights.SetActive(false);
		yield return new WaitForSeconds(flickertime);
		lights.SetActive(true);
		canMove = true;


	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger)
        {
            pa = collision.gameObject.GetComponent<PlayerAction>();
            if (pa != null)
            {
                pa.spaceClicked += moveToDestination;
                PanelController.instance.Dog("*Woof* Oh this thing... It's always so loud... *Woof*");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger)
        {
            PlayerAction pa = collision.gameObject.GetComponent<PlayerAction>();
            if (pa != null)
            {
                pa.spaceClicked -= moveToDestination;
                PanelController.instance.ClearNow();
            }
        }
    }

    private void moveToDestination()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        pa.spaceClicked -= moveToDestination;
		act = true;
		StartCoroutine(HairDryer());
    }

	public bool CanMove()
	{
		return canMove;
	}
}
