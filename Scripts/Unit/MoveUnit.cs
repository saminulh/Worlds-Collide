using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using MELD;

public class MoveUnit : MonoBehaviour {

	void FixedUpdate(){

		//Update Server, since a unit's stuff has been changed
		//MELDAPI.SendMessageToOthers (ServerTags.NetworkControl.admin, ServerTags.NetworkMessages.unitUpdated, UnitStatsContainer.UnitStats);
	}

    /*public void SerializeUnitStats (UnitStatsContainer.UnitStats _stats, bool _unitCreated)
    {
        using (MELDWriter writer = new MELDWriter())
        {
            writer.Write(_stats.MaxArmour);
            writer.Write(_stats.Armour);
            writer.Write(_stats.AttackDamage);
            writer.Write(_stats.MaxHealth);
            writer.Write(_stats.Health);

            writer.Write(_stats.PlayerID);

            writer.Write(_stats.Position.x);
            writer.Write(_stats.Position.y);
            writer.Write(_stats.Position.z);

            writer.Write(_stats.Rotation.w);
            writer.Write(_stats.Rotation.x);
            writer.Write(_stats.Rotation.y);
            writer.Write(_stats.Rotation.z);

            writer.Write(_stats.DefaultSpeed);
            writer.Write(_stats.Speed);
            writer.Write(_stats.UnitID);

            writer.Write(_stats.IsBuilder);

            writer.Write(_unitCreated);

            if (_unitCreated)
            {
                MELDAPI.SendMessageToOthers((byte)ServerTags.NetworkControl.localPlayer, ServerTags.NetworkMessages.unitCreated, writer);
                Debug.Log("Sent others a new unit (for unit: " + _stats.UnitID + " )! From player: " + ServerTags.NetworkControl.localPlayer);
            }   
            else
            {
                MELDAPI.SendMessageToOthers((byte)ServerTags.NetworkControl.localPlayer, ServerTags.NetworkMessages.unitUpdated, writer);
                Debug.Log("Sent others a unit update (for unit: " + _stats.UnitID + " )! From player: " + ServerTags.NetworkControl.localPlayer);
            }
                
        }
    }

    public void DeserializeUnitStats (object data)
    {
        if (data is MELDReader)
        {
            //Cast in a using statement because we are using streams and therefore it 
            //is important that the memory is deallocated afterwards, you wont be able
            //to use this more than once though.
            using (MELDReader reader = (MELDReader)data)
            {
                uint _maxArmour = reader.ReadUInt32();
                uint _armour = reader.ReadUInt32();
                uint _attackDamage = reader.ReadUInt32();
                uint _maxHealth = reader.ReadUInt32();
                uint _health = reader.ReadUInt32();
                uint _playerID = reader.ReadUInt32();

                float _posX = reader.ReadSingle();
                float _posY = reader.ReadSingle();
                float _posZ = reader.ReadSingle();

                float _rotW = reader.ReadSingle();
                float _rotX = reader.ReadSingle();
                float _rotY = reader.ReadSingle();
                float _rotZ = reader.ReadSingle();

                uint _defaultSpeed = reader.ReadUInt32();
                uint _speed = reader.ReadUInt32();
                uint _unitID = reader.ReadUInt32();

                bool _isBuilder = reader.ReadBoolean();

                bool _unitCreated = reader.ReadBoolean();

                if (_unitCreated)
                {
                    UnitStatsContainer.UnitStats _newUnit = new UnitStatsContainer.UnitStats();

                    _newUnit.Armour = _armour;
                    _newUnit.AttackDamage = _attackDamage;
                    _newUnit.DefaultSpeed = _defaultSpeed;
                    _newUnit.Health = _health;
                    _newUnit.IsBuilder = _isBuilder;
                    _newUnit.MaxArmour = _maxArmour;
                    _newUnit.MaxHealth = _maxHealth;
                    _newUnit.PlayerID = _playerID;
                    _newUnit.Position = new Vector3 (_posX, _posY, _posZ);
                    _newUnit.Rotation = new Quaternion(_rotX, _rotY, _rotZ, _rotW);
                    _newUnit.Speed = _speed;
                    _newUnit.UnitID = _unitID;

                    GlobalVariables.unitsList.Add(_newUnit);
                    Debug.Log("Received a unit creation (for unit: " + _unitID + " )! From player: " + _playerID);
                }
                else
                {
                    for (int i = 0; i < GlobalVariables.unitsList.Count; i++)
                    {
                        if (GlobalVariables.unitsList[i].PlayerID == _playerID && GlobalVariables.unitsList[i].UnitID == _unitID)
                        {
                            GlobalVariables.unitsList[i].MaxArmour = _maxArmour;
                            GlobalVariables.unitsList[i].Armour = _armour;
                            GlobalVariables.unitsList[i].AttackDamage = _attackDamage;
                            GlobalVariables.unitsList[i].MaxHealth = _maxHealth;
                            GlobalVariables.unitsList[i].Health = _health;
                            GlobalVariables.unitsList[i].Position = new Vector3(_posX, _posY, _posZ);
                            GlobalVariables.unitsList[i].Rotation = new Quaternion(_rotX, _rotY, _rotZ, _rotW);
                            GlobalVariables.unitsList[i].Speed = _speed;
                        }
                    }
                    Debug.Log("Received a unit update for unit: " + _unitID + " from player: " + _playerID);
                }
            }
        }
        else
        {
            Debug.LogError("Should have recieved a reciever but didn't! (Got: " + data.GetType() + ")");
        }

    }*/
}
