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
   
    //ï¿½ï¿½ï¿½Å¹ï¿½Æ° Å¬ï¿½ï¿½ï¿½ï¿½ buy ï¿½Þ¼Òµå¿¡ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½Ç°ï¿½ï¿½ ï¿½Îºï¿½ï¿½ä¸®ï¿½ï¿½ Ç¥ï¿½ï¿½
    //playerï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Æ®ï¿½Ï´ï¿½ ï¿½Ô¼ï¿½ È£ï¿½ï¿½. 

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
                Debug.Log("ÀÌ¹Ì ±¸¸ÅÇÑ ¾ÆÀÌÅÛ");
            }
            else 
            {
                check = true;
                myItemImg.sprite = myItem.itemImage;
                itemD.boughtUpdate();
                PlayerSetting.item = myItem;

                PlayerSetting.money -= myItem.itemPrice;
                curmoney.text = PlayerSetting.money.ToString();
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
