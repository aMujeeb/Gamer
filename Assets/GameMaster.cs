using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public static int currentScore = 0;
	public int testScore = 0;
	public float offsetY = 40f;
	public float sizeX	= 100f;
	public float sizeY = 40f;

	
	// Update is called once per frame
	void Update () {
		testScore = currentScore;
	}

	void OnGUI() {
		GUI.Box(new Rect(Screen.width/2f - sizeX/2f, offsetY,sizeX,sizeY), "Score :"+currentScore);
	}
}
