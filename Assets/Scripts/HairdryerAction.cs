using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairdryerAction : MonoBehaviour {

    public GameObject destinationObj;
	public GameObject sparks;
	public GameObject lights;
    private bool act = false;
	public float flickertime = 0.1f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

	IEnumerator HairDryer()
	{
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
		lights.SetActive(true);
		yield return new WaitForSeconds(flickertime);
		lights.SetActive(false);
		yield return new WaitForSeconds(flickertime);
		lights.SetActive(true);
		yield return new WaitForSeconds(flickertime);
		lights.SetActive(false);
		yield return new WaitForSeconds(flickertime);
		lights.SetActive(true);
		yield return new WaitForSeconds(flickertime);
		lights.SetActive(false);
		yield return new WaitForSeconds(flickertime);
		lights.SetActive(true);

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
		StartCoroutine(HairDryer());
    }

}
