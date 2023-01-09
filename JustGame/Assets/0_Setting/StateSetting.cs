using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSetting : MonoBehaviour
{
    public static string states = null;
    /* types of states
     * SelectST : player select action
     * BattleST : player battle with enemy
     * WinST : player won the battle
     * LoseST : player lose the battle
     */

    public static string bossName = "BlackTurtoise";
    /* 현무 -> 백호 -> 주작 -> 청룡 순서
     * BlackTurtoise -> WhiteTiger -> RedBird -> BlueDragon
     */

    public static void SetStates(string str)
    {
        states = str;
    }

    public static bool CompareStates(string str)
    {
        if (states == str)
            return true;
        return false;
    }

    public static string GetState()
    {
        return states;
    }
}
