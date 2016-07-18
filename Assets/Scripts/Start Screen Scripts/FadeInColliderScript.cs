using UnityEngine;
using System.Collections;

public class FadeInColliderScript : MonoBehaviour {
	
	//MiniPlayerScript playerScript;
	KnightLifeLogoScript logoScript;
	WantedTextScript wantedScript;

	bool fadeActive = false;
	// Use this for initialization
	void Start () {

		//playerScript = GameObject.Find("Start Screen Hero").GetComponent<MiniPlayerScript>();
		logoScript = GameObject.Find("Knight Life Logo").GetComponent<KnightLifeLogoScript>();
		wantedScript = GameObject.Find("Wanted Text").GetComponent<WantedTextScript>();

	}
	
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name.Equals("Start Screen Hero") /*&& !fadeActive*/) {
			//print("collided");

			fadeActive = true;
			wantedScript.FadeOut();

			logoScript.FadeIn();
			
			//StartCoroutine("WantedTextFadeUp");
		}
	}
}
