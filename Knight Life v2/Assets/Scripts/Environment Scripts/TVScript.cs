using UnityEngine;
using System.Collections;

public class TVScript : MonoBehaviour {

	SpriteRenderer sr;
	public Sprite [] chair = new Sprite [2];

	GameObject tvScreen;
	SpriteRenderer tvSR;
	public GameObject tvStatic;
	GameObject staticClone;

	public AudioClip staticSound, click;

	public Renderer[] houseInterior;

	GameObject player;
	Renderer playerRend;
	PlayerScript playerScript;

	//Timeline timeline;

	//off, chan1, chan2, chan3
	public Sprite[] channels = new Sprite [4];
	int channelCnt = 0;
	bool seated = false;
	GameObject collidedWith;

	DayKeeper dayKeeper;
	DayTransitioner dayTrans;

	Renderer[] afternoonSky = new Renderer [3];
	Renderer[] nightSky = new Renderer [3];

	bool changingChannel = false;

	// Use this for initialization
	void Start () {
		tvScreen = GameObject.Find("TV Screen");
		tvSR = tvScreen.GetComponent<SpriteRenderer>();
		sr = GetComponent<SpriteRenderer>();
		player = GameObject.Find("Player");
		playerRend = player.GetComponent<Renderer>();
		playerScript = player.GetComponent<PlayerScript>();
		//timeline = GameObject.Find("Time Keeper").GetComponent<Timeline>();

		dayKeeper = GameObject.Find("Time Keeper").GetComponent<DayKeeper>();
		dayTrans = GameObject.Find("Time Keeper").GetComponent<DayTransitioner>();

		for (int ii = 1; ii <= afternoonSky.Length; ii++) {
			//print(ii);

			afternoonSky[ii - 1] = GameObject.Find("Afternoon Sky " + ii).GetComponent<Renderer>();
			nightSky[ii - 1] = GameObject.Find("Night Sky " + ii).GetComponent<Renderer>();

			afternoonSky[ii - 1].material.color = new Color(afternoonSky[ii - 1].material.color.r, afternoonSky[ii - 1].material.color.g, afternoonSky[ii - 1].material.color.b, 0f);
			nightSky[ii - 1].material.color = new Color(nightSky[ii - 1].material.color.r, nightSky[ii - 1].material.color.g, nightSky[ii - 1].material.color.b, 0f);
		
		}

		//houseInterior = GameObject.Find("House Interior").GetComponentsInChildren<Renderer>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (collidedWith != null) {
			if (collidedWith.name.Equals("Player") && Input.GetButtonDown("Interact") && !changingChannel && !(dayKeeper.days.currDay.GetWatchedTV())) {
				if (seated) {
					StartCoroutine("ChangeChannel");
				}
				else {
					//houseInterior = GameObject.Find("House Interior").GetComponentsInChildren<Renderer>();
					seated = true;
					sr.sprite = chair[1];
					playerScript.enabled = false;
					player.GetComponent<SpriteRenderer>().enabled = false;
				}

			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		collidedWith = other.gameObject;
		//print(collidedWith.name);
	}

	void OnTriggerExit2D (Collider2D other) {
		collidedWith = null;
	}

	IEnumerator ChangeChannel () {

		changingChannel = true;

		if (channelCnt < 3) {
			channelCnt++;
			AudioSource.PlayClipAtPoint(staticSound, transform.position);
			yield return new WaitForSeconds (0.599f);

			if (channelCnt == 2) {
				//currentSky = afternoonSky;
				dayTrans.PassTime(afternoonSky, 1f, 0.843f, 0.0157f);

			}
			else if (channelCnt == 3) {
				//currentSky = nightSky;
				dayTrans.PassTime(nightSky, 0.843f, 0.647f, 0.0196f);
			}

			staticClone = (GameObject) Instantiate (tvStatic, new Vector2(tvScreen.transform.position.x, tvScreen.transform.position.y), Quaternion.identity);
			yield return new WaitForSeconds (0.832f);
			Destroy(staticClone);
			
			tvSR.sprite = channels[channelCnt];

			//Renderer[] currentSky;			
			//print(channelCnt);
		}
		else {
			AudioSource.PlayClipAtPoint(click, transform.position);
			channelCnt = 0;
			tvSR.sprite = channels[channelCnt];
			seated = false;
			sr.sprite = chair[0];
			playerScript.enabled = true;
			player.GetComponent<SpriteRenderer>().enabled = true;
			dayKeeper.days.currDay.SetWatchedTV(true);
		}

		yield return new WaitForSeconds (0.2f);

		changingChannel = false;

	}

	/*void PassTime (Renderer[] sky) {
		StartCoroutine(TimePass(sky));
	}

	IEnumerator TimePass (Renderer[] sky) {
		float currentAlpha = 0.0f;
		float currentRBG = 0f;
		float endRBG = 0f;
		float changeRate = 0f;

		if (channelCnt == 2) {
			//currentRBG = 255f;
			currentRBG = 1f;
			//endRBG = 215f;
			endRBG = 0.843f;
			changeRate = 0.0157f;
		}
		else if (channelCnt == 3) {
			currentRBG = 0.843f;
			//endRBG = 165f;
			endRBG = 0.647f;
			changeRate = 0.0196f;
		}
		
		while (currentAlpha < 1.0f && endRBG < currentRBG) {
			currentRBG -= changeRate;
			currentAlpha += 0.1f;

			for (int ii = 0; ii < sky.Length; ii++) {
				sky[ii].material.color = new Color(1f, 1f, 1f, currentAlpha);
			}

			for (int ii = 0; ii < houseInterior.Length; ii++) {
				houseInterior[ii].material.color = new Color(currentRBG, currentRBG, currentRBG, 1f);
				playerRend.material.color = new Color(currentRBG, currentRBG, currentRBG, 1f);
			}

			yield return new WaitForSeconds(0.05f);
		}

	}*/

}
