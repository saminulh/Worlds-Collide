using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Heal : Ability {
	#region HealSpeed Attribute
	protected uint healSpeed;
	public uint HealSpeed
	{
		get {
			return healSpeed;
		}
		set
		{
			healSpeed = value;
		}
	}
	#endregion
	#region Healer Attribute
	protected Unit healer;
	public Unit Healer
	{
		get {
			return healer;
		}
		set
		{
			healer = value;
		}
	}
	#endregion
	#region Receivers Attribute
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
	
	public void ExecuteHeal(){
		FindTargets ();
		HealUnits ();
	}
	
	protected abstract void FindTargets();
	protected void HealUnits(){
		foreach (Unit r in receivers) {
			r.Health += healSpeed;
			if (r.Health > r.MaxHealth){
				r.Health = r.MaxHealth;
			}
		}
	}
}
