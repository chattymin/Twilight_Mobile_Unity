using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * PlayerController : player의 동작 제어 스크립트
 */
public class PlayerController : MonoBehaviour{
    private GameManager gameManager = GameManager.instance;
    private ItemController itemController;

    void Start() {
        itemController = GameObject.Find("ScriptObject").GetComponent<ItemController>();        
    }

    /***buyItem 메소드***/
    public void BuyItem(Item itemBePurchased) {

        gameManager.playerInventoryItem = itemBePurchased; //player의 인벤토리 아이템 변수에 item 저장
        gameManager.playerMoney -= itemBePurchased.itemPrice; //player의 소지금 차감
        itemController.ItemDelete();
        itemBePurchased = null;    
    }

    /***buyExpRun 메소드***/
    public void BuyExpRun(string expName) {

        switch (expName) {//expName에 따른 player의 능력치 업데이트
            case "attack":
                gameManager.playerAttackLV += 1;
                break;
            case "defense":
                gameManager.playerDefenseLV += 1;
                break;
            case "recovery":
                gameManager.playerRecoveryLV += 1;
                break;

        }
        gameManager.playerMoney -= itemController.GetPrice(expName);//player의 소지금 차감
        itemController.SetPrice(expName);//itemController SetPrice 메소드 이용해 능력치 가격 업데이트
        }       
    }



