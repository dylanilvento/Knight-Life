using UnityEngine;
using System.Collections;

public class WardLogoScript : MonoBehaviour {

	Animator anim;
	bool runGlint = false;
	StartScreenScript startScript;

	SpriteRenderer sr;
	
	public AudioClip glint;
	public Sprite normalLogo, pixelLogo;
	MusicScript gleam;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		startScript = GameObject.Find("Start Screen").GetComponent<StartScreenScript>();
		//gleam = GameObject.Find("Gleam Sound").GetComponent<MusicScript>();
		audio = GetComponent<AudioSource>();
		sr = GetComponent<SpriteRenderer>();
		sr.sprite = normalLogo;
	}
	
	// Update is called once per frame
	void Update () {
		if (!runGlint) {
			StartCoroutine("AnimateLogo");
			runGlint = true;
		}
	}

	IEnumerator AnimateLogo() {
		yield return new WaitForSeconds(1.5f);
		anim.SetTrigger("Pixelate");
		yield return new WaitForSeconds(2.5f);
		//sr.sprite = pixelLogo;
		//yield return new WaitForSeconds(1.5f);
		anim.SetTrigger("Glint");
		//AudioSource.PlayClipAtPoint(glint, transform.position);
		audio.PlayOneShot(glint, 1f);
		//gleam.PlayMusic();
		
		yield return new WaitForSeconds(1f);

		float currentAlpha = 1f;

		for (int jj = 0; jj < 5; jj++) {

			currentAlpha -= 0.2f;

			Color currentColor = new Color(gameObject.GetComponent<Renderer>().material.color.r, gameObject.GetComponent<Renderer>().material.color.g, gameObject.GetComponent<Renderer>().material.color.b, currentAlpha);
			gameObject.GetComponent<Renderer>().material.color = currentColor;

			yield return new WaitForSeconds(0.05f);
		}

		startScript.StartIntro();
		Destroy(this.gameObject);
	}

}
