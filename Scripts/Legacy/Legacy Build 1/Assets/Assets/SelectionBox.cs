using UnityEngine;
using System.Collections;

public class SelectionBox : MonoBehaviour {
	public float depth;
	public Vector3 s, c, start, click;
	// Use this for initialization
	void Start () {
		depth = 20;
	}
	
	// Update is called once per frame
	void Update () {
		start = GlobalVariables.startClickPos;
		click = GlobalVariables.clickPos;
		s = Camera.main.ScreenToWorldPoint(start + new Vector3 (0, 0, 1));
		c = Camera.main.ScreenToWorldPoint(click + new Vector3 (0, 0, 1));
		Vector3 dims = c - s + new Vector3(0,0,0.0000001f);
		if (GlobalVariables.leftClicked)
			transform.localScale = dims;
		else
			transform.localScale = new Vector3 (0, 0, 0);

		transform.localPosition = s+new Vector3(dims.x/2,dims.y/2,0);
		//Debug.Log ("Scale:  " + transform.localScale);
		//Debug.Log ("Position:  " + transform.localPosition);
	}
}
