using UnityEngine;
using System.Collections;

public class FollowPlayerScript : MonoBehaviour {

	public string location;
	GameObject cam;
	//public GameObject collidedWith;
	CameraScript cameraScript;
	int exitCnt;

	public bool enteredLeft, enteredRight, exitedLeft, exitedRight;
	bool caveEntranceHit = false;

	// Use this for initialization
	void Start () {
		
		cam = GameObject.Find("Main Camera");
		cameraScript = (CameraScript)cam.GetComponent(typeof(CameraScript));
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		GameObject collidedWith = other.gameObject;
		if (!(this.gameObject.name.Equals("Camera Collider (Cave)"))) {
			ChangeFollow(collidedWith);
		}
		else if (caveEntranceHit) {
			ChangeFollow(collidedWith);
		}
		
	}

	void OnTriggerExit2D (Collider2D other) {
		GameObject collidedWith = other.gameObject;
		if (collidedWith.name.Equals("Player")) {
			exitCnt++;
			
			if (!cameraScript.GetFollowPlayer() && exitCnt == 4){
				if (!location.Equals("Cave")) {
					cameraScript.SetFollowPlayer(true);
					exitCnt = 0;
				}
			}

			if (enteredRight && (collidedWith.transform.position.x > transform.position.x)) {
				cameraScript.SetFollowPlayer(true);
				exitCnt = 0;
				enteredRight = false;
			}

			else if (enteredLeft && (collidedWith.transform.position.x < transform.position.x)) {
				cameraScript.SetFollowPlayer(true);
				exitCnt = 0;
				enteredLeft = false;
			}
		}

		//collidedWith = null;
	}

	void ChangeFollow (GameObject go) {
		if (go.name.Equals("Player")) {
			if (cameraScript.GetFollowPlayer()) {
				cameraScript.SetFollowPlayer(false);
				//collided = true;
			}
			if ((go.transform.position.x > transform.position.x) && !enteredLeft) {
				enteredRight = true;
			}

			else if ((go.transform.position.x < transform.position.x) && !enteredRight) {
				enteredLeft = true;
			}
		}
	}

	public void SetCaveEntranceHit (bool val) {
		caveEntranceHit = val;
	}
}
