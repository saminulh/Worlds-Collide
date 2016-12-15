using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Attack {
	#region Damage Attribute
	protected uint baseDamage;
	public uint BaseDamage
	{
		get {
			return baseDamage;
		}
		set
		{
			baseDamage = value;
		}
	}
	#endregion
	#region Attacker Attribute
	protected Unit attacker;
	public Unit Attacker
	{
		get {
			return attacker;
		}
		set
		{
			attacker = value;
		}
	}
	#endregion
	#region Attacker Attribute
	protected List<Unit> receivers;
	public List<Unit> Receivers
	{
		get {
			return receivers;
		}
		set
		{
			receivers = value;
		}
	}
	#endregion
	#region Range Attribute
	protected uint range;
	public uint Range
	{
		get {
			return range;
		}
		set
		{
			range = value;
		}
	}
	#endregion

}
