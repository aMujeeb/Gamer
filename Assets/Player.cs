using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody2D myrigitbody;

	private Rigidbody2D mobilerigitbody;
	private Animator myAnimator;
	private float horizontal;

	[SerializeField]
	private float movementSpeed;

	private bool facingRight;

	[SerializeField]
	private Transform[] groundPoints;

	[SerializeField]
	private float groundRadius;

	[SerializeField]
	private LayerMask whatIsGround;

	private bool isGrounded;

	private bool jump;

	private bool isLeftPressed = false;
	private bool isRightPressed = false;

	[SerializeField]
	private bool airControl;

	[SerializeField]
	private float jumpForce;

	// Use this for initialization
	void Start () {
		facingRight = true;
		myrigitbody = GetComponent<Rigidbody2D> ();
		myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//float horizontal = Input.GetAxis ("Horizontal");
		//handleMovement (horizontal);
		if (isLeftPressed && isGrounded) {
			myrigitbody.velocity = new Vector2 (-movementSpeed, 0);
		}
		if(isRightPressed && isGrounded) {
			myrigitbody.velocity = new Vector2 (movementSpeed, 0);
		}
	}

	void Awake() {
	}

	void FixedUpdate () { //Regardslessly the frame rate of hardware this works
		isGrounded = IsGrounded ();
		handleMovement();
		handleLayers ();
		//resetValues ();

	}

	private void handleInput(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			jump = true;
		}
	}

	public void resetValues() {
		jump = false;
	}

	private void handleMovement() {
		if(isGrounded && jump){
			isGrounded = false;
			myrigitbody.AddForce (new Vector2(0,jumpForce));
			myAnimator.SetTrigger ("jump");
			jump = false;
		}

		if(myrigitbody.velocity.y < 0) {
			myAnimator.SetBool ("land", true);

		}
	}

	private void flip(float horizontal) {
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
			facingRight = !facingRight;

			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	private bool IsGrounded() {
		if (myrigitbody.velocity.y <= 0) {
			foreach (Transform point in groundPoints) {
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);
			
				for(int i = 0; i< colliders.Length; i++){
					if (colliders [i].gameObject != gameObject) {
						Debug.Log ("Ground Game Object:" +gameObject.tag);
						myAnimator.ResetTrigger ("jump");
						myAnimator.SetBool ("land", false);
						return true;
					}
				}
			}

		}
		return false;
	}

	private void handleLayers(){
		if (!isGrounded) {
			myAnimator.SetLayerWeight (1, 1);
		} else {
			myAnimator.SetLayerWeight (1, 0);
		}
	}


	public void MoveLeft() {
		//Debug.Log ("Player Speed Left:" + movementSpeed);
		isLeftPressed = true;
		flip (-1f);
		myrigitbody.velocity = new Vector2 (-movementSpeed, 0);
		myAnimator.SetFloat ("speed", 1);
	}

	public void MoveRight() {
		isRightPressed = true;
		flip (1f);
		myrigitbody.velocity = new Vector2 (movementSpeed, 0);
		myAnimator.SetFloat ("speed", 1);
	}

	public void StopMoving() {
		//jump = false;
		isLeftPressed = false;
		isRightPressed = false;
		myrigitbody.velocity = Vector2.zero;
		myAnimator.SetFloat ("speed", 0);
	}

	public void JumpUp(){
		jump = true;
	}

	public void StopJumping() {
		jump = false;
	}

}
