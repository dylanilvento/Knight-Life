using UnityEngine;
using System.Collections;

public class ChangeScreenScript : MonoBehaviour {
	float startTime, currTime;
	Camera startCam, mainCam;
	GameObject collidedWith;
	PlayerScript playerScript;
	bool startEnded = false;
	bool entered = false;
	// Use this for initialization
	void Start () {

		startCam = GameObject.Find("Start Screen Camera").GetComponent<Camera>();
		mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
		playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (entered) {
			if (((Time.realtimeSinceStartup - startTime) >= 12.582f) && !startEnded) {
				print("called");
				ChangeScreen();
			}

		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		collidedWith = other.gameObject;

		if (other.gameObject.name.Equals("Start Screen Hero")) {
			entered = true;
			print("entered");
		}
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.name.Equals("Start Screen Hero")) {

			entered = true;
			print("entered");
		}
	}

	public void SetOutroStartTime (float startTime) {
		this.startTime = startTime;
	}

	void ChangeScreen () {
		startEnded = true;
		startCam.enabled = false;
		mainCam.enabled = true;
		playerScript.StartBossFight();

	}
}
