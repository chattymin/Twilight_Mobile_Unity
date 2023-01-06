using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
[System.Serializable]
public class Item
{
    public string type;
    public string itemName;
    public string itemexp;
    public string itemdesc;
    public int itemPrice;
    public Sprite itemImage;

    // 게임 첫 시작 시 Item 리스트 정의하는 생성자
    public Item(string type, string itemName, string itemexp, string itemdesc, int itemPrice)
    {
        this.type = type;
        this.itemName = itemName;
        this .itemexp = itemexp;
        this.itemdesc = itemdesc;
        this.itemPrice = itemPrice;
    }

    //게임 첫 시작 player 또는 enemy 객체 생성시 player와 enemy의 첫 아이템을 설정하는 생성자 
    public Item()
    {
       
    }
}
