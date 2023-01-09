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
    ItemManager itemD;
    playerInfoUpdate playerInfo;
   

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

        playerInfo = GameObject.Find("GameObject").GetComponent<playerInfoUpdate>();
        
    }

    /* buyItem 메소드
     * 아이템 구매 버튼을 클릭했을 경우 작동하는 메소드
     */
    public void buyItem(){
        if (checkMoney(myItem.itemPrice)) // 현재 아이템을 구매할 수 있는지 확인
        { 
            itemD.popup.SetActive(true) ; //구매할 수 없는 경우 popup을 띄움
        }
        else {
            if (PlayerSetting.bought[itemD.indexNumber] == true) // 이미 player가 구매한 상품일 경우
            {
                Debug.Log("이미 구매한 아이템");
            }
            else 
            {
                myItemImg.sprite = myItem.itemImage; // inventroy 아이템 이미지를 구매한 아이템 이미지로 변경
                itemD.boughtUpdate(); // player의 정보 업데이트. 구매 버튼 업데이트
                PlayerSetting.item = myItem; // player의 아이템을 구매한 아이템으로 변경

                PlayerSetting.money -= myItem.itemPrice; // player 소지금 차감
                curmoney.text = PlayerSetting.money.ToString(); // 현재 소지금 변경
            }    
        }
    }


    /* buyExpAttack 메소드
     * defense 레벨업 구매할 경우 작동하는 메소드 
     */
    public void buyExpAttack(){
        if (checkMoney(ItemManager.aPrice)) // 현재 attack 레벨업을 할 수 있는지 확인
        {
            itemD.popup.SetActive(true); // 구매할 수 없는 경우 popup을 띄움
        }
        else { //구매할 수 있는 경우
            PlayerSetting.attackLV += 1; // player의 LV 1 증가
            PlayerSetting.money -= itemD.getPrice("attack"); // player 소지금 차감
            itemD.setPrice("attack"); //아이템 가격 업데이트

            // player의 정보 표시
            attackexp.text = PlayerSetting.attackLV.ToString();
            curmoney.text = PlayerSetting.money.ToString();
        }
    }

    /* buyExpDefense 메소드
     * defense 레벨업 구매할 경우 작동하는 메소드 
     */

    public void buyExpDefense(){
        if (checkMoney(ItemManager.dPrice)) // 현재 defense 레벨업을 할 수 있는지 확인
        {
            itemD.popup.SetActive(true); // 구매할 수 없는 경우 popup을 띄움
        }
        else // 구매할 수 있는 경우
        {
            PlayerSetting.defenseLV += 1;//player의 LV 1 증가
            PlayerSetting.money -= itemD.getPrice("defense");  //player의 소지금 차감
            itemD.setPrice("defense"); //아이템 가격 업데이트

            // player의 정보 표시
            defenseexp.text = PlayerSetting.defenseLV.ToString();
            curmoney.text = PlayerSetting.money.ToString();
        } 
    }

    /* buyExpRecovery 메소드
     * recovery 레벨업 구매할 경우 작동하는 메소드 
     */

    public void buyExpRecovery(){
        if (checkMoney(ItemManager.rPrice)) // 현재 recovery 레벨업을 할 수 있는지 확인
        { 
            itemD.popup.SetActive(true); // 구매할 수 없는 경우 popup을 띄움
        }
        else // 구매할 수 있는 경우
        {
            PlayerSetting.recoveryLV += 1; //player의 LV 1 증가
            PlayerSetting.money -= itemD.getPrice("recovery"); //player의 소지금 차감
            itemD.setPrice("recovery"); //아이템 가격 업데이트

            // player의 정보 표시
            recoveryexp.text = PlayerSetting.recoveryLV.ToString(); 
            curmoney.text = PlayerSetting.money.ToString();
        }
    }

    /* checkMoney 메소드
     * Player의 소지금-아이템 가격 결과값이 0보다 작을 경우 true를 반환해
     * 구매할 수 없도록 함. 
     */

    bool checkMoney(int money){
        if ((PlayerSetting.money-money) < 0) {
            return true;
        }
        return false;        
    }

    /* popup 메소드
     * player의 소지금이 부족할 시 popup창을 띄우는 메소드
     */
    public void popup() {
        GameObject.Find("popup").SetActive(false);
    }
}
