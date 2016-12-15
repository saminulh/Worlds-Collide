using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Tile : Unit {
	#region ControllingTeam Attribute
	protected uint controllingTeam;
	public uint ControllingTeam
	{
		get {
			return controllingTeam;
		}
		set
		{
			controllingTeam = value;
		}
	}
	#endregion
	#region AdjacentTiles Attribute
	protected List<Terrain> adjacentTiles;
	public List<Terrain> AdjacentTiles
	{
		get {
			return adjacentTiles;
		}
		set
		{
			adjacentTiles = value;
		}
	}
	#endregion

}
