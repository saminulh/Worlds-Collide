using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PathRequestManager : MonoBehaviour {

	Queue<PathRequest> pathRequestQueue = new Queue<PathRequest>();
	PathRequest currentPathRequest;

	static PathRequestManager instance;
	DijkstraPathfinding pathfinding;

	bool isProcessingPath;

	void Awake() {
		instance = this;
		pathfinding = GetComponent<DijkstraPathfinding>();
	}

	public static void RequestPath(Vector3 pathStart, Vector3 pathEnd, Action<List<Vector3>, bool> callback) {
		PathRequest newRequest = new PathRequest(pathStart,pathEnd,callback);
		instance.pathRequestQueue.Enqueue(newRequest);
		instance.TryProcessNext();
	}

	void TryProcessNext() {
		if (!isProcessingPath && pathRequestQueue.Count > 0) {
			currentPathRequest = pathRequestQueue.Dequeue();
			isProcessingPath = true;
			//Debug.Log ("HIHI");
			pathfinding.StartFindPath(currentPathRequest.pathStart, currentPathRequest.pathEnd);
		}
	}

	public void FinishedProcessingPath(List<Vector3> path, bool success) {
		currentPathRequest.callback(path,success);
		isProcessingPath = false;
		TryProcessNext();
	}

	struct PathRequest {
		public Vector3 pathStart;
		public Vector3 pathEnd;
		public Action<List<Vector3>, bool> callback;

		public PathRequest(Vector3 _start, Vector3 _end, Action<List<Vector3>, bool> _callback) {
			pathStart = _start;
			pathEnd = _end;
			callback = _callback;
		}

	}
}
