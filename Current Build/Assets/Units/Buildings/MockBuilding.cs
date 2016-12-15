using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MockBuilding : Building {
	public bool prebuilt;

	void Awake () {
		playerID = 0;
		unitID=0;
		buildWorkReq = 10000;
		stats = new StatsContainer ();
		stats.maxHealth=5;
		stats.health=stats.maxHealth;
		stats.maxArmour=3;
		stats.buildSpeed = 3;
		stats.buildRange = 1;
		stats.armour=stats.maxArmour;
		unitAbilities = new List<Del>();
		abilityQueue = new Queue<AbilityInfoContainer> ();
		stats.speed=0;
		position=transform.position;
		rotation = transform.rotation;
		radius = transform.localScale.x / Mathf.Sqrt (2);
		if (!prebuilt) {
			currentBuildProgress = 0;
			GetComponent<Renderer> ().material.color = Color.white;
		} else {
			currentBuildProgress = buildWorkReq;
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
