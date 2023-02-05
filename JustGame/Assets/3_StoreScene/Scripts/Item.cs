using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class Item{
    //아이템 속성
    public enum Type { exp, money, heart };
    public Type itemType;
    public string itemCode;
    public string itemName;
    public string itemexp;
    public string itemdesc;
    public int itemPrice;
    public Sprite itemImage;
    public bool useValue = true;
}
