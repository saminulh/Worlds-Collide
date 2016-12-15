using UnityEngine;
using System.Collections;

public class UnitStatsContainer : MonoBehaviour {

    [SerializeField]
	public class UnitStats
    {

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

        private uint defaultSpeed;
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

        private uint attackDamage;
        public uint AttackDamage
        {
            get
            {
                return attackDamage;
            }
            set
            {
                attackDamage = value;
            }
        }

        private bool isBuilder;
        public bool IsBuilder
        {
            get
            {
                return isBuilder;
            }
            set
            {
                isBuilder = value;
            }
        }

        /*public uint playerID;
        public double unitID;
        public uint maxHealth;
        public uint health;
        public uint maxArmour;
        public uint armour;
        public uint attackDamage;
        public uint defaultSpeed;
        public uint speed;

        public Vector3 position;
        public Vector3 lastPosition;

        public Quaternion rotation;
        public Quaternion lastRotation;

        public bool isBuilder;*/
    }

    void CheckForSelection()
    {
        SelectionBox box = GameObject.Find("Selection Box").GetComponent<SelectionBox>();
        Debug.Log(GetComponent<Renderer>().bounds.Intersects(box.GetComponent<Renderer>().bounds));
    }
}
