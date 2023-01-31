using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * PlayerController : player의 동작 제어 스크립트
 */
public class PlayerController : MonoBehaviour {
    private GameManager gameManager;
    private UiController uiController;
    private ItemController itemController;

    void Start() {
        gameManager = GameManager.instance;
        itemController = GameObject.Find("ScriptObject").GetComponent<ItemController>();
        uiController = GameObject.Find("ScriptObject").GetComponent<UiController>();
    }

    /***buyItem 메소드***/
    public void BuyItem(Item itemBePurchased) {
        if (CheckMoney(itemBePurchased.itemPrice)) {//Player의 소지금을 확인해 구매할 수 있는지 판단        
            uiController.checkMoneyPopup.SetActive(true); //구매할 수 없을 경우 구매할 수 없다는 팝업창 활성화
        }
        /*else if(IsTruePurchase()) {//소지금 확인 후 구매 의사를 묻기 위한 팝업창 활성화. True일 경우 구매한다는 뜻
            itemController.ItemDelete(itemBePurchased.itemName);
            //itemController ItemDelete 메소드에 인자로 itemName을 넘겨 리스트에서 해당 아이템 삭제
            gameManager.playerInventoryItem = itemBePurchased; //player의 인벤토리 아이템 변수에 item 저장
            gameManager.playerMoney -= itemBePurchased.itemPrice; //player의 소지금 차감
        }*/
        else {
            itemController.ItemDelete();
            //itemController ItemDelete 메소드에 인자로 itemName을 넘겨 리스트에서 해당 아이템 삭제
            gameManager.playerInventoryItem = itemBePurchased; //player의 인벤토리 아이템 변수에 item 저장
            gameManager.playerMoney -= itemBePurchased.itemPrice; //player의 소지금 차감
        }
        itemBePurchased = null;
    }

    /***buyExpRun 메소드***/
    public void BuyExpRun(string expName) {
       //반환된 능력치명을 expName 변수에 저장

        if (CheckMoney(itemController.GetPrice(expName))) {//Player의 소지금을 확인해 구매할 수 있는지 판단        
            uiController.checkMoneyPopup.SetActive(true);//구매할 수 없을 경우 구매할 수 없다는 팝업창 활성화
        }
        else {//소지금 확인 후 구매 의사를 묻기 위한 팝업창 활성화. True일 경우 구매
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

    /*** CheckMoney 메소드***/
    private bool CheckMoney(int money) {
        if ((gameManager.playerMoney - money) < 0) {//소지금 확인해 구매할 수 있는지 판단.
            return true;//구매할 수 없을 경우 true 반환
        }
        return false;//구매할 수 있는 경우 false 반환
    }


    /***IsTruePurchase 메소드***/
    private bool IsTruePurchase() {
        uiController.isTruePurchasePopup.SetActive(true); // 구매여부를 묻는 팝업창 
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        return uiController.isTruePurchaseBTN(clickObject.name);
    }
}
