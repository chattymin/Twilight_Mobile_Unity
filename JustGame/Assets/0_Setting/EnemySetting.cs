using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetting : MonoBehaviour {
    public const int MaxHP = 3;
    public static int HP = 3;
    public static int attackLV = 5; //attackMin, attackMax; (min: LV / max: LV * 2)
    public static int defenseLV = 5; //deffenceMin, deffenceMax;
    public static int recoveryLV = 5; //recoveryMin, recoveryMax;
}
