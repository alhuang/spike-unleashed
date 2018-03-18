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

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else
			Destroy(this);
	}

	void Start()
	{
		i = GetComponentsInChildren<Image>()[0];
		//text = GetComponentInChildren<Text>();
		typewriter = GetComponentsInChildren<UITypewriterEffect>()[0];
	}

	public void Dog(string text)
	{
		i.sprite = dogSprite;
		typewriter.ChangeText(text);
	}

	public void Human(string text)
	{
		i.sprite = humanSprite;
		typewriter.ChangeText(text);
	}
}
