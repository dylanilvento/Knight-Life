using UnityEngine;
using System.Collections;

public class CoffeeMakerScript : MonoBehaviour {
	public GameObject cup;
	GameObject collidedWith;
	bool started = false;
	Animator anim;
	DayKeeper dayKeeper;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		dayKeeper = GameObject.Find("Time Keeper").GetComponent<DayKeeper>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (collidedWith != null) {
			if (collidedWith.name == "Player" && Input.GetButtonDown("Interact") && !started) {
				if (dayKeeper.GetCurrentDay().Equals("Day 2")) {
					StartCoroutine("CreateCoffee");
				}
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		collidedWith = other.gameObject;
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.name.Equals("Player")) {
			collidedWith = other.gameObject;
		}

		else {
			collidedWith = null;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		collidedWith = null;
	}

	IEnumerator CreateCoffee () {
		started = true;
		float coffeeStart = Time.realtimeSinceStartup;
		anim.SetBool("CoffeeOn", true);

		GameObject coffeeMug = (GameObject) Instantiate (cup, transform.position, Quaternion.identity);
		coffeeMug.GetComponent<Rigidbody2D>().velocity = new Vector2(-6f, 3.5f);
		//foodClone.name = "Bread";

		while (Time.realtimeSinceStartup - coffeeStart < 30f) {
			yield return new WaitForSeconds(1f);
			anim.SetTrigger("Drip");
		}
	}
}
