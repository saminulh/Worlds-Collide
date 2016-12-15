using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MockResourceHub : ResourceHub {

	public void Awake(){
		playerID = 0;
		unitID = 0;
		buildWorkReq = 1;
		currentBuildProgress = 1;
		maxHealth=1;
		health=maxHealth;
		maxArmour=0;
		armour=maxArmour;
		unitAbilities = new List<Ability> ();
		speed=2;
		position=transform.position;
		rotation = transform.rotation;
		resources = new Dictionary<string, uint> ();
		
		Debug.Log ("HI");
	}
	
	public void Update(){
		CheckForSelection ();
	}
}
