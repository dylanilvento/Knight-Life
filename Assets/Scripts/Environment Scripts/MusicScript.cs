using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {
	float totalTime;
	AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayMusic () {
		audio.Play();

	}

	public void StopMusic () {
		audio.Stop();
	}

	public void PlayMusic (float waitTime) {
		audio.PlayDelayed(waitTime);
	}

	//totalTime in milliseconds
	public void FadeOutMusic (float totalTime) {

		this.totalTime = totalTime;
		StartCoroutine("FadeOut");
	}

	IEnumerator FadeOut () {
		float secTime = totalTime / 1000f;

		//for time
		float interval = secTime / 100;

		while (audio.volume >= 0.01f) {
			audio.volume -= 0.01f;
			yield return new WaitForSeconds(interval);
		}
	}

	public void FadeInMusic (float delay, float maxVol) {
		print("Test");
		audio.volume = 0f;
		//audio.Play();
		//this.totalTime = totalTime;
		StartCoroutine(FadeIn(delay, maxVol));
	}

	IEnumerator FadeIn (float delay, float maxVol) {
		//float secTime = totalTime / 1000f;
		audio.PlayDelayed(delay);
		//for time
		//float interval = secTime / 100;
		yield return new WaitForSeconds(delay);
		
		while (audio.volume <= maxVol) {
			audio.volume += 0.01f;
			yield return new WaitForSeconds(0.1f);
		}
	}
}
