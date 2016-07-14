using UnityEngine;
using System.Collections;

public class Girl : MonoBehaviour {

	private Rigidbody2D mygirlrigitbody;
	private Animator myAnimator;

	private BoxCollider2D playerCollider;

	private bool facingRight;

	private bool shoot;

	// Use this for initialization
	void Start () {
		facingRight = false;
		mygirlrigitbody = GetComponent<Rigidbody2D> ();
		myAnimator = GetComponent<Animator>();

		playerCollider = GameObject.Find ("Player").GetComponent<BoxCollider2D>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		flip ();
	}

	private void flip() {
		if (!facingRight) {
			facingRight = !facingRight;

			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	void OnTriggerEnter2D(Collider2D info) {
		if (info.name == playerCollider.name) {
			Debug.Log ("Girl Knock");
			shoot = true;
			HandleAttack ();
		}
	}

	private void HandleAttack() {
		if (shoot) {
			myAnimator.SetTrigger ("shoot");
			shoot = false;
		}
	}

}
