using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Ability {
	#region IsPassive Attribute
	protected bool isPassive;
	public bool IsPassive
	{
		get {
			return isPassive;
		}
		set
		{
			isPassive = value;
		}
	}
	#endregion
}
