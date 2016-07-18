using UnityEngine;
using System.Collections;

public class PlatformCollider : MonoBehaviour {

	private BoxCollider2D heroCollider;

	[SerializeField]
	private BoxCollider2D platformCollider;

	[SerializeField]
	private BoxCollider2D platformTrigger;

	// Use this for initialization
	void Start () {
		heroCollider = GameObject.Find ("Hero").GetComponent<BoxCollider2D> ();
		Physics2D.IgnoreCollision (platformCollider,platformTrigger,true);
	}

	void OnTriggerEnter2D(Collider2D obj) {
		if(obj.name == heroCollider.name) {
			Physics2D.IgnoreCollision(platformCollider,heroCollider,true);
		}
	}
	
	void OnTriggerExit2D(Collider2D obj){
		if(obj.name == heroCollider.name) {
			Physics2D.IgnoreCollision(platformCollider,heroCollider,false);
		}
	}
}
