using UnityEngine;
using System.Collections;

using UnityEngine.UI;

using MELD;

public class ChatScript : MonoBehaviour {

    public Text chatBox;
    public Text inputText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void SendChatMessage()
    {
        GlobalVariables.chatList.Add(inputText.text);

        Debug.Log("Entered: " + inputText.text);

        using (MELDWriter writer = new MELDWriter())
        {
            writer.Write(inputText.text);

            MELDAPI.SendMessageToAll(ServerTags.NetworkControl.admin, ServerTags.NetworkMessages.globalChatMessage, writer);
        }

        //MELDAPI.SendMessageToAll(ServerTags.NetworkControl.admin, ServerTags.NetworkMessages.globalChatMessage, inputText.text);

        chatBox.text += System.Environment.NewLine + inputText.text;
    }
}
