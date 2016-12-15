using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseOver(){
		//Debug.Log (Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 100)));
		if (GlobalVariables.rightClicked && !GlobalVariables.wasRightClicked) {
			if (Input.GetKey(KeyCode.Z)){
				GameObject temp = Instantiate(Resources.Load("Prefabs/MockBuildingPrefab", typeof(GameObject)), GlobalVariables.mouseWorldPos, Quaternion.identity) as GameObject;
				Debug.Log("HI");
				foreach (Unit u in GlobalVariables.selected){
					u.EnqueueMove(GlobalVariables.mouseWorldPos, temp.GetComponent<Unit> ().Radius+u.Stats.buildRange);
					u.EnqueueBuild(temp.GetComponent<Unit> ());
				}
			}
			else{
				foreach (Unit u in GlobalVariables.selected){
					u.EnqueueMove(GlobalVariables.mouseWorldPos);
				}
			}
		}

	}
}
