using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartScreenScript : MonoBehaviour {
	public Renderer[] startObjects = new Renderer[8];
	public Text wantedText;

	//MusicScript startMusicIntro;
	//MusicScript startMusicLoop;
	StartScreenMusicScript startMusic;

	KnightLifeLogoScript flagScript;

	// Use this for initialization
	void Start () {
		//startMusicIntro = GameObject.Find("Start Screen Music Intro").GetComponent<MusicScript>();
		//startMusicLoop = GameObject.Find("Start Screen Music Loop").GetComponent<MusicScript>();
		startMusic = GameObject.Find("Start Screen Music").GetComponent<StartScreenMusicScript>();

		flagScript = GameObject.Find("Knight Life Logo").GetComponent<KnightLifeLogoScript>();
		wantedText.color = new Color (wantedText.color.r, wantedText.color.g, wantedText.color.b, 0f);

		for (int ii = 0; ii < startObjects.Length; ii++) {
			Color startColor = new Color(startObjects[ii].material.color.r, startObjects[ii].material.color.g, startObjects[ii].material.color.b, 0.0f);
			startObjects[ii].material.color = startColor;
		}

		//print(MyTestDLL.DLLClass.GetRandom());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartIntro () {
		
		StartCoroutine("FadeIn");
	}

	IEnumerator FadeIn() {
		float cnt = 0.0f;
		//float timeTest = Time.realtimeSinceStartup;
		//print("Test started at " + timeTest);
		yield return new WaitForSeconds(0.75f);
		//print(cnt);
		//startMusicIntro.PlayMusic();
		startMusic.PlayIntro();
		yield return new WaitForSeconds(3f);
		//print(Time.realtimeSinceStartup - timeTest + " seconds have passed");
		cnt += 5f;
		
		float currentAlpha = 0.0f;

		flagScript.AnimateTailFlap();

		for (int jj = 0; jj < 200; jj++) {

			currentAlpha += 0.005f;

			for (int ii = 0; ii < startObjects.Length; ii++) {
				Color currentColor = new Color(startObjects[ii].material.color.r, startObjects[ii].material.color.g, startObjects[ii].material.color.b, currentAlpha);
				startObjects[ii].material.color = currentColor;
			}

			yield return new WaitForSeconds(0.005f);
			cnt += 0.005f;

		}
		//print("cnt: " + cnt);
		flagScript.StartAnimation();
	}
}
