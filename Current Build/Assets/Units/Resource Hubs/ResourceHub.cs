using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class ResourceHub : Unit {
	#region Resources Attribute
	protected Dictionary<string,uint> resources;
	public Dictionary<string,uint> Resources
	{
		get
		{
			return resources;
		}
		set
		{
			resources = value;
		}
	}
	#endregion
}
