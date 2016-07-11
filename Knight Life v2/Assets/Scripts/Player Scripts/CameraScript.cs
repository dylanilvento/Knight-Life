using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Transform target;
	Vector3 relPos, endPos;
	float maxSpeed = 5f;

	public bool followPlayer;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		if (followPlayer){

			transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);// - relPos;
		}
		else {

			endPos = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
		}

	}

	public void CenterOnPlayer () {


		StartCoroutine("MoveToCharacter");


	}

	IEnumerator MoveToCharacter() {

		//Vector3 startPos = transform.position;
		//Vector3 velocity = Vector3.zero;

		float i = 0f;
		//float lerpTime = 0.75f;
    	//float currentLerpTime = 0f;

    	//float lastGreatestI = 0f;
		
    	while (endPos.x - transform.position.x > 0.05f) {

				yield return new WaitForSeconds(0.01f);
				
				i += Time.deltaTime * 0.5f;
		
				transform.position = new Vector3(transform.position.x + (maxSpeed * Time.deltaTime), transform.position.y, transform.position.z);
			
		}

		followPlayer = true;

	}
	
	public void SetFollowPlayer (bool val) {

		followPlayer = val;

	}

	public bool GetFollowPlayer () {
		
		return followPlayer;
		
	}

	
}