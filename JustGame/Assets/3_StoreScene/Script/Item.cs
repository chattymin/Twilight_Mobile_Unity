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

    // ���� ù ���� �� Item ����Ʈ �����ϴ� ������
    public Item(string type, string itemName, string itemexp, string itemdesc, int itemPrice)
    {
        this.type = type;
        this.itemName = itemName;
        this .itemexp = itemexp;
        this.itemdesc = itemdesc;
        this.itemPrice = itemPrice;
    }

    //���� ù ���� player �Ǵ� enemy ��ü ������ player�� enemy�� ù �������� �����ϴ� ������ 
    public Item()
    {
       
    }
}
