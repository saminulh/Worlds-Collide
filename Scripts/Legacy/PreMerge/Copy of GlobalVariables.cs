using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalVariables : MonoBehaviour {

    public static int playerID;

    public static List<UnitStatsContainer.UnitStats> unitsList = new List<UnitStatsContainer.UnitStats>();
    public static List<string> chatList = new List<string>();

    public static bool isOnline;
    public static bool leftClicked;
    public static Vector3 startClickPos, clickPos;

}
