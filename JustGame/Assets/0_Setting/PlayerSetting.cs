using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour {
    public const int MaxHP = 100;
    public static int HP = 100;
    public static int attackLV = 5; //attackMin, attackMax; (min: LV / max: LV * 2)
    public static int defenseLV = 5; //deffenceMin, deffenceMax;
    public static int recoveryLV = 5; //recoveryMin, recoveryMax;
    public static int money = 0;
    public static bool [] bought = new bool[11];
    public static Item item = GameObject.Find("GameObject").GetComponent<ItemManager>().AllItemList[0];
}
