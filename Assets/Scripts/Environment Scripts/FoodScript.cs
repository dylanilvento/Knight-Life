using UnityEngine;
using System.Collections;

public class FoodScript : MonoBehaviour {

	string foodName;

	SpriteRenderer sr;
	FridgeScript fridgeScript;

	public Sprite newFood;
	public GameObject[] extras = new GameObject[5];
	public AudioClip hitSound;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		fridgeScript = GameObject.Find("Fridge").GetComponent<FridgeScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenFood (string name) {
		foodName = name;
		switch (name) {
			case "Mayo":
				StartCoroutine("OpenMayo");
				//OpenMayo();
				break;
			case "Bread":
				StartCoroutine("OpenBread");
				break;
			case "Chicken":
				StartCoroutine("OpenChicken");
				break;
			case "Lettuce":
				StartCoroutine("OpenLettuce");
				break;
			default:
				break;
		}
	}

	IEnumerator OpenMayo () {
		GameObject lid, mayoSpec;
		sr.sprite = newFood;
		AudioSource.PlayClipAtPoint(hitSound, transform.position);

		lid = (GameObject) Instantiate (extras[0], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
		lid.name = "Mayo Lid";
		lid.GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f, 10.0f);
		lid.GetComponent<Rigidbody2D>().angularVelocity = 120.0f;

		for (int i = 0; i < 5; i++) {
			yield return new WaitForSeconds(0.001f);
			mayoSpec = (GameObject) Instantiate (extras[Mathf.FloorToInt(Random.Range (1f, 3.9f))], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
			mayoSpec.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range (-2.5f, 2.5f), Random.Range (12.0f, 16.0f));
			mayoSpec.GetComponent<Rigidbody2D>().angularVelocity = Random.Range (90.0f, 120.0f);
		}

		fridgeScript.SetFoodOpened(1, true);
	}

	IEnumerator OpenBread () {
		GameObject breadSpec;
		//print("OPENED " + foodName);
		sr.sprite = newFood;
		AudioSource.PlayClipAtPoint(hitSound, transform.position);

		for (int i = 0; i < 5; i++) {
			yield return new WaitForSeconds(0.001f);
			breadSpec = (GameObject) Instantiate (extras[Mathf.FloorToInt(Random.Range (0f, 2.9f))], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
			breadSpec.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range (-2.5f, 2.5f), Random.Range (12.0f, 16.0f));
			breadSpec.GetComponent<Rigidbody2D>().angularVelocity = Random.Range (90.0f, 120.0f);
		}

		fridgeScript.SetFoodOpened(2, true);

		//yield return new WaitForSeconds(0.05f);

	}

	IEnumerator OpenChicken () {
		GameObject chickenSpec;
		//print("OPENED " + foodName);
		sr.sprite = newFood;
		AudioSource.PlayClipAtPoint(hitSound, transform.position);

		for (int i = 0; i < 5; i++) {
			yield return new WaitForSeconds(0.001f);
			chickenSpec = (GameObject) Instantiate (extras[Mathf.FloorToInt(Random.Range (0f, 2.9f))], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
			chickenSpec.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range (-2.5f, 2.5f), Random.Range (12.0f, 16.0f));
			chickenSpec.GetComponent<Rigidbody2D>().angularVelocity = Random.Range (90.0f, 120.0f);
		}

		fridgeScript.SetFoodOpened(0, true);

		//yield return new WaitForSeconds(0.05f);
	}

	IEnumerator OpenLettuce () {
		GameObject lettuceSpec;
		//print("OPENED " + foodName);
		sr.sprite = newFood;
		AudioSource.PlayClipAtPoint(hitSound, transform.position);

		for (int i = 0; i < 5; i++) {
			yield return new WaitForSeconds(0.001f);
			lettuceSpec = (GameObject) Instantiate (extras[Mathf.FloorToInt(Random.Range (0f, 1.9f))], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
			lettuceSpec.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range (-2.5f, 2.5f), Random.Range (12.0f, 16.0f));
			lettuceSpec.GetComponent<Rigidbody2D>().angularVelocity = Random.Range (90.0f, 120.0f);
		}

		fridgeScript.SetFoodOpened(3, true);

		//yield return new WaitForSeconds(0.05f);
	}
}
