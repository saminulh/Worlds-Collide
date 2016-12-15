using UnityEngine;
using System.Collections;

public class GlobalVariables : MonoBehaviour {
	public static int playerID;

    public static List<UnitStatsContainer.UnitStats> unitsList = new List<UnitStatsContainer.UnitStats>();
    public static List<string> chatList = new List<string>();
	
	public bool isOnline;
	public bool leftClicked;
	public Vector3 startClickPos,clickPos;

	// Use this for initialization
	void Start () {
		leftClicked = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!leftClicked && Input.GetMouseButton (0)) {
			startClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition-new Vector3(0,0,-50));
			leftClicked = true;
		}
		if (!Input.GetMouseButton (0))
			leftClicked = false;
		if (leftClicked) {
			clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition-new Vector3(0,0,-50));
		}

	}
}
