using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MockUnit : Unit {

	public void Awake(){
		playerID = 0;
		unitID=0;
		maxHealth=5;
		health=maxHealth;
		maxArmour=3;
		armour=maxArmour;
		unitAttacks = new List<Attack>();
		speed=2;
		position=transform.position;
		rotation = transform.rotation;
		Debug.Log ("HI");
	}

	public void Update(){
		CheckForSelection ();
	}
}
