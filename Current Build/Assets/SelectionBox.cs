using UnityEngine;
using System.Collections;

public class SelectionBox : MonoBehaviour {
	public float depth;
	public Vector3 s, c, start, click;
	public static Vector3 Size, Position;
	// Use this for initialization
	void Start () {
		depth = 20;
	}
	
	// Update is called once per frame
	void Update () {
		start = GlobalVariables.startClickPos;
		click = GlobalVariables.clickPos;
		s = Camera.main.ScreenToWorldPoint(new Vector3(start.x,start.y,1));
		c = Camera.main.ScreenToWorldPoint(new Vector3(click.x,click.y,1));
		Vector3 dims = c - s + new Vector3(0,0.0000001f,0);
		if (GlobalVariables.leftClicked) {
			Size = dims;
			Position = s + new Vector3 (dims.x / 2, 0, dims.z / 2);
		} else {
			Size = Vector3.zero;
			Position = Vector3.zero;
		}

		transform.localScale = Size;
		transform.localPosition = Position;
		//Debug.Log ("Scale:  " + transform.localScale);
		//Debug.Log ("Position:  " + transform.localPosition);
	}
}
