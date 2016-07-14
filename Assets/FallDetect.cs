using UnityEngine;
using System.Collections;

public class FallDetect : MonoBehaviour {

	public Vector2 checkPoint;

	// Use this for initialization
	void Start () {
		checkPoint = new Vector2 (0, 5);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -5) {
			//Debug.Log ("Fall X Position :" + transform.position.x);
			checkPoint.x = transform.position.x + 1;
			transform.position = checkPoint;
		}
	}
}
