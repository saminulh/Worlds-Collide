using UnityEngine;
using System.Collections;

using MELD;

public class MELDReceiver : MonoBehaviour {
	
	public string IP = "127.0.0.1";
	
	void Start(){
		MELDAPI.Connect(IP);
	}
	
	void OnApplicationQuit(){
		MELDAPI.Disconnect();
	}

	void Update(){
		if (MELDAPI.isConnected) {
			MELDAPI.Recieve();
		}
	}
}
