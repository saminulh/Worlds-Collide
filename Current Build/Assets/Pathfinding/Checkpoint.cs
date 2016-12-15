using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Checkpoint : MonoBehaviour, IHeapItem<Checkpoint> {

	public static List<Checkpoint> FindClosestCheckpointGroup(Vector3 position){
		float minMag = -1;
		int closest = 0;
		foreach (Checkpoint c in GlobalVariables.checkpoints) {
			if (minMag < 0 || minMag > Vector3.Distance(position, c.Position)){
				minMag = Vector3.Distance(position, c.Position);
				closest = c.GroupID;
			}
		}
		//Debug.Log (closest);
		return GlobalVariables.checkpointGroups[closest];
	}

	public bool actualCheckpoint;

	public int cpID;
	public int CpID {
		get {
			return cpID;
		}
	}

	public int groupID;
	public int GroupID {
		get {
			return groupID;
		}
		set {
			groupID = value;
		}
	}

	public float weight;
	public float Weight {
		get {
			return weight;
		}
		set {
			weight = value;
		}
	}

	int heapIndex;
	public int HeapIndex {
		get {
			return heapIndex;
		}
		set {
			heapIndex = value;
		}
	}

	bool open;
	public bool Open{
		get{
			return open;
		}
		set{
			open = value;
		}
	}

	Checkpoint parent;
	public Checkpoint Parent{
		get{
			return parent;
		}
		set{
			parent=value;
		}
	}

	Vector3 position;
	public Vector3 Position {
		get {
			return position;
		}
		set{
			position = value;
		}
	}

	List<Checkpoint> adjacent;
	public List<Checkpoint> Adjacent {
		get {
			return adjacent;
		}
	}

	Checkpoint tempTarget;
	public Checkpoint TempTarget {
		get{
			return tempTarget;
		}
		set{
			tempTarget = value;
		}
	}

	void Awake(){
		position = transform.position;
		adjacent = new List<Checkpoint> ();
		tempTarget = null;
		parent = null;
	}

	void Start(){
		if (actualCheckpoint) {
			cpID = GlobalVariables.checkpoints.Count;
			GlobalVariables.checkpoints.Add (this);
			foreach (Checkpoint c in GlobalVariables.checkpointGroups[groupID]) {
				adjacent.Add (c);
				c.Adjacent.Add (this);
			}
			for (int i = 0; i < GlobalVariables.adjacencies.Length/2; i++) {
				//Debug.Log (checkpoints.Count);
				//Debug.Log (checkpoints[adjacencies[i,0]]);
				if (GlobalVariables.adjacencies[i,0] == cpID){
					Adjacent.Add(GlobalVariables.checkpoints[GlobalVariables.adjacencies[i,1]]);
					GlobalVariables.checkpoints[GlobalVariables.adjacencies[i,1]].Adjacent.Add(this);
				}
			}
			GlobalVariables.checkpointGroups [groupID].Add (this);
		}
	}

	void OnMouseDown(){
		Debug.Log ("For " + cpID);
		foreach (Checkpoint c in adjacent) {
			Debug.Log (c.CpID);
		}
	}

	void Update(){
		if (!actualCheckpoint) this.gameObject.SetActive (false);
	}

	public void ResetForPathfinding(){
		tempTarget = null;
		parent = null;
		open = true;
		weight = float.PositiveInfinity;
	}

	public int CompareTo (Checkpoint other){
		return -Weight.CompareTo(other.Weight);
	}
	
}
