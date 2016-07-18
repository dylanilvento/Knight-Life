using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {

	public AudioClip deathSound;
	public GameObject collidedWith;

	Animator anim;

	public GameObject explosion;
	GameObject explosionClone;

	bool bossDying = false;

	MusicScript battleMusic, victoryMusic, bgMusic;
	//FollowPlayerScript followCollider;

	public GameObject[] redHealth = new GameObject[10];
	public GameObject[] goldHealth = new GameObject[10];
	
	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
		battleMusic = GameObject.Find("Boss Battle Music").GetComponent<MusicScript>();
		victoryMusic = GameObject.Find("Victory Music").GetComponent<MusicScript>();
		bgMusic = GameObject.Find("Background Music").GetComponent<MusicScript>();
		
	}
	
	// Update is called once per frame
	void Update () {

		//print(gameObject.GetComponent<Animation>().clip.name);

		if (collidedWith != null) {
			if (collidedWith.name == "Weapon Collider" && !bossDying) {

				bossDying = true;
				anim.SetBool("Dead", true);
				AudioSource.PlayClipAtPoint(deathSound, transform.position);
				StartCoroutine("DyingAnimation");
				//EndGame();
			}
		}
		
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		
		collidedWith = other.gameObject;
		
	}
	
	void OnTriggerExit2D (Collider2D other) {
		
		collidedWith = null;

	}

	IEnumerator DyingAnimation () {

		battleMusic.StopMusic();
		bool pushRight = false;
		//bool exploded = false;
		//float prevX, prevY;
		int goldCnt = 9;
		int redCnt = 9;
		
		for (int i = 0; i < 125; i++) {			

			//print(i);
			//exploded = false;

			if (pushRight) {
				//transform.position.x -= 0.5;
				transform.position = new Vector2(transform.position.x - 0.25f, transform.position.y);
				pushRight = false;
			}

			else {
				//GetComponent<Rigidbody2D>().velocity = new Vector2(0.5f, GetComponent<Rigidbody2D>().velocity.y);
				transform.position = new Vector2(transform.position.x + 0.25f, transform.position.y);
				pushRight = true;
			}
			
			if (i >= 50 && i < 120) {
				if (i % 2 == 0) {
					//print (i);
					explosionClone = (GameObject) Instantiate (explosion, new Vector3(transform.position.x + Random.Range (-1.5f, 1.5f), transform.position.y + Random.Range (-1.5f, 1.5f), transform.position.z), Quaternion.identity);
					//exploded = true;
				}

				if (i % 4 == 0) {
					if (goldCnt > 0) {
						Destroy(goldHealth[goldCnt]);
						goldCnt--;
						Destroy(goldHealth[goldCnt]);
						goldCnt--;

						//print("goldCnt: " + goldCnt);
					}

					else if (redCnt >= 0) {
						Destroy(redHealth[redCnt]);
						redCnt--;

						//print("redCnt: " + redCnt);
					}

					
					
				}
			}

			yield return new WaitForSeconds(0.05f);
			
		}

		Destroy(this.gameObject);
		//yield return new WaitForSeconds(0.5f);
		victoryMusic.PlayMusic(0.5f);
		bgMusic.FadeInMusic(8f, 0.5f);
	}

	public void CollectHealthBars () {
		for (int ii = 0; ii < redHealth.Length; ii++) {
			redHealth[ii] = GameObject.Find("Red Health Piece " + (ii + 1));
			goldHealth[ii] = GameObject.Find("Gold Health Piece " + (ii + 1));
		}

	}
}