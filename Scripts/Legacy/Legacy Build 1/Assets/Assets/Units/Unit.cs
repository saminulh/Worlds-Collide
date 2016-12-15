using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Unit : MonoBehaviour {
	public Vector3 start, pos, current, c, e, t;
	public Bounds bounds;
	public float left, right, up, down;
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
	
	protected List<Ability> unitAbilities;
	public List<Ability> UnitAbilities
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

	protected void CheckForSelection()
	{
		bounds = GetComponent<Renderer> ().bounds;
		start = GlobalVariables.startClickPos;
		current = GlobalVariables.clickPos;
		c = bounds.center;
		e = bounds.extents;
		t = Camera.main.WorldToScreenPoint(c-new Vector3(e.x,e.y,0));
		left = t.x;
		down = t.y;
		t = Camera.main.WorldToScreenPoint(c+new Vector3(e.x,e.y,0));
		right = t.x;
		up = t.y;
		pos = Camera.main.WorldToScreenPoint (transform.position);

		if ( ( ((start.x <= pos.x && pos.x <= current.x) || (start.x >= pos.x && pos.x >= current.x))
	  	    && ((start.y <= pos.y && pos.y <= current.y) || (start.y >= pos.y && pos.y >= current.y)) )
		  || ( ((left <= start.x && start.x <= right) || (left >= start.x && start.x >= right)) 
		    && ((down <= start.y && start.y <= up) || (down >= start.y && start.y >= up)) ) ) {
			Debug.Log (true);
		} else {
			Debug.Log (false);
		}
		//pos.z = 1;
		//pos = Camera.main.ScreenToWorldPoint (pos);
		//SelectionBox box = GameObject.Find("Selection Box").GetComponent<SelectionBox>();
		//Debug.Log(GetComponent<Renderer>().bounds.Intersects(GlobalVariables.selector.GetComponent<Renderer>().bounds));
	}
	
}