using UnityEngine;
using System.Collections;

public class MiniPlayerScript : MonoBehaviour {
	bool goLeft = false;
	bool goRight = true;
	float maxSpeed = 1.5f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		
		float move = Input.GetAxis("Horizontal");
		if (goLeft && !goRight) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(-1f * Mathf.Abs(move) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

		else if (goRight && !goLeft) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Abs(move) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		}

		else {
			GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
	}

	public void SetGoLeft (bool val) {
		goLeft = false;
		goRight = false;
		goLeft = val;
		
	}

	public void SetGoRight (bool val) {
		goLeft = false;
		goRight = false;
		goRight = val;
		
	}

	public void SetGoLeftRight () {
		goLeft = false;
		goRight = false;
	}

	public bool GetGoLeft () {
		return goLeft;
	}

	public bool GetGoRight () {
		return goLeft;
	}

	public void SetVelocityX (float x) {
		GetComponent<Rigidbody2D>().velocity = new Vector2(x, GetComponent<Rigidbody2D>().velocity.y);
		
	}
}