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
    ItemData itemD;
   
    //���Ź�ư Ŭ���� buy �޼ҵ忡�� ������ ��ǰ�� �κ��丮�� ǥ��
    //player���� ������Ʈ�ϴ� �Լ� ȣ��. 

    private void Start()
    {

        itemD = GameObject.Find("GameObject").GetComponent<ItemData>();
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

             if (check == true) {
                itemD.popup.SetActive(true);
            }
            else {
         

               check = true;
               //ItemData itemD = GameObject.Find("GameObject").GetComponent<ItemData>();
               myItemImg.sprite = myItem.itemImage;
               itemD.boughtUpdate();
               PlayerSetting.item = myItem;
               PlayerSetting.money -= myItem.itemPrice;
                playerInfo.updateMoney(); 
               }
           }
    }

    public void buyExpAttack(){
        if (checkMoney(myItem.itemPrice))
        {
            itemD.popup.SetActive(true);
        }
        else { 
            PlayerSetting.attackLV += 1;
            PlayerSetting.money -= 100;
            attackexp.text = PlayerSetting.attackLV.ToString();
            curmoney.text = PlayerSetting.money.ToString();

         }
    }

    public void buyExpDefense(){
        if (checkMoney(myItem.itemPrice))
        {
            itemD.popup.SetActive(true);
        }
        else
        {
        PlayerSetting.defenseLV += 1;
            PlayerSetting.money -= 100;
            defenseexp.text = PlayerSetting.defenseLV.ToString();
            curmoney.text = PlayerSetting.money.ToString();
        } 
    }

    public void buyExpRecovery(){
        if (checkMoney(myItem.itemPrice))
        {
            itemD.popup.SetActive(true);
        }
        else
        {
            PlayerSetting.recoveryLV += 1;
            PlayerSetting.money -= 100;
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
