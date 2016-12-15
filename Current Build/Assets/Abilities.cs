using UnityEngine;
using System.Collections;

public class Abilities {
	public static bool Move (AbilityInfoContainer c){
		//Debug.Log ("Moving");
		MoveInfoContainer container = (MoveInfoContainer) c;

		if (container.u.requestFailed) {
			//Debug.Log ("Failed");
			return true;
		}
		if (!container.u.findingPath && !container.u.pathFound) {
			//Debug.Log ("Requested");
			container.u.RequestPath (container.targetPos, container.targetRadius);
		}
		if (container.u.pathFound) {
			//Debug.Log ("Following");
			return container.u.FollowPath ();
		}
		return false;
	}

	public static bool Build (AbilityInfoContainer c){
		BuildInfoContainer container = (BuildInfoContainer)c;
		if (Vector3.Distance (container.u.transform.position, container.target.transform.position) >= container.maxRange) {
			return true;
		}
		return container.target.BuildUp ((uint) (1000*container.u.Stats.buildSpeed * Time.deltaTime));
	}
}
