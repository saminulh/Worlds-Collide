using UnityEngine;
using System.Collections;

public class IntersectTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void CheckForSelection(){
		SelectionBox box = GameObject.Find ("Selection Box").GetComponent<SelectionBox> ();
		Debug.Log (GetComponent<Renderer> ().bounds.Intersects (box.GetComponent<Renderer> ().bounds));
	}
}
