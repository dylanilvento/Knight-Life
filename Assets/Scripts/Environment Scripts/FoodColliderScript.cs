using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FoodColliderScript : MonoBehaviour {

	public GameObject counter, parentFood;
	Rigidbody2D rb;
	public bool opened = false;

	public FoodScript foodScript;

	public GameObject collidedWith;

	//FridgeScript fridgeScript;

	string foodName;
	//public Text uiText, uiTextBG;

	// Use this for initialization
	void Start () {
		parentFood = transform.parent.gameObject;
		foodName = parentFood.name;//GetFoodName(parentFood.name);
		foodScript = parentFood.GetComponent<FoodScript>();
		
		

	}
	
	// Update is called once per frame
	void Update () {
		if (collidedWith != null) {
			if (((collidedWith.name.Equals("Player") && Input.GetButtonDown("Interact")) || collidedWith.name.Equals("Weapon Collider"))  && !opened) {
				
				foodScript.OpenFood(foodName);
				//fridgeScript()
				opened = true;

			}
		}

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name.Equals("Player")) {
			collidedWith = other.gameObject;
		}
		
		//print(foodName + " collided with " + collidedWith.name);

	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.name.Equals("Player")) {
			collidedWith = other.gameObject;
		}

		/*else {
			collidedWith = null;
		}*/
		//print(foodName + " collided with " + collidedWith.name);

	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.name.Equals("Player")) {
			collidedWith = null;
		}
	}

	public string GetFoodName (string objString) {
		int strLength = 0;
		for (int i = 0; i < objString.Length; i++) {
			if (objString.Substring(i, 1).Equals("(")) {
				strLength = i;
			}
		}
		return objString.Substring(0, strLength);
	}
}
