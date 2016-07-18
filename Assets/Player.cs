using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody2D playerRigidBody;
	private float moveDirection;

	private Animator playerAnimator;

	[SerializeField]
	private float movementSpeed;

	private bool turnRight;

	[SerializeField]
	private Transform[] groundPoints;

	[SerializeField]
	private float groundRadius;

	[SerializeField]
	private LayerMask placedOnGround;

	private bool isOnTheGround;

	[SerializeField]
	private float jumpForce;

	private bool jumping;

	// Use this for initializatio
	void Start () {
		playerRigidBody = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<Animator> ();
		turnRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		moveDirection = Input.GetAxis ("Horizontal");
	}

	void FixedUpdate() {
		isOnTheGround = IsGrounded ();
		movePlayer (moveDirection);
		turnPlayer (moveDirection);
		HandleKeyInput ();
	}
		
	public void movePlayer(float moveDirection) {
		//Debug.Log ("Move Direction-"+jumping+"-"+isOnTheGround);
		if (isOnTheGround && jumping) {
			playerRigidBody.AddForce (new Vector2 (0, jumpForce));
			playerAnimator.SetBool("jump",true);
			jumping = false;
			isOnTheGround = false;
		} 

		if (isOnTheGround) {
			playerRigidBody.velocity = new Vector2 (moveDirection * movementSpeed, playerRigidBody.velocity.y);
			playerAnimator.SetFloat ("speed", Mathf.Abs (moveDirection));
		}
	}

	public void turnPlayer (float moveDirection) {
		if (moveDirection > 0 && !turnRight || moveDirection < 0 && turnRight) {
			turnRight = !turnRight;

			Vector3 updatedScale = transform.localScale;
			updatedScale.x *= -1;
			transform.localScale = updatedScale;
		}
	}

	public void HandleKeyInput() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			//Debug.Log ("Press Key Space");
			jumping = true;
		}
	}
		
	private bool IsGrounded() {
		if(playerRigidBody.velocity.y <= 0){
			foreach(Transform tPoint in groundPoints){
				Collider2D[] groundColliders = Physics2D.OverlapCircleAll (tPoint.position, groundRadius, placedOnGround);
				for (int i = 0; i< groundColliders.Length ; i++){
					if (groundColliders [i].gameObject != gameObject) { //groundCollider game object != Player game object
						//Debug.Log ("Grounded");
						playerAnimator.SetBool("jump",false);
						return true;
					}
				}
			}
		}
		return false;
	}
}
