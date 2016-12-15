using UnityEngine;
using System.Collections;

using UnityEngine.UI;

using MELD;

public class SignUpManager : MonoBehaviour {

    public InstantGuiInputText loginName;
    public InstantGuiInputText pass1;
    public InstantGuiInputText pass2;
    public InstantGuiInputText email;

	// Use this for initialization
	void Start () {
        CheckInput();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CheckInput()
    {
        if (loginName.text != null)
        {
            if (pass1.text == pass2.text)
            {
                if (pass1.text != loginName.text)
                {
                    if (IsValidEmail(email.text))
                    {
                        //Seems to be a valid enough email (haha)
                        SignUp();
                    }
                }
            }
        }
    }

    bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void SignUp()
    {
        using (MELDWriter writer = new MELDWriter())
        {
            writer.Write(loginName.text);
            writer.Write(pass1.text);
            writer.Write(email.text);

            MELDAPI.SendMessageToServer(ServerTags.NetworkControl.newAccountSignUp, 0, writer);
        }
    }
}
