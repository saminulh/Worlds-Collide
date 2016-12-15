using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MockMinion : Minion {

	public void Awake(){
		playerID = 0;
		unitID=0;
		buildWorkReq = 1;
		currentBuildProgress = 1;
		stats = new StatsContainer ();
		stats.maxHealth=5;
		stats.health=stats.maxHealth;
		stats.maxArmour=3;
		stats.buildSpeed = 3;
		stats.buildRange = 1;
		stats.armour=stats.maxArmour;
		unitAbilities = new List<Del>();
		unitAbilities.Add (Abilities.Move);
		unitAbilities.Add (Abilities.Build);
		abilityQueue = new Queue<AbilityInfoContainer> ();
		stats.speed=40;
		position=transform.position;
		rotation = transform.rotation;
		radius = transform.localScale.x / Mathf.Sqrt (2);
		Debug.Log ("HI");
	}

	public void Update(){
		CheckForSelection ();
		if (abilityQueue.Count > 0) {
			if (abilityQueue.Peek ().abilityFunction (abilityQueue.Peek ())){
				abilityQueue.Dequeue ();
			}
		}
	}
}
