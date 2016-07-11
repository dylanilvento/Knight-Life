using UnityEngine;
using System.Collections;

public class ChangeScreenScript : MonoBehaviour {
	float startTime, currTime;
	Camera startCam, mainCam;
	GameObject collidedWith;
	PlayerScript playerScript;
	bool startEnded = false;
	// Use this for initialization
	void Start () {

		startCam = GameObject.Find("Start Screen Camera").GetComponent<Camera>();
		mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
		playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		collidedWith = other.gameObject;

		if (other.gameObject.name.Equals("Start Screen Hero")) {
			ChangeScreen();
		}
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.name.Equals("Start Screen Hero")) {
			ChangeScreen();
		}
	}

	public void SetOutroStartTime (float startTime) {
		this.startTime = startTime;
	}

	void ChangeScreen () {
		if (((Time.realtimeSinceStartup - startTime) >= 12.582f) && !startEnded) {

			startEnded = true;
			startCam.enabled = false;
			mainCam.enabled = true;
			playerScript.StartBossFight();

		}
	}
}
