using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyScript : MonoBehaviour
{
    Item myItem;
    public Image myItemImg;
    PlayerSetting p1 = GameObject.Find("").GetComponent<PlayerSetting>();

    //���Ź�ư Ŭ���� buy �޼ҵ忡�� ������ ��ǰ�� �κ��丮�� ǥ��
    //player���� ������Ʈ�ϴ� �Լ� ȣ��. 

    public void buyItem(){
        
        ItemData itemD=GameObject.Find("randomstart").GetComponent<ItemData>();
        itemD.boughtUpdate();
        myItem = itemD.exitItem;      
        myItemImg.sprite = myItem.itemImage;
        //p1.item = myItem;
        //p1.money -= myItem.itemPrice;

    }

    public void buyExpAttack(){
        // p1.attackLV += 1;
        // p1.money -= myItem.itemPrice;
    }

    public void buyExpDefense(){
        //defenseLV += 1;
        //p1.money -= myItem.itemPrice;
    }

    public void buyExpRecovery(){
        //recoveryLV += 1;
        //p1.money -= myItem.itemPrice;
    }
}
