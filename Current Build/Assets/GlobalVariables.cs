using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalVariables : MonoBehaviour {
	public static bool isOnline;
	public static bool leftClicked, rightClicked, wasRightClicked;
	public static Vector3 startClickPos,clickPos;
	public static List<Unit> selected;
	public static Checkpoint startCP, endCP;
	public static List<Checkpoint>[] checkpointGroups;
	public static List<Checkpoint> checkpoints;
	public static Heap<Checkpoint> cpHeap;
	public static int[,] adjacencies;
	public static Vector3 mouseWorldPos;

	// Use this for initialization
	void Awake () {
		//Instantiate(Resources.Load("Prefabs/MockBuildingPrefab", typeof(GameObject)));
		leftClicked = false;
		selected = new List<Unit> ();
		startCP = GameObject.Find ("Start Checkpoint").GetComponent <Checkpoint> ();
		endCP = GameObject.Find ("End Checkpoint").GetComponent <Checkpoint> ();
		checkpointGroups = new List<Checkpoint>[10];
		for (int i = 0; i < 10; i++) {
			checkpointGroups[i] = new List<Checkpoint> ();
		}
		checkpoints = new List<Checkpoint> ();
		cpHeap = new Heap<Checkpoint> (50);
		adjacencies = new int[2,2] { {2,0} , {4,1} };
	}
	
	// Update is called once per frame
	void Update () {
		mouseWorldPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
		wasRightClicked = rightClicked;
		rightClicked = Input.GetMouseButton (1);
		if (!leftClicked && Input.GetMouseButton (0)) {
			startClickPos = Input.mousePosition;
			leftClicked = true;
			selected.Clear();
		}
		if (!Input.GetMouseButton (0)) {
			leftClicked = false;
		}
		if (leftClicked) {
			clickPos = Input.mousePosition;
			while (cpHeap.Count > 0){
				Debug.Log (cpHeap.RemoveFirst ().Weight);
			}
		}
		
		//Debug.Log (selected.Count);

	}
}
