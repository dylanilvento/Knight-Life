using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

	public GameObject healthRedBegin;
	public GameObject healthRedFill;
	public GameObject healthRedEnd;

	public GameObject healthGoldBegin;
	public GameObject healthGoldFill;
	public GameObject healthGoldEnd;

	GameObject healthPiece;

	SpriteRenderer sr;

	public AudioClip fillSound;

	bool fillBar = false;

	MusicScript battleMusic;
	PlayerScript playerScript;
	BossScript bossScript;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		battleMusic = GameObject.Find("Boss Battle Music").GetComponent<MusicScript>();
		playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
		bossScript = GameObject.Find("Boss").GetComponent<BossScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartFillBar() {
		StartCoroutine("FillBarStart");
	}

	IEnumerator FillBarStart () {
		yield return new WaitForSeconds(2.0f);
		AudioSource.PlayClipAtPoint(fillSound, transform.position);
		float posIncr = 0.0f;
		float waitTime = 0.0f;

		int i = 1;

		healthPiece = (GameObject) Instantiate (healthRedBegin, new Vector3(transform.localPosition.x - (3.6f * transform.localScale.x), transform.position.y, transform.position.z), Quaternion.identity);
		healthPiece.name = "Red Health Piece 1";

		i++; // i = 2;

		while (i < 10) {
			switch (i) {
			    case 2:
			        waitTime = 0.19f;
			        break;
			    case 3:
			        waitTime = 0.19f;
			        break;
			    case 4:
			        waitTime = 0.19f;
			        break;
			    case 5:
			        waitTime = 0.18f;
			        break;
			    case 6:
			        waitTime = 0.177f;
			        break;
			    case 7:
			        waitTime = 0.182f;
			        break;
			    case 8:
			        waitTime = 0.147f;
			        break;
			    case 9:
			        waitTime = 0.134f;
			        break;
			    default:
			        break;
			}

			yield return new WaitForSeconds(waitTime);
			healthPiece = (GameObject) Instantiate (healthRedFill, new Vector3(transform.localPosition.x + ((-2.8f + posIncr) * transform.localScale.x), transform.position.y, transform.position.z), Quaternion.identity);
			healthPiece.name = "Red Health Piece " + i;
			posIncr += 0.8f;
			i++;
		}

		//i = 10
		yield return new WaitForSeconds(0.152f);
		healthPiece = (GameObject) Instantiate (healthRedEnd, new Vector3(transform.localPosition.x + ((-2.8f + posIncr) * transform.localScale.x), transform.position.y, transform.position.z), Quaternion.identity);
		healthPiece.name = "Red Health Piece " + i;
		i++;

		int goldCnt = 1;
		// i = 11
		yield return new WaitForSeconds(0.168f);
		healthPiece = (GameObject) Instantiate (healthGoldBegin, new Vector3(transform.localPosition.x - (3.6f * transform.localScale.x), transform.position.y, transform.position.z), Quaternion.identity);
		healthPiece.name = "Gold Health Piece " + goldCnt;
		goldCnt++;

		healthPiece = (GameObject) Instantiate (healthGoldFill, new Vector3(transform.localPosition.x - (2.8f * transform.localScale.x), transform.position.y, transform.position.z), Quaternion.identity);
		healthPiece.name = "Gold Health Piece " + goldCnt;
		posIncr = 0.0f;
		i++;
		goldCnt++;

		while (i < 15) {
			switch (i) {
			    case 12:
			        waitTime = 0.152f;
			        break;
			    case 13:
			        waitTime = 0.137f;
			        break;
			    case 14:
			        waitTime = 0.152f;
			        break;
			    default:
			        break;
			}
			yield return new WaitForSeconds(waitTime);
			healthPiece = (GameObject) Instantiate (healthGoldFill, new Vector3(transform.localPosition.x + ((-2f + posIncr) * transform.localScale.x), transform.position.y, transform.position.z), Quaternion.identity);
			healthPiece.name = "Gold Health Piece " + goldCnt;
			posIncr += 0.8f;
			goldCnt++;

			healthPiece = (GameObject) Instantiate (healthGoldFill, new Vector3(transform.localPosition.x + ((-2f + posIncr) * transform.localScale.x), transform.position.y, transform.position.z), Quaternion.identity);
			healthPiece.name = "Gold Health Piece " + goldCnt;
			posIncr += 0.8f;
			goldCnt++;
			i++;
		}

		yield return new WaitForSeconds(0.146f);
		healthPiece = (GameObject) Instantiate (healthGoldFill, new Vector3(transform.localPosition.x + ((-2f + posIncr) * transform.localScale.x), transform.position.y, transform.position.z), Quaternion.identity);
		healthPiece.name = "Gold Health Piece " + goldCnt;
		posIncr += 0.8f;
		goldCnt++;

		healthPiece = (GameObject) Instantiate (healthGoldEnd, new Vector3(transform.localPosition.x + ((-2f + posIncr) * transform.localScale.x), transform.position.y, transform.position.z), Quaternion.identity);
		healthPiece.name = "Gold Health Piece " + goldCnt;
		
		yield return new WaitForSeconds(0.5f);
		battleMusic.PlayMusic();
		bossScript.CollectHealthBars();
		playerScript.SetStopAction(false);
	}
}
