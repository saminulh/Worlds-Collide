using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Build : Ability {
	#region BuildSpeed Attribute
	protected uint buildSpeed;
	public uint BuildSpeed
	{
		get {
			return buildSpeed;
		}
		set
		{
			buildSpeed = value;
		}
	}
	#endregion
	#region Builder Attribute
	protected Unit builder;
	public Unit Builder
	{
		get {
			return builder;
		}
		set
		{
			builder = value;
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

	public void ExecuteBuild(){
		FindTargets ();
		BuildUnits ();
	}

	protected abstract void FindTargets();
	protected void BuildUnits(){
		foreach (Unit r in receivers) {
			r.CurrentBuildProgress += buildSpeed;
			if (r.CurrentBuildProgress > r.BuildWorkReq){
				r.CurrentBuildProgress = r.BuildWorkReq;
			}
		}
	}
}
