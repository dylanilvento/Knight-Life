using UnityEngine;
using System.Collections;

public class SandwichScript : MonoBehaviour {

	public AudioClip eat;
	GameObject collidedWith, parent;
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
			if ((collidedWith.name.Equals("Player") || collidedWith.name.Equals("Weapon Collider")) && Input.GetButtonDown("Interact")) {
				Eat();

			}
		}
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name.Equals("Player")) {
			collidedWith = other.gameObject;
		}
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.name.Equals("Player")) {
			collidedWith = other.gameObject;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.name.Equals("Player")) {
			collidedWith = null;
		}
	}

	void Eat() {
		AudioSource.PlayClipAtPoint(eat, transform.position);
		Destroy(parent);
		dayKeeper.days.currDay.SetMadeFood(true);

		//Destroy(this.gameObject);
	}
}
