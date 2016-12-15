using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MockMinion : Minion {

	public void Awake(){
		playerID = 0;
		unitID=0;
		buildWorkReq = 1;
		currentBuildProgress = 1;
		maxHealth=5;
		health=maxHealth;
		maxArmour=3;
		armour=maxArmour;
		unitAbilities = new List<Ability>();
		unitAbilities.Add (new MockAttack (this));
		speed=2;
		position=transform.position;
		rotation = transform.rotation;
		Debug.Log ("HI");
	}

	public void Update(){
		CheckForSelection ();
	}
}
