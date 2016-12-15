using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;

public class DijkstraPathfinding : MonoBehaviour {
	
	
	PathRequestManager requestManager;
	
	void Awake() {
		requestManager = GetComponent<PathRequestManager>();
	}
	
	
	public void StartFindPath(Vector3 startPos, Vector3 targetPos) {
		StartCoroutine(FindPath(startPos,targetPos));
	}
	
	IEnumerator FindPath(Vector3 startPos, Vector3 targetPos) {
		
		Stopwatch sw = new Stopwatch();
		sw.Start();

		List<Vector3> waypoints = new List<Vector3> ();
		bool pathSuccess = false;
		List<Checkpoint> startGroup = Checkpoint.FindClosestCheckpointGroup(startPos),
		targetGroup = Checkpoint.FindClosestCheckpointGroup(targetPos);

		Checkpoint targetCP = GlobalVariables.endCP;
		Checkpoint startCP = GlobalVariables.startCP;
		Checkpoint current;

		Heap<Checkpoint> openSet = new Heap<Checkpoint>(GlobalVariables.checkpoints.Count+2);
		startCP.ResetForPathfinding ();
		startCP.Weight = 0;
		openSet.Add (startCP);
		foreach (Checkpoint c in GlobalVariables.checkpoints) {
			c.ResetForPathfinding ();
			openSet.Add (c);
		}
		targetCP.ResetForPathfinding ();
		openSet.Add (targetCP);

		targetCP.transform.position = targetPos;
		targetCP.Position = targetPos;
		foreach (Checkpoint c in targetGroup) {
			//Debug.Log (c.CPID);
			c.TempTarget = targetCP;
		}

		startCP.transform.position = startPos;
		startCP.Position = startPos;
		startCP.Adjacent.Clear ();

		foreach (Checkpoint c in startGroup) {
			startCP.Adjacent.Add(c);
		}
		if (startGroup.Equals (targetGroup)) {
			startCP.TempTarget = targetCP;
		}
		
		do {
			//Debug.Log ("");
			current = openSet.First ();
			//Debug.Log ("Cur:  " + current.CPID);
			//Debug.Log ("TT: " + current.TempTarget);
			//Debug.Log ("Adj:");
			foreach (Checkpoint adj in current.Adjacent) {
				//Debug.Log (adj.CPID);
				if (adj.Weight > current.Weight + Vector3.Distance (current.Position, adj.Position) && adj.Open) {
					adj.Weight = current.Weight + Vector3.Distance (current.Position, adj.Position);
					openSet.UpdateItem (adj);
					adj.Parent = current;
				}
			}
			if (current.TempTarget != null) {
				//Debug.Log (current.TempTarget.CPID);
				if (targetCP.Weight > current.Weight + Vector3.Distance (current.Position, targetCP.Position)) {
					targetCP.Weight = current.Weight + Vector3.Distance (current.Position, targetCP.Position);
					openSet.UpdateItem (targetCP);
					targetCP.Parent = current;
					pathSuccess = true;
				}
			}
			current.Open = false;
			openSet.RemoveFirst ();
			//Debug.Log ("");
			//Debug.Log (openSet.First ().CPID);

		} while (!current.Equals(targetCP));

		sw.Stop ();
		UnityEngine.Debug.Log (sw.ElapsedMilliseconds);
		yield return null;
		if (pathSuccess) {
			waypoints = RetracePath(startCP,targetCP);
		}
		requestManager.FinishedProcessingPath(waypoints,pathSuccess);
		
	}
	
	List<Vector3> RetracePath(Checkpoint startCP, Checkpoint endCP) {
		List<Vector3> path = new List<Vector3>();
		Checkpoint currentCP = endCP;
		
		while (currentCP != null) {
			path.Add(currentCP.Position);
			currentCP = currentCP.Parent;
		}
		path.Reverse ();
		return path;
		
	}	

	Vector3[] SimplifyPath(List<Checkpoint> path){
		Vector3[] waypoints = new Vector3[path.Count];
		for (int i = 0; i < path.Count; i++) {
			//UnityEngine.Debug.Log (path[i].CPID);
			waypoints[i] = path[i].Position;
		}
		return waypoints;
	}

}
