using UnityEngine;
using System.Collections;

public class CounterScript : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		//print(gameObject.layer);
		Physics2D.IgnoreLayerCollision(player.layer, gameObject.layer);
	}
	
	// Update is called once per frame
	void Update () {
		//Physics2D.IgnoreLayerCollision(player.layer, gameObject.layer);
		//print(Physics2D.GetIgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>()));
	}
}
