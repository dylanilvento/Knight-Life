using UnityEngine;
using System.Collections;

public class BedScript : MonoBehaviour {

	GameObject collidedWith;
	//Timeline timeline;
	// Use this for initialization
	DayKeeper dayKeeper;
	PlayerScript playerScript;

	void Start () {
		//timeline = GameObject.Find("Time Keeper").GetComponent<Timeline>();
		dayKeeper = GameObject.Find("Time Keeper").GetComponent<DayKeeper>();
		playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (collidedWith != null) {
			if (dayKeeper.days.currDay.GetMadeFood() && dayKeeper.days.currDay.GetWatchedTV()) {
				if (collidedWith.name.Equals("Player") && Input.GetButtonDown("Interact")) {
					dayKeeper.days.currDay.SetSlept(true);
					if (dayKeeper.days.GetCurrentDay().Equals("Day 1")) {
						playerScript.SetRobed(true);	
					}
				}
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.name.Equals("Player")) {
			collidedWith = other.gameObject;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		collidedWith = null;
	}

}
