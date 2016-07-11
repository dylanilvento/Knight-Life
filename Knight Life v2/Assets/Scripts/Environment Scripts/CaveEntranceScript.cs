using UnityEngine;
using System.Collections;

public class CaveEntranceScript : MonoBehaviour {

	GameObject cam;
	CameraScript cameraScript;
	FollowPlayerScript followCollider;

	// Use this for initialization
	void Start () {

		cam = GameObject.Find("Main Camera");
		cameraScript = (CameraScript) cam.GetComponent(typeof(CameraScript));
		followCollider = GameObject.Find("Camera Collider (Cave)").GetComponent<FollowPlayerScript>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (!(cameraScript.GetFollowPlayer())) {
			cameraScript.CenterOnPlayer();
			followCollider.SetCaveEntranceHit(true);
		}

	}
}
