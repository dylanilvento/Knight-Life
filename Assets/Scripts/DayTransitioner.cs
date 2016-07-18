using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DayTransitioner : MonoBehaviour {

	public GameObject dayBG;
	public GameObject dayText;

	DayKeeper dayKeeper;
	GameObject dayCntBG, dayCnt;

	GameObject player;
	Renderer playerRend;
	PlayerScript playerScript;
	FridgeScript fridgeScript;

	Renderer[] houseInterior;

	bool dayFinished;

	// Use this for initialization
	void Start () {

		dayKeeper = GetComponent<DayKeeper>();
		player = GameObject.Find("Player");
		playerRend = player.GetComponent<Renderer>();
		playerScript = player.GetComponent<PlayerScript>();
		fridgeScript = GameObject.Find("Fridge").GetComponent<FridgeScript>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (dayFinished == true && Input.GetButtonDown("Interact")) {
			ResetDay();
		}
	
	}

	public void DayTransition () {
		StartCoroutine("TransitionDay");
		//GameAnimation.Instance.GraphicFadeIn(dayBG.GetComponent<Image>());
		
	}

	IEnumerator TransitionDay () {
		float currentAlpha = 0.0f;
		float currTextPos = 200f;

		dayCntBG = (GameObject) Instantiate (dayBG, new Vector2(0f, 0f), transform.rotation);
		dayCntBG.transform.SetParent(GameObject.Find("Canvas").transform, false);
		Image img = dayCntBG.GetComponent<Image>();
		img.color = new Color(img.color.r, img.color.g, img.color.b, 1f);

		dayCnt = (GameObject) Instantiate (dayText, new Vector2(0f, 0f), transform.rotation);
		dayCnt.transform.SetParent(GameObject.Find("Canvas").transform, false);
		dayCnt.transform.localPosition = new Vector2(currTextPos, 0f);
		//dayCnt.GetComponent<RectTransform>().localPosition = new Vector2(75f, 0f);
		Text cntText = dayCnt.GetComponent<Text>();
		cntText.text = dayKeeper.days.GetNextDay();
		cntText.color = new Color(cntText.color.r, cntText.color.g, cntText.color.b, currentAlpha);

		while (currentAlpha < 1.0f) {
			currentAlpha += 0.1f;
			currTextPos -= 5f;
			dayCnt.transform.localPosition = new Vector2(currTextPos, 0f);
			//img.color = new Color(img.color.r, img.color.g, img.color.b, currentAlpha);
			cntText.color = new Color(cntText.color.r, cntText.color.g, cntText.color.b, currentAlpha);
			yield return new WaitForSeconds(0.05f);
		}
		dayKeeper.IncrementDay();
		dayFinished = true;

		//yield return new WaitForSeconds(0.05f);
	}

	//called by TVScrip.cs
	public void PassTime (Renderer[] sky, float start, float end, float rate) {
		print("Pass time activated");
		houseInterior = GameObject.Find("House Interior").GetComponentsInChildren<Renderer>();
		StartCoroutine(TimePass(sky, start, end, rate));

	}

	IEnumerator TimePass (Renderer[] sky, float start, float end, float rate) {
		float currentAlpha = 0.0f;
		float currentRBG = start;
		float endRBG = end;
		float changeRate = rate;
		
		while (currentAlpha < 1.0f && endRBG < currentRBG) {
			currentRBG -= changeRate;
			currentAlpha += 0.1f;

			for (int ii = 0; ii < sky.Length; ii++) {
				sky[ii].material.color = new Color(1f, 1f, 1f, currentAlpha);
			}

			for (int ii = 0; ii < houseInterior.Length; ii++) {
				houseInterior[ii].material.color = new Color(currentRBG, currentRBG, currentRBG, 1f);
			}

			playerRend.material.color = new Color(currentRBG, currentRBG, currentRBG, 1f);

			yield return new WaitForSeconds(0.05f);
		}

	}

	public void ResetDay () {
		for (int ii = 0; ii < houseInterior.Length; ii++) {

			houseInterior[ii].material.color = new Color(1f, 1f, 1f, 1f);
		}

		playerRend.material.color = new Color(1f, 1f, 1f, 1f);

		if (dayKeeper.days.GetCurrentDay().Equals("Day 2")) {
			GameObject[] food = new GameObject[5];
			food[0] = GameObject.Find("Chicken");
			food[1] = GameObject.Find("Mayo");
			food[2] = GameObject.Find("Bread");
			food[3] = GameObject.Find("Lettuce");
			food[4] = GameObject.Find("Mayo Lid");

			for (int ii = 0; ii < food.Length; ii++) {
				Destroy(food[ii]);
			}

			fridgeScript.CloseFridge();
		}

		Destroy(dayCntBG);
		Destroy(dayCnt);

		dayFinished = false;

	}
}
