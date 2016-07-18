using UnityEngine;
using System.Collections;

public class OutroFadeColliderScript : MonoBehaviour {
	
	//MiniPlayerScript playerScript;
	StartScreenMusicScript musicScript;
	ChangeScreenScript screenScript;

	bool fadeActive = false;
	// Use this for initialization
	void Start () {

		//playerScript = GameObject.Find("Start Screen Hero").GetComponent<MiniPlayerScript>();
		musicScript = GameObject.Find("Start Screen Music").GetComponent<StartScreenMusicScript>();
		//wantedScript = GameObject.Find("Wanted Text").GetComponent<WantedTextScript>();
		screenScript = GameObject.Find("Change Screen Trigger").GetComponent<ChangeScreenScript>();
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name.Equals("Start Screen Hero") /*&& !fadeActive*/) {
			//print("collided");

			musicScript.OutroFadeIn();
			screenScript.SetOutroStartTime(Time.realtimeSinceStartup);
			//StartCoroutine("WantedTextFadeUp");
		}
	}
}
