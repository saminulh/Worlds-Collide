using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitPathGen : MonoBehaviour {


	public Transform target;
	uint speed;
	List<Vector3> path, drawnPath;
	float targetRadius;
	Queue<CurvePointInfo> curvePoints;
	int targetIndex;
	Vector3 currentWaypoint;
	CurvePointInfo rotationPoint;
	Unit unitRef;
	public bool findingPath, pathFound, requestFailed;

	void Start() {
		curvePoints = new Queue<CurvePointInfo> ();
		try {
			unitRef = GetComponent<Unit> ();
			speed = 10;
		}
		catch {
			speed = 20;
		}
		findingPath = false;
		pathFound = false;
		requestFailed = false;
		//PathRequestManager.RequestPath(transform.position,target.position, OnPathFound);
	}

	public void RequestPath (Vector3 targetPos){
		RequestPath (targetPos, 0);
	}

	public void RequestPath(Vector3 targetPos, float radius){
		findingPath = true;
		requestFailed = false;
		pathFound = false;
		PathRequestManager.RequestPath (transform.position, targetPos, OnPathFound);
		targetRadius = radius;
	}

	public void OnPathFound(List<Vector3> newPath, bool pathSuccessful) {
		findingPath = false;
		pathFound = pathSuccessful;
		requestFailed = !pathSuccessful;
		Debug.Log (pathFound);
		if (pathSuccessful && newPath.Count > 0) {
			path = newPath;
			curvePoints.Clear();
			CurvePoints(path);
			InitPathInfo ();
		}
	}

	void CurvePoints(List<Vector3> path){
		int i = 0;
		while (i < path.Count) {
			if (i > 0){
				if (i < path.Count-1){
					Line first = new Line (path[i-1], path[i]);
					Line second = new Line (path[i], path[i+1]);
					if (first.m != second.m){
						Line t1, t2, closestToFirst, closestToSecond;
						Vector3 center, firstTangent, secondTangent;
						float initRadius = 1, radius = initRadius;
						t1 = second.TranslateParallel(radius, true);
						t2 = second.TranslateParallel(radius, false);
						if (t1.DistanceFromPoint(path[i-1]) < t2.DistanceFromPoint(path[i-1])){
							closestToFirst = t1;
						}
						else{
							closestToFirst = t2;
						}
						
						t1 = first.TranslateParallel(radius, true);
						t2 = first.TranslateParallel(radius, false);
						if (t1.DistanceFromPoint(path[i+1]) < t2.DistanceFromPoint(path[i+1])){
							closestToSecond = t1;
						}
						else{
							closestToSecond = t2;
						}
						center = closestToFirst.IntersectionPoint(closestToSecond);
						firstTangent = first.ClosestPointFromPoint(center);
						secondTangent = second.ClosestPointFromPoint(center);
						radius = Mathf.Min(Vector3.Distance(path[i-1], path[i])/Vector3.Distance(firstTangent, path[i]),
						                   Vector3.Distance(path[i+1], path[i])/Vector3.Distance(secondTangent, path[i]),
						                   initRadius);
						center = path[i]+Vector3.Scale((center-path[i]),new Vector3(radius/initRadius,radius/initRadius,radius/initRadius));
						//Debug.Log (radius);
						//Debug.Log (Vector3.Distance(firstTangent, path[i])+", "+Vector3.Distance(path[i-1], path[i]));
						//Debug.Log (Vector3.Distance(secondTangent, path[i])+", "+Vector3.Distance(path[i+1], path[i]));
						firstTangent = first.ClosestPointFromPoint(center);
						secondTangent = second.ClosestPointFromPoint(center);
						path.RemoveAt(i);
						path.Insert(i, secondTangent);
						path.Insert(i, firstTangent);
						curvePoints.Enqueue (new CurvePointInfo(i+1, center, radius));
						i++;
					}
				}
			}
			i++;
		}
	}

	void InitPathInfo (){
		currentWaypoint = path[0];
		targetIndex = 0;
		rotationPoint = curvePoints.Count > 0 ? curvePoints.Dequeue ():new CurvePointInfo(-1,Vector3.zero,0);
	}

	public bool FollowPath() {
		if (targetIndex == path.Count-1 && Vector3.Distance(transform.position, currentWaypoint) <= targetRadius){
			pathFound = false;
			return true;
		}
		if (Vector3.Distance(transform.position, currentWaypoint) <= 0.001f) {
			if (targetIndex == rotationPoint.targetIndex){
				rotationPoint = curvePoints.Count > 0 ? curvePoints.Dequeue ():new CurvePointInfo(-1,Vector3.zero,0);
			}
			targetIndex ++;
			//if (targetIndex >= path.Count) {
			//	yield break;
			//}
			currentWaypoint = path[targetIndex];
		}

		if (targetIndex != rotationPoint.targetIndex){
			MoveStraightTo(currentWaypoint);
		}
		else {
			RotateTo(currentWaypoint, rotationPoint, targetIndex == 2);
		}
		return false;
	}

	void MoveStraightTo(Vector3 pos){
		transform.position = Vector3.MoveTowards(transform.position,pos,speed * Time.deltaTime);
	}

	void RotateTo(Vector3 pos, CurvePointInfo cpInfo, bool output){
		float radPerTime = speed * Time.deltaTime / cpInfo.radius;
		float currentAngle = Vector3.Angle (Vector3.right, transform.position - cpInfo.center);//* Mathf.PI/180;
		if (transform.position.z - cpInfo.center.z < 0) {
			currentAngle = 360-currentAngle;
		}
		float endAngle = Vector3.Angle (Vector3.right, pos - cpInfo.center);//* Mathf.PI/180;
		if (pos.z - cpInfo.center.z < 0) {
			endAngle = 360-endAngle;
		}
		if (output) Debug.Log ((transform.position-cpInfo.center)+",  "+Vector3.right+",  "+currentAngle+"          "+
		                       (pos-cpInfo.center)+",  "+Vector3.right+",  "+endAngle);
		transform.position = Vector3.MoveTowards(transform.position,pos,speed * Time.deltaTime);
	}

	public void OnDrawGizmos() {
		if (path != null) {
			int i = 0;
			while (i < path.Count) {
				Gizmos.color = Color.black;
				//Gizmos.DrawCube(path[i], Vector3.one);
				if (i > 0){
					Gizmos.DrawLine(path[i-1],path[i]);
					//Line l = new Line(path[i-1], path[i]);
					//Line t = l.TranslateParallel(1,true);
					//Gizmos.DrawLine(t.GetPoint(-50),t.GetPoint(50));
					//t = l.TranslateParallel(1,false);
					//Gizmos.DrawLine(t.GetPoint(-50),t.GetPoint(50));
					//Debug.Log(l);
					//Debug.Log ("D:  "+t.DistanceFromPoint(path[i-1]));
					//Debug.Log (l.CheckIfOnLine(path[i-1]));
					//Debug.Log (l.CheckIfOnLine(path[i]));
				}
				i++;
			}
			drawnPath = path;
		}
	}
}

struct CurvePointInfo {
	public int targetIndex;
	public Vector3 center;
	public float radius;

	public CurvePointInfo (int _index, Vector3 _center, float _radius){
		targetIndex = _index;
		center = _center;
		radius = _radius;
	}
}
