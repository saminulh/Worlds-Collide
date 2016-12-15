using UnityEngine;
using System.Collections;
using System;

public class BuildInfoContainer : AbilityInfoContainer {
	public Unit u;
	public Unit target;
	public float maxRange;

	public BuildInfoContainer (Unit _u, Unit _target, float _maxRange){
		u = _u;
		target = _target;
		maxRange = _maxRange;
		abilityFunction = Abilities.Build;
	}
}
