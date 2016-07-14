using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

	private Rigidbody2D playerRigitbody;

	[SerializeField]
	private float xMax;

	[SerializeField]
	private float yMax;

	[SerializeField]
	private float xMin;

	[SerializeField]
	private float yMin;

	private Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player").transform;
	}

	void LateUpdate() {
		transform.position = new Vector3(Mathf.Clamp(target.position.x,xMin,xMax),Mathf.Clamp(target.position.y,yMin,yMax), transform.position.z);
	}
}
