using UnityEngine;
using System.Collections;

public class WalkwayColliderScript : MonoBehaviour {
	public bool goLeft;
	public bool goRight;

	public GameObject ramp;
	//public GameObject activeRamp;
	//public GameObject deactiveRamp;

	MiniPlayerScript playerScript;
	// Use this for initialization
	void Start () {
		playerScript = GameObject.Find("Start Screen Hero").GetComponent<MiniPlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		//print("Hit collider");
		if (other.gameObject.name == "Start Screen Hero") {
			//print("Player hit");

			if (goLeft && !goRight) {
				playerScript.SetGoLeft(true);
				
			}
			else if (goRight && !goLeft) {
				playerScript.SetGoRight(true);
				
			}
			else if (goRight && goLeft) {
				playerScript.SetGoLeftRight();
			}
			else {
				print("Exlcusive side not set.");
			}

			if (!(ramp.GetComponent<PolygonCollider2D>().enabled)) {
					ramp.GetComponent<PolygonCollider2D>().enabled = true;
			}

			else {
				ramp.GetComponent<PolygonCollider2D>().enabled = false;
			}


		}
	}
}