using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour {

	public static PanelController instance;
	public Sprite dogSprite;
	public Sprite humanSprite;
	UITypewriterEffect typewriter;
	Image i;
	Text text;

    Coroutine clearing;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else
			Destroy(this);
	}

	void Start()
	{
		//i = GetComponentsInChildren<Image>()[0];
		i = transform.Find("Image").gameObject.GetComponent<Image>();
		//text = GetComponentInChildren<Text>();
		typewriter = GetComponentsInChildren<UITypewriterEffect>()[0];
	}

	public void Dog(string text)
    {
        if (clearing != null)
        {
            StopCoroutine(clearing);
        }
        i.gameObject.SetActive(true);
        typewriter.gameObject.SetActive(true);
        i.sprite = dogSprite;
		typewriter.ChangeText(text);
        clearing = StartCoroutine(Clear());
    }

	public void Human(string text)
    {
        if (clearing != null)
        {
            StopCoroutine(clearing);
        }
        i.gameObject.SetActive(true);
        typewriter.gameObject.SetActive(true);
        i.sprite = humanSprite;
		typewriter.ChangeText(text);
        clearing = StartCoroutine(Clear());
    }

    IEnumerator Clear()
    {
        yield return new WaitForSeconds(10);
        i.gameObject.SetActive(false);
        typewriter.gameObject.SetActive(false);
    }
}
