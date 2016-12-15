using UnityEngine;
using System.Collections;

using UnityEngine.UI;

using MELD;

public class LoginManager : MonoBehaviour {

    public GameObject loginWindow;
    public GameObject signUpWindow;
    public GameObject successWindow;
    public GameObject failureWindow;

    void Start()
    {
        MELDAPI.onData += OnDataReceived;
        LoginToServer();
    }

    void OnDataReceived(byte tag, ushort subject, object data)
    {
        if (tag == ServerTags.NetworkControl.newAccountSignUp && subject == 1)
        {
            if (data.Equals(true))
            {
                loginWindow.SetActive(true);
                successWindow.SetActive(true);
                signUpWindow.SetActive(false);
            }
            else
            {
                failureWindow.SetActive(true);
            }
        }

        if (tag == ServerTags.NetworkControl.accountLogin && subject == 1)
        {
            Debug.Log("Received login code!");
            if (data.ToString() != null)
            {
                Debug.Log("We gucci!");

                PlayerAuthenticator.playerUsername = data.ToString();

                Debug.Log(PlayerAuthenticator.playerUsername);

                PlayerAuthenticator.isLoggedOn = true;
                Application.LoadLevel(1);
            }
            else
            {
                PlayerAuthenticator.isLoggedOn = false;
            }
        }
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void LoginToServer()
    {


        MELDAPI.SendMessageToServer(0, 0, "Test");
    }
}
