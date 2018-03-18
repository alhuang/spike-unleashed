﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// attach to UI Text component (with the full text already there)

public class UITypewriterEffect : MonoBehaviour 
{

	Text txt;
	string story;

	void Awake()
	{
		txt = GetComponent<Text>();
		story = txt.text;
		txt.text = "";

		// TODO: add optional delay when to start
		StartCoroutine("PlayText");
	}

	public void ChangeText(string dialogue)
	{
		txt = GetComponent<Text>();
		story = dialogue;
		txt.text = "";

		// TODO: add optional delay when to start
		StartCoroutine("PlayText");
	}

	IEnumerator PlayText()
	{
		foreach (char c in story)
		{
			txt.text += c;
			yield return new WaitForSeconds(0.125f);
		}
	}

}
