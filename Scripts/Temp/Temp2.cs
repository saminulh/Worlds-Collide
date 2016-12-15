using UnityEngine;
using System.Collections;

public class Temp2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Unit u = GetComponent<Unit> ();
		Debug.Log (u.Health);
	}
}
