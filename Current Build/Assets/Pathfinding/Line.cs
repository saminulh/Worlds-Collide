using UnityEngine;
using System.Collections;

public class Line {
	public float m, b, horizontal;

	public Line (float _m, float _b){
		this.m = _m;
		this.b = _b;
		this.horizontal = Mathf.Infinity;
	}

	public Line (float _a){
		this.m = Mathf.Infinity;
		this.b = Mathf.Infinity;
		this.horizontal = _a;
	}

	public Line (Vector3 pos1, Vector3 pos2){
		this.m = (pos1.z - pos2.z) / (pos1.x - pos2.x);
		if (this.m != Mathf.Infinity) {
			this.b = pos1.z - this.m * pos1.x;
			this.horizontal = Mathf.Infinity;
		} else {
			this.b = Mathf.Infinity;
			this.horizontal = pos1.x;
		}
	}

	public Line (Vector3 pos, float _m){
		this.m = _m;
		if (this.m != Mathf.Infinity) {
			this.b = pos.z - this.m * pos.x;
			this.horizontal = Mathf.Infinity;
		} else {
			this.b = Mathf.Infinity;
			this.horizontal = pos.x;
		}
	}

	public Vector3 IntersectionPoint (Line other){
		if (other.m == m) {
			return Vector3.zero;
		} else {
			if (m == Mathf.Infinity){
				return other.GetPoint(horizontal);
			}
			if (other.m == Mathf.Infinity){
				return GetPoint(other.horizontal);
			}
			float x = (other.b-b)/(m-other.m);
			return GetPoint (x);
		}
	}

	public Vector3 ClosestPointFromPoint (Vector3 pos){
		Line temp = new Line (pos, -1/m);
		return IntersectionPoint (temp);
	}

	public float DistanceFromPoint (Vector3 pos){
		return Vector3.Distance (pos, ClosestPointFromPoint(pos));
	}

	public bool CheckIfOnLine(Vector3 pos){
		if (m != Mathf.Infinity) {
			//Debug.Log (pos);
			//Debug.Log (pos.z);
			//Debug.Log (m * pos.x + b);
			//Debug.Log (pos.z - m * pos.x + b);
			return Mathf.Abs(pos.z - m * pos.x - b) < 0.001f;
		} else {
			return Mathf.Abs(pos.x - horizontal) < 0.001f;
		}
	}

	public Vector3 GetPoint (float x){
		if (m != Mathf.Infinity) {
			return new Vector3(x,0,m*x+b);
		}
		return new Vector3 (x,0,0);
	}

	public Line TranslateParallel (float dist, bool up){
		float deltaB;
		Vector3 slope = new Vector3 (Mathf.Abs(m), 0, 1);
		slope.Normalize ();
		deltaB = (Mathf.Abs(m + 1 / m)) * slope.x * dist;
		if (up) {
			return new Line(m, b + deltaB);
		} else {
			return new Line(m, b - deltaB);
		}
	}

	public override string ToString(){
		if (m != Mathf.Infinity) {
			return "z = " + m + "x + " + b;
		} else {
			return "x = " + horizontal;
		}
	}
}
