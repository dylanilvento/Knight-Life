using UnityEngine;
using System.Collections;
using System;

public class FridgeScript : MonoBehaviour {

	GameObject collidedWith;
	SpriteRenderer sr;
	public Sprite closed;
	public Sprite open;

	public AudioClip fridgeOpenSound;

	public GameObject lettuce;
	public GameObject mayo;
	public GameObject bread;
	public GameObject chicken;
	public GameObject sandwich;

	public static GameObject test;

	BoxCollider2D fridgeDoor;

	//Timeline timeline;
	DayKeeper dayKeeper;

	GameObject foodClone;
	GameObject houseInterior;

	bool opened = false;

	//chicken, mayo, bread, lettuce
	public bool[] foodOpened = {false, false, false, false};

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		fridgeDoor = GameObject.Find("Fridge Door Collider").GetComponent<BoxCollider2D>();
		houseInterior = GameObject.Find("House Interior");
		//timeline = GameObject.Find("Time Keeper").GetComponent<Timeline>();
		dayKeeper = GameObject.Find("Time Keeper").GetComponent<DayKeeper>();

		//test = Timeline.GetTest();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (collidedWith != null) {
			if (collidedWith.name == "Player" && Input.GetButtonDown("Interact") && !opened) {
				if (dayKeeper.GetCurrentDay().Equals("Day 1")) {
					StartCoroutine("SpawnFood");	
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

	IEnumerator SpawnFood () {
		sr.sprite = open;
		fridgeDoor.enabled = true;
		AudioSource.PlayClipAtPoint(fridgeOpenSound, transform.position);
		opened = true;

		//if (timeline.)

		if (dayKeeper.GetCurrentDay().Equals("Day 1")) {//days.GetCurrentDay.Equals("Day 1")) {
			//chicken, mayo, bread, lettuce
			bool[] foodLaunched = {false, false, false, false};
			int launchNum;
			int cnt = 0;
			while (Array.Exists(foodLaunched, element => element == false)) {
		
				launchNum = Mathf.FloorToInt(UnityEngine.Random.Range(0f, 3.9f));
	
				if (launchNum == 0 && !foodLaunched[0]) {
					foodClone = (GameObject) Instantiate (chicken, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					foodClone.name = "Chicken";
					FoodVelocity(cnt);
					cnt++;
					foodLaunched[0] = true;
					yield return new WaitForSeconds(0.2f);
				}
	
				else if (launchNum == 1 && !foodLaunched[1]) {
					foodClone = (GameObject) Instantiate (mayo, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					foodClone.name = "Mayo";
					FoodVelocity(cnt);
					cnt++;
					foodLaunched[1] = true;
					yield return new WaitForSeconds(0.2f);
				}
	
				else if (launchNum == 2 && !foodLaunched[2]) {
					foodClone = (GameObject) Instantiate (bread, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					foodClone.name = "Bread";
					FoodVelocity(cnt);
					cnt++;
					foodLaunched[2] = true;
					yield return new WaitForSeconds(0.2f);
				}
	
				else if (launchNum == 3 && !foodLaunched[3]) {
					foodClone = (GameObject) Instantiate (lettuce, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					foodClone.name = "Lettuce";
					FoodVelocity(cnt);
					cnt++;
					foodLaunched[3] = true;
					yield return new WaitForSeconds(0.2f);
				}
	
				foodClone.transform.parent = houseInterior.transform;
					
				}
			}

	}

	void FoodVelocity (int cnt) {
		if (cnt == 0) {
			foodClone.GetComponent<Rigidbody2D>().velocity = new Vector2(9.1f, 8.0f);
			//cnt++;
		}

		else if (cnt == 1) {
			foodClone.GetComponent<Rigidbody2D>().velocity = new Vector2(7.5f, 8.0f);
			//cnt++;
		}

		else if (cnt == 2) {
			foodClone.GetComponent<Rigidbody2D>().velocity = new Vector2(5.5f, 8.0f);
			//cnt++;
		}

		else if (cnt == 3) {
			foodClone.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 8.0f);
			//cnt++;
		}
	}

	public void SetFoodOpened (int index, bool val) {
		foodOpened[index] = val;

		if (!(Array.Exists(foodOpened, element => element == false))) {

			foodClone = (GameObject) Instantiate (sandwich, new Vector2(transform.position.x + 5f, transform.position.y), Quaternion.identity);
			foodClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.5f, 20f);
			//timeline.SetMadeFood(true);

		}

	}

	public void CloseFridge () {
		sr.sprite = closed;
	}



}
