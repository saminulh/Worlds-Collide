using UnityEngine;
using System.Collections;

using UnityEngine.UI;

using MELD;

public class LoginCodeExectuor : MonoBehaviour {

    public InstantGuiInputText loginName;
    public InstantGuiInputText password;

	// Use this for initialization
	void Start () {
	    if (loginName.text != "Enter login name ..." && password.text != "Pass")
        {
            using (MELDWriter writer = new MELDWriter())
            {
                writer.Write(loginName.text);
                writer.Write(password.text);

                MELDAPI.SendMessageToServer(ServerTags.NetworkControl.accountLogin, 0, writer);
            }
        }
	}
}
