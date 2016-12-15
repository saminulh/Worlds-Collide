using UnityEngine;
using System.Collections;

public class ServerTags : MonoBehaviour {

	public class NetworkControl {

		public const int server = 225;
        public const int admin = 226;
        public const int newAccountSignUp = 227;
        public const int accountLogin = 228;

        public static int localPlayer = GlobalVariables.playerID;

		public const int player1 = 1;
		public const int player2 = 2;
		public const int player3 = 3;
		public const int player4 = 4;
	}


	public class NetworkMessages {
		public const int victory = 1;

		public const int playerJoined = 2;
		public const int playerLeft = 3;

		public const int unitCreated = 4;
		public const int unitUpdated = 5;
		public const int resourceUpdated = 6;
		public const int techUpdated = 7;

        public const int globalChatMessage = 190;

        public const int team1ChatMessage = 201;
        public const int team2ChatMessage = 202;
        public const int team3ChatMessage = 203;
        public const int team4ChatMessage = 204;
        public const int team5ChatMessage = 205;
        public const int team6ChatMessage = 206;
        public const int team7ChatMessage = 207;
        public const int team8ChatMessage = 208;
        public const int team9ChatMessage = 209;
        public const int team10ChatMessage = 210;
    }

}
