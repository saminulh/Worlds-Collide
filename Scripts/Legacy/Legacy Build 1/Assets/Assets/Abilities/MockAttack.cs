using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MockAttack : Attack {
	public MockAttack(Unit attacker){
		isPassive = false;
		baseDamage = 1;
		this.attacker = attacker;
		receivers = new List<Unit>();
		range = 1;
		isPlanarAttack = true;
	}

	protected override void FindTargets(){
		receivers.Clear ();
		receivers.Add(GameObject.Find("Cube").GetComponent<Unit>());
	}
}
