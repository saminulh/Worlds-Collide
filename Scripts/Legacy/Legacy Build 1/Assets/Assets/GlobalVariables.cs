using UnityEngine;
using System.Collections;

public class GlobalVariables : MonoBehaviour {
	public static bool isOnline;
	public static bool leftClicked;
	public static Vector3 startClickPos,clickPos;

	// Use this for initialization
	void Start () {
		leftClicked = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!leftClicked && Input.GetMouseButton (0)) {
			startClickPos = Input.mousePosition;
			leftClicked = true;
		}
		if (!Input.GetMouseButton (0)) {
			leftClicked = false;
		}
		if (leftClicked) {
			clickPos = Input.mousePosition;
		}
		//Debug.Log (Input.mousePosition);

	}
}
