using UnityEngine;
using System.Collections;

public class StartScreenMusicScript : MonoBehaviour {

	float totalTime;

	public AudioClip[] clips = new AudioClip[3];
	AudioSource[] sources = new AudioSource[3];
	// Use this for initialization
	void Start () {

     	for (int ii = 0; ii < 3; ii++)
     	{
	        sources[ii] = gameObject.AddComponent<AudioSource>();
	        sources[ii].mute = true;
	        sources[ii].clip = clips[ii];
	        sources[ii].playOnAwake = false;
	        //print(sources[ii].clip.name);
	        // set up the properties such as distance for 3d sounds here if you need to.
	    }

	    //sources[1].volume = 0.5f;
	    sources[1].loop = true;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayIntro () {
		//sources[0].mute = false;
		StartCoroutine("Intro");
		//sources[0].Play();
		//sources[0].mute = false;
		//sources[0].PlayOneShot(clips[0]);
		//sources[0].PlayDelayed(0.001f);
		//AudioSource.PlayClipAtPoint(clips[0], transform.position);
	}

	IEnumerator Intro () {
		sources[0].Play();
		yield return new WaitForSeconds(0.5f);

		sources[0].mute = false;
		StartCoroutine("LoopFadeIn");
	}

	public void FadeInLoop (float totalTime) {
		this.totalTime = totalTime;
		StartCoroutine("LoopFadeIn");
	}

	IEnumerator LoopFadeIn () {
		float secTime = totalTime / 1000f;

		//for time
		float interval = secTime / 100;

		//sources[1].mute = false;
		yield return new WaitForSeconds(6f);
		sources[1].Play();

		//print("intro loop played");

		//float cnt = 0.0f;

		yield return new WaitForSeconds(0.1f);
		sources[1].mute = false;

	}

	public void OutroFadeIn () {
		StartCoroutine("FadeInOutro");
	}

	IEnumerator FadeInOutro () {
		sources[2].volume = 0f;
		sources[2].Play();
		sources[2].mute = false;

		while (sources[1].volume >= 0.01f || sources[2].volume <= 0.99f) {
			sources[1].volume -= 0.05f;
			sources[2].volume += 0.08f;
			yield return new WaitForSeconds(0.005f);
			
		}
	}
}
