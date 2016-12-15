using UnityEngine;
using System.Collections;

public class Temp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Unit u = GetComponent<Unit> ();
		u.UnitAttacks [0].ExecuteAttack ();
	}
}
