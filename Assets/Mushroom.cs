using UnityEngine;
using System.Collections;

public class Mushroom : MonoBehaviour {

	private BoxCollider2D playerCollider;

	//
	// Use this for initialization
	void Start () {
		playerCollider = GameObject.Find ("Player").GetComponent<BoxCollider2D>();
	}
	


	void OnTriggerEnter2D(Collider2D info) {
		if (info.name == playerCollider.name) {
			//Debug.Log ("Mushroom Knock");

			GameMaster.currentScore += 1; //Increment by One when Collide
			//gameObj = Instantiate(mushroomEffect, transform.position,transform.rotation);
			//Destroy (gameObj, 2);
			Destroy (gameObject);
		}
	}
}
