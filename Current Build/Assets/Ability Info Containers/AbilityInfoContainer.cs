using UnityEngine;
using System.Collections;
using System;

public abstract class AbilityInfoContainer {
	public delegate bool Del(AbilityInfoContainer info);
	public Del abilityFunction; 
}
