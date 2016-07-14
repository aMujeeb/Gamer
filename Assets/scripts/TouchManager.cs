using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {

	void Start() {
		
	}


	void Update () { 
		if (Input.touchCount > 0) {
			//foreach (Touch touch in Input.touches) {
				//Debug.Log ("Touch Position :" + touch.position);
			//}

			if(Input.GetTouch(0).phase == TouchPhase.Began) {
				Debug.Log ("Touch Began");
			}
			if(Input.GetTouch(0).phase == TouchPhase.Moved) {
				Debug.Log ("Touch Moved");
			}
			if(Input.GetTouch(0).phase == TouchPhase.Ended) {
				Debug.Log ("Touch Ended");
			}
		}
	}
}
