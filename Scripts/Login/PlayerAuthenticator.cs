using UnityEngine;
using System.Collections;

public class PlayerAuthenticator : MonoBehaviour {

    public static string playerUsername;
    public static bool isLoggedOn = false;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
}
