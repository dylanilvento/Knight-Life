using UnityEngine;
using System.Collections;

public class CoffeeColliderScript : MonoBehaviour {

	// Use this for initialization
	public AudioClip slurp;
	public GameObject collidedWith;
	GameObject parent;
	//Timeline timeline;
	DayKeeper dayKeeper;

	// Use this for initialization
	void Start () {
		parent = transform.parent.gameObject;
	//	timeline = GameObject.Find("Time Keeper").GetComponent<Timeline>();
		dayKeeper = GameObject.Find("Time Keeper").GetComponent<DayKeeper>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (collidedWith != null) {
			if (((collidedWith.name.Equals("Player") && Input.GetButtonDown("Interact")) || collidedWith.name.Equals("Weapon Collider"))) {
				Drink();

			}
		}
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name.Equals("Player")) {
			collidedWith = other.gameObject;
			//print("enter");
		}
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.name.Equals("Player")) {
			collidedWith = other.gameObject;
		//	print("stay");
		}
		else {
			collidedWith = null;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.name.Equals("Player")) {
			collidedWith = null;
			//print("exit");
		}
	}

	void Drink() {
		AudioSource.PlayClipAtPoint(slurp, transform.position);
		Destroy(parent);
		dayKeeper.days.currDay.SetMadeFood(true);

		//Destroy(this.gameObject);
	}
}
