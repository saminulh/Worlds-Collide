using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class Unit : MonoBehaviour {
	public Vector3 start, pos, current, c, e, t;
	public Bounds bounds;
	public float left, right, up, down;
	public bool isSelected, wasBoxEnabled = false;

	protected uint playerID;
	public uint PlayerID
	{
		get {
			return playerID;
		}
		set
		{
			playerID = value;
		}
	}
	
	protected double unitID;
	public double UnitID
	{
		get
		{
			return unitID;
		}
		set
		{
			unitID = value;
		}
	}

	protected StatsContainer stats;
	public StatsContainer Stats {
		get {
			return stats;
		}
		set {
			stats = value;
		}
	}


	protected uint buildWorkReq;
	public uint BuildWorkReq
	{
		get
		{
			return buildWorkReq;
		}
		set
		{
			buildWorkReq = value;
		}
	}

	protected uint currentBuildProgress;
	public uint CurrentBuildProgress
	{
		get
		{
			return currentBuildProgress;
		}
		set
		{
			currentBuildProgress = value;
		}
	}
	

	protected float radius;
	public float Radius
	{
		get
		{
			return radius;
		}
		set
		{
			radius = value;
		}
	}
	
	protected Vector3 position;
	public Vector3 Position
	{
		get
		{
			return position;
		}
		set
		{
			position = value;
		}
	}
	
	protected Vector3 lastPosition;
	public Vector3 LastPosition
	{
		get
		{
			return lastPosition;
		}
		set
		{
			lastPosition = value;
		}
	}
	
	protected Quaternion rotation;
	public Quaternion Rotation
	{
		get
		{
			return rotation;
		}
		set
		{
			rotation = value;
		}
	}
	
	protected Quaternion lastRotation;
	public Quaternion LastRotation
	{
		get
		{
			return lastRotation;
		}
		set
		{
			lastRotation = value;
		}
	}

	public delegate bool Del(AbilityInfoContainer info);
	protected List<Del> unitAbilities;
	public List<Del> UnitAbilities
	{
		get
		{
			return unitAbilities;
		}
		set
		{
			unitAbilities = value;
		}
	}

	protected Queue<AbilityInfoContainer> abilityQueue;

	public void EnqueueMove (Vector3 targetPos, float radius = 0){
		if (unitAbilities.Contains (Abilities.Move)) {
			abilityQueue.Enqueue(new MoveInfoContainer(GetComponent<UnitPathGen> (), targetPos, radius));
		}
	}

	public void EnqueueBuild (Unit target){
		if (unitAbilities.Contains (Abilities.Build)) {
			abilityQueue.Enqueue (new BuildInfoContainer (this,target, target.Radius+stats.buildRange));
		}
	}
		
	protected void CheckForSelection()
	{
		if (!(SelectionBox.Size.Equals (Vector3.zero) && SelectionBox.Position.Equals (Vector3.zero))) {
			bounds = GetComponent<Renderer> ().bounds;
			start = GlobalVariables.startClickPos;
			current = GlobalVariables.clickPos;
			c = bounds.center;
			e = bounds.extents;
			t = Camera.main.WorldToScreenPoint (c - new Vector3 (e.x, 0, e.z));
			left = t.x;
			down = t.y;
			t = Camera.main.WorldToScreenPoint (c + new Vector3 (e.x, 0, e.z));
			right = t.x;
			up = t.y;
			pos = Camera.main.WorldToScreenPoint (transform.position);

			if ((((start.x <= pos.x && pos.x <= current.x) || (start.x >= pos.x && pos.x >= current.x))
				&& ((start.y <= pos.y && pos.y <= current.y) || (start.y >= pos.y && pos.y >= current.y)))
				|| (((left <= start.x && start.x <= right) || (left >= start.x && start.x >= right)) 
				&& ((down <= start.y && start.y <= up) || (down >= start.y && start.y >= up)))) {
				isSelected = true;
				//Debug.Log (true);
			} else {
				isSelected = false;
				//Debug.Log (false);
			}
			wasBoxEnabled = true;
			//pos.z = 1;
			//pos = Camera.main.ScreenToWorldPoint (pos);
			//SelectionBox box = GameObject.Find("Selection Box").GetComponent<SelectionBox>();
			//Debug.Log(GetComponent<Renderer>().bounds.Intersects(GlobalVariables.selector.GetComponent<Renderer>().bounds));
		} else {
			if (isSelected && wasBoxEnabled) {
				GlobalVariables.selected.Add(this);
			}
			wasBoxEnabled = false;
		}

	}

	public bool BuildUp(uint maxWorkDelta){
		if (buildWorkReq - currentBuildProgress <= maxWorkDelta) {
			currentBuildProgress = buildWorkReq;
			GetComponent<Renderer> ().material.color = Color.blue;
			Debug.Log (maxWorkDelta+"    "+currentBuildProgress+"     "+buildWorkReq);
			return true;
		} else {
			currentBuildProgress += maxWorkDelta;
			GetComponent<Renderer> ().material.color = new Color (1-(float) currentBuildProgress/buildWorkReq, 1, 1-(float) currentBuildProgress/buildWorkReq);
			return false;
		}
	}
	
}

public struct StatsContainer{
	public uint buildSpeed;	
	public float buildRange;
	public uint maxHealth;
	public uint health;
	public uint maxArmour;
	public uint armour;
	public uint speed;

}