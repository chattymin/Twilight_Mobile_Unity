using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour {
    public static int HP = 100;
    public static int attackLV = 1; //attackMin, attackMax; (min: LV / max: LV * 2)
    public static int defenseLV = 1; //deffenceMin, deffenceMax;
    public static int recoveryLV = 1; //recoveryMin, recoveryMax;
    public static int money =1000;
    public static bool [] bought = new bool[10];
    public static Item item;
}
