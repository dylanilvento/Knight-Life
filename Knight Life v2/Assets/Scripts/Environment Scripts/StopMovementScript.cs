using UnityEngine;
using System.Collections;

public class StopMovementScript : MonoBehaviour {


	GameObject player;
	PlayerScript playerScript;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		player = other.gameObject;
		playerScript = (PlayerScript) player.GetComponent(typeof (PlayerScript));

		if (player.transform.position.x < transform.position.x) {
			playerScript.SetStopMvmtRight(true);
		}
		else if (player.transform.position.x > transform.position.x) {
			playerScript.SetStopMvmtLeft(true);
		}

		
	}

	void OnTriggerExit2D (Collider2D other) {
		playerScript.SetStopMvmtRight(false);
		playerScript.SetStopMvmtLeft(false);
		
	}
}
