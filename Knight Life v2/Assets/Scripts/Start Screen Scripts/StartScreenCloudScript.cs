using UnityEngine;
using System.Collections;

public class StartScreenCloudScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("Movement");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Movement () {
		while (true) {
			yield return new WaitForSeconds(0.75f);
			//GetComponent<Rigidbody2D>().velocity = new Vector2(0.5f, GetComponent<Rigidbody2D>().velocity.y);
			gameObject.transform.position = new Vector2(gameObject.transform.position.x + 0.3f, gameObject.transform.position.y);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.name.Equals("Start Screen Cloud Collider")) {
			gameObject.transform.position = new Vector2(gameObject.transform.position.x - 40f, gameObject.transform.position.y);
		}
	}
}
