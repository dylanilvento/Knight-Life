using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	int animCnt = 0;
	bool animStarted = false;

	// Use this for initialization
	void Start () {

		StartCoroutine(WaitToDestroy());
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	IEnumerator WaitToDestroy()
	{
		yield return new WaitForSeconds(1.5f);
		Destroy(this.gameObject);
	}
}
