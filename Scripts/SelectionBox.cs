using UnityEngine;
using System.Collections;

public class SelectionBox : MonoBehaviour {
	public float depth;
	// Use this for initialization
	void Start () {
		depth = 20;
	}
	
	// Update is called once per frame
	void Update () {
		GlobalVariables vars = GameObject.Find ("Global Variables").GetComponent<GlobalVariables> ();
		Vector3 dims = vars.clickPos - vars.startClickPos + new Vector3(0,0,depth);
		transform.localScale = dims;
		transform.localPosition = vars.startClickPos+new Vector3(dims.x/2,dims.y/2,dims.z/2);
	}
}
