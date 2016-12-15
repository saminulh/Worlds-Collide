using UnityEngine;
using System.Collections;

abstract class Unit : MonoBehaviour {
	private uint playerID;
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

	private double unitID;
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

	private uint maxHealth;
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

	private uint health;
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

	private uint maxArmour;
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

	private uint armour;
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

	private uint defaultSpeed = 1;
	public uint DefaultSpeed
	{
		get
		{
			return defaultSpeed;
		}
		set
		{
			defaultSpeed = value;
		}
	}

	private uint speed;
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

	private Vector3 position;
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

	private Vector3 lastPosition;
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

	private Quaternion rotation;
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

	private Quaternion lastRotation;
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

	private Attack unitAttack;
	public Attack UnitAttack{
		get
		{
			return unitAttack;
		}
		set
		{
			unitAttack = value;
		}
	}
	
	public Unit(uint playerID, double unitID, uint maxHealth, uint maxArmour, Attack unitAttack, uint speed=defaultSpeed, Vector3 position, Quaternion rotation){
		this.playerID=playerID;
        this.unitID=unitID;
        this.maxHealth=maxHealth;
        this.health=maxHealth;
        this.maxArmour=maxArmour;
        this.armour=maxArmour;
        this.attackDamage=attackDamage;
        this.speed=speed;
        this.position=position;
        this.rotation=rotation
	}
	
	private void CheckForSelection()
    {
        SelectionBox box = GameObject.Find("Selection Box").GetComponent<SelectionBox>();
        Debug.Log(GetComponent<Renderer>().bounds.Intersects(box.GetComponent<Renderer>().bounds));
    }
	
}