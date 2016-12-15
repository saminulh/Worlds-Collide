using UnityEngine;
using System.Collections;
using System;

public class MoveInfoContainer : AbilityInfoContainer {
	public UnitPathGen u;
	public Vector3 targetPos;
	public float targetRadius;

	public MoveInfoContainer (UnitPathGen _u, Vector3 _targetPos, float _radius){
		u = _u;
		targetPos = _targetPos;
		targetRadius = _radius;
		abilityFunction = Abilities.Move;
	}
}
