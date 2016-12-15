using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Unit : MonoBehaviour {
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
	
	protected uint maxHealth;
	public uint MaxHealth
	{
		get
		{
			return maxHealth;
		}
		set
		{
			maxHealth = value;
		}
	}
	
	protected uint health;
	public uint Health
	{
		get
		{
			return health;
		}
		set
		{
			health = value;
		}
	}
	
	protected uint maxArmour;
	public uint MaxArmour
	{
		get
		{
			return maxArmour;
		}
		set
		{
			maxArmour = value;
		}
	}
	
	protected uint armour;
	public uint Armour
	{
		get
		{
			return armour;
		}
		set
		{
			armour = value;
		}
	}
	
	protected uint speed;
	public uint Speed
	{
		get
		{
			return speed;
		}
		set
		{
			speed = value;
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
	
	protected List<Attack> unitAttacks;
	public List<Attack> UnitAttacks
	{
		get
		{
			return unitAttacks;
		}
		set
		{
			unitAttacks = value;
		}
	}

	protected void CheckForSelection()
	{
		SelectionBox box = GameObject.Find("Selection Box").GetComponent<SelectionBox>();
		Debug.Log(GetComponent<Renderer>().bounds.Intersects(box.GetComponent<Renderer>().bounds));
	}
	
}