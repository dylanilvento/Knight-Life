using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	int animCnt = 0;
	bool animStarted = false;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		if (!animStarted) {
			
			animCnt++;
			
			if (animCnt == 15) {
				Destroy(this.gameObject);
			}
		}
	
	}
}
