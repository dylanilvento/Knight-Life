using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CastleEntranceScript : MonoBehaviour {

	//Text wantedText;

	MiniPlayerScript playerScript;
	KnightLifeLogoScript logoScript;
	WantedTextScript wantedScript;

	bool fadeActive = false;
	// Use this for initialization
	void Start () {

		playerScript = GameObject.Find("Start Screen Hero").GetComponent<MiniPlayerScript>();
		logoScript = GameObject.Find("Knight Life Logo").GetComponent<KnightLifeLogoScript>();
		wantedScript = GameObject.Find("Wanted Text").GetComponent<WantedTextScript>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name.Equals("Start Screen Hero") && !fadeActive) {
			fadeActive = true;
			logoScript.FadeOut();
			wantedScript.FadeIn();
			//StartCoroutine("WantedTextFadeUp");
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.name.Equals("Start Screen Hero")) {
			//playerScript.SetVelocityX(0f);
			//other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, GetComponent<Rigidbody2D>().velocity.y);
			playerScript.SetGoLeftRight();
		}
	}
}
