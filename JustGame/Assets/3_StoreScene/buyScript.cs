using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class buyScript : MonoBehaviour
{
    Item myItem;
    public Image myItemImg;
    TextMeshProUGUI curmoney;
    TextMeshProUGUI attackexp;
    TextMeshProUGUI defenseexp;
    TextMeshProUGUI recoveryexp;
    bool check = false;
    ItemManager itemD;
   
    //구매버튼 클릭시 buy 메소드에서 구매한 상품을 인벤토리에 표시
    //player정보 업데이트하는 함수 호출. 

    private void Start()
    {

        itemD = GameObject.Find("GameObject").GetComponent<ItemManager>();
        myItem = itemD.exitItem;

        curmoney = GameObject.Find("curmoney").GetComponent<TextMeshProUGUI>();
        curmoney.text = PlayerSetting.money.ToString();

        attackexp = GameObject.Find("attackexp").GetComponent<TextMeshProUGUI>();
        attackexp.text = PlayerSetting.attackLV.ToString();

        defenseexp = GameObject.Find("defenseexp").GetComponent<TextMeshProUGUI>();
        defenseexp.text = PlayerSetting.defenseLV.ToString();

        recoveryexp = GameObject.Find("recoveryexp").GetComponent<TextMeshProUGUI>();
        recoveryexp.text = PlayerSetting.recoveryLV.ToString();
        
    }
    public void buyItem(){
        if (checkMoney(myItem.itemPrice))
          {
            itemD.popup.SetActive(true) ;
          }
          else {
            if (check == true)
            {
                Debug.Log("이미 구매한 아이템");
            }
            else 
            {
                check = true;
                myItemImg.sprite = myItem.itemImage;
                itemD.boughtUpdate();
                PlayerSetting.item = myItem;

                PlayerSetting.money -= myItem.itemPrice;
                curmoney.text = PlayerSetting.money.ToString();
                Debug.Log(PlayerSetting.item.itemdesc);

            }    
        }
    }

    public void buyExpAttack(){
        if (checkMoney(100))
        {
            itemD.popup.SetActive(true);
        }
        else { 
            PlayerSetting.attackLV += 1;
            PlayerSetting.money -= itemD.getPrice("attack");
            itemD.setPrice("attack");

            attackexp.text = PlayerSetting.attackLV.ToString();
            curmoney.text = PlayerSetting.money.ToString();

         }
    }

    public void buyExpDefense(){
        if (checkMoney(100))
        {
            itemD.popup.SetActive(true);
        }
        else
        {
        PlayerSetting.defenseLV += 1;
            PlayerSetting.money -= itemD.getPrice("defense");
            itemD.setPrice("defense");
            
            defenseexp.text = PlayerSetting.defenseLV.ToString();
            curmoney.text = PlayerSetting.money.ToString();
        } 
    }

    public void buyExpRecovery(){
        if (checkMoney(100))
        {
            itemD.popup.SetActive(true);
        }
        else
        {
            PlayerSetting.recoveryLV += 1; 
            PlayerSetting.money -= itemD.getPrice("recovery");
            itemD.setPrice("recovery");
           
            recoveryexp.text = PlayerSetting.recoveryLV.ToString();
            curmoney.text = PlayerSetting.money.ToString();
        }
    }

    bool checkMoney(int money){
        if ((PlayerSetting.money-money) <= 0) {
            return true;
        }
        return false;        
    }

    public void popup() {
        GameObject.Find("popup").SetActive(false);
    }
}
