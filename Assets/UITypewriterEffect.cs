using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// attach to UI Text component (with the full text already there)

public class UITypewriterEffect : MonoBehaviour 
{

	Text txt;
	string story;

    Coroutine playingText;

	void Awake()
	{
		txt = GetComponent<Text>();
		story = txt.text;
		txt.text = "";

		// TODO: add optional delay when to start
		//StartCoroutine("PlayText");
	}

	public void ChangeText(string dialogue)
	{
		txt = GetComponent<Text>();
		story = dialogue;
		txt.text = "";

        if (playingText != null)
        {
            StopCoroutine(playingText);
        }

		// TODO: add optional delay when to start
		playingText = StartCoroutine("PlayText");
	}

	IEnumerator PlayText()
	{
		foreach (char c in story)
		{
			txt.text += c;
			yield return new WaitForSeconds(0.05f);
		}
	}

}
