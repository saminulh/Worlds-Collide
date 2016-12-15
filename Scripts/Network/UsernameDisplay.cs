using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class UsernameDisplay : MonoBehaviour {

    public Text usernameText;

    // Use this for initialization
    void Start () {
        if (usernameText.text != "Username: " + PlayerAuthenticator.playerUsername)
        {
            usernameText.text = "Username: " + PlayerAuthenticator.playerUsername;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
