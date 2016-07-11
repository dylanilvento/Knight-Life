using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float maxSpeed = 5f;
	//public float test;
	bool facingRight = true;
	public bool stopMvmtRight = false;
	public bool stopMvmtLeft = false;
	public bool stopAction = true;

	public bool robed = false;
	public bool robedStubble = false;

	GameObject collidedWith;
	GameObject counter;

	Animator anim;
	public AudioClip swordSwing;

	//public GameObject weap;
	public BoxCollider2D weapCollider;

	Rigidbody2D rb;

	HealthBarScript hbScript;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
		counter = GameObject.Find("Counter");
		rb = GetComponent<Rigidbody2D>();
		hbScript = GameObject.Find("Health Bar").GetComponent<HealthBarScript>();
		//Physics2D.IgnoreLayerCollision(counter.layer, gameObject.layer);
		//print("playerScript: " + Physics2D.GetIgnoreCollision(counter.GetComponent<Collider2D>(), GetComponent<Collider2D>()));
		//weap = GameObject.Find("Weapon Collider");
		//weapCollider = GameObject.Find("Weapon Collider").GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	//Don't have to use time.deltaTime
	void FixedUpdate () { 

		float move = Input.GetAxis("Horizontal");

		if (robed) {
			anim.SetBool("Robed", true);
		}

		else if (robedStubble) {
			anim.SetBool("RobedStubble", true);
		}
		
		if (!stopAction) {
			if (!stopMvmtLeft || !stopMvmtRight) {	
				anim.SetFloat("Speed", Mathf.Abs(move));
				rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
			
			}

			if ((move > 0 && stopMvmtRight) || (move < 0 && stopMvmtLeft)) {
				anim.SetFloat("Speed", 0.00f);
				rb.velocity = new Vector2(0f, 0f);

			}
		}

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	
	}

	void Update () {

		if (Input.GetButtonDown("Interact") && !stopAction) {

			if (collidedWith != null && collidedWith.name == "DoorCollider") {

				transform.position = new Vector2(transform.position.x + 92, transform.position.y);
				//weapCollider.enabled = true;

			}

			else if (!robed && !robedStubble) {
				StartCoroutine("FlashWeaponCollider");
				AudioSource.PlayClipAtPoint(swordSwing, transform.position);
				anim.SetBool("Attack", true);
			}

		}

	}

	void Flip () {

		facingRight = !facingRight;
		Vector3 playerScale = transform.localScale;
		playerScale.x *= -1;
		transform.localScale = playerScale;
	}

	public void SetStopMvmtRight (bool val) {
		stopMvmtRight = val;
	}

	public bool GetStopMvmtRight () {
		return stopMvmtRight;
	}

	public void SetStopMvmtLeft (bool val) {
		stopMvmtLeft = val;
	}

	public bool GetStopMvmtLeft () {
		return stopMvmtLeft;
	}

	public void OnTriggerEnter2D (Collider2D other) {

		collidedWith = other.gameObject;

	}

	public void OnTriggerExit2D (Collider2D other) {

		collidedWith = null;
	}

	IEnumerator FlashWeaponCollider () {

		yield return new WaitForSeconds(0.2f);
		weapCollider.enabled = true;
		yield return new WaitForSeconds(0.2f);
		weapCollider.enabled = false;


	}

	public void SetStopAction (bool val) {
		stopAction = val;
	}

	public void StartBossFight () {
		StartCoroutine("BossFightStart");
	}

	public void SetRobed (bool val) {
		robed = val;
	}

	public void SetRobedStubble (bool val) {
		robedStubble = val;
	}

	IEnumerator BossFightStart () {
		float startTime = Time.realtimeSinceStartup;

		while ((Time.realtimeSinceStartup - startTime) < 0.75f) {
			
			if (!facingRight) {
				Flip();
			}

			anim.SetFloat("Speed", 1f);
			rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
			yield return new WaitForSeconds(0.01f);

		}

		anim.SetFloat("Speed", 0f);
		rb.velocity = new Vector2(0f, rb.velocity.y);
		hbScript.StartFillBar();
	}
}
