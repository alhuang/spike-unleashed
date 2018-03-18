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
		i = GetComponentInChildren<Image>();
		//text = GetComponentInChildren<Text>();
		typewriter = GetComponentInChildren<UITypewriterEffect>();
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
