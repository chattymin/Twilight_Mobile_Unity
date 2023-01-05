using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyScript : MonoBehaviour
{
    Item myItem;
    public Image myItemImg;
    PlayerSetting p1 = GameObject.Find("").GetComponent<PlayerSetting>();

    //구매버튼 클릭시 buy 메소드에서 구매한 상품을 인벤토리에 표시
    //player정보 업데이트하는 함수 호출. 

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
