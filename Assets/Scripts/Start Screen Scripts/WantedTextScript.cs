using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WantedTextScript : MonoBehaviour {

	Text text;
	// Use this for initialization
	void Start () {

		text = gameObject.GetComponent<Text>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FadeIn () {
		StartCoroutine("TextFadeIn");
	}


	IEnumerator TextFadeIn () {
		float currentAlpha = 0.0f;

		yield return new WaitForSeconds(0.5f);

		while (currentAlpha < 1.0f) {
			currentAlpha += 0.1f;
			//print("Logo alpha is " + currentAlpha);
			text.color = new Color(text.color.r, text.color.g, text.color.b, currentAlpha);
			yield return new WaitForSeconds(0.05f);
		}
	}

	public void FadeOut () {
		StartCoroutine("TextFadeOut");
	}


	IEnumerator TextFadeOut () {
		float currentAlpha = 1.0f;

		//yield return new WaitForSeconds(0.5f);

		while (currentAlpha != 0f) {
			currentAlpha -= 0.1f;
			text.color = new Color(text.color.r, text.color.g, text.color.b, currentAlpha);
			yield return new WaitForSeconds(0.05f);
		}

		
	}
}
