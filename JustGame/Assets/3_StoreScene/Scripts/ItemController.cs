using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ItemController :Item 관리하는 스크립트
 */
public class ItemController : MonoBehaviour {
    private const int EXP_PRICE = 100;//능력치 가격 기본값
    private GameManager gameManager = GameManager.instance;
    private int indexNumber;

    private int attackPrice = EXP_PRICE; // attack price  
    private int defensePrice = EXP_PRICE; // defense price 
    private int recoveryPrice = EXP_PRICE; // recovery price

   
    /***GetPrice 메소드***/
    public int GetPrice(string expName) {
        switch (expName) {//능력치명에 따라 가격 반환
            case "attack":
                return attackPrice;
            case "defense":
                return defensePrice;
            case "recovery":
                return recoveryPrice;
        }
        return -1;
    }

    public void SetPrice(string expName) {
        switch (expName) {//능력치명에 따라 능력치 가격 업데이트
            case "attack":
                attackPrice += gameManager.playerAttackLV * 50;
                break;
            case "defense":
                defensePrice += gameManager.playerDefenseLV * 50;
                break;
            case "recovery":
                recoveryPrice += gameManager.playerRecoveryLV * 50;
                break;
            default:
                break;
        }
    }

    /***SelectItem 메소드***/
    public Item SelectItem() {
        indexNumber = Random.Range(0, 10);//리스트 길이를 이용해 랜덤으로 인덱스 번호 추출
        return gameManager.ShopItemList[indexNumber];//랜덤으로 아이템 반환
    }

    /***ItemDelete 메소드***/
    public void ItemDelete() {
        gameManager.ShopItemList.RemoveAt(indexNumber);
    }

    /***SetPrice 메소드***/
    public bool CheckMoney(int money) {
        if ((gameManager.playerMoney - money) < 0) {
            return true;
        }
        return false;
        //구매할 수 있는 경우 false 반환
    }

    public bool isUse(Item item) {
        return item.useValue;
    }

    public void useItem(string itemName) {

        switch (itemName) {

            case "1000":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1001":
                Debug.Log("두번째 아이템 사용");
                break;
            case "1002":
                Debug.Log("세번째 아이템 사용");
                break;
            case "1003":
                Debug.Log("네번째 아이템 사용");
                break;
            case "1004":
                Debug.Log("다섯번째 아이템 사용");
                break;
            case "1005":
                Debug.Log("여섯번째 아이템 사용");
                break;
            case "1006":
                Debug.Log("일곱번째 아이템 사용");
                break;
            case "1007":
                Debug.Log("여덟번째 아이템 사용");
                break;
            case "1008":
                Debug.Log("아홉번째 아이템 사용");
                break;
            case "1009":
                Debug.Log("열번째 아이템 사용");
                break;
            case "1010":
                Debug.Log("열한번째 아이템 사용");
                break;
            case "1011":
                Debug.Log("열두번째 아이템 사용");
                break;
            case "1012":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1013":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1014":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1015":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1016":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1017":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1018":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1019":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1020":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1021":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1022":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1023":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1024":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1025":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1026":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1027":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1028":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1029":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1030":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1031":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1032":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1033":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1034":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1035":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1036":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1037":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1038":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1039":
                Debug.Log("첫번째 아이템 사용");
                break;
            case "1040":
                Debug.Log("첫번째 아이템 사용");
                break;
        }
    }

    public void useItem2( string user, Item item) {
        item.useValue = false;

        switch (item.itemType) {

            case Item.Type.exp:
                if (user == "player") {
                    // gameManager.playerAttackLV += item.itemexp;
                }
                else if (user == "enemy") {
                    //gameManager.enemyAttackLV -= item.itemexp;
                }
                break;

            case Item.Type.money:
                //gameManager.playerMoney += item.itemexp;
                break;
            case Item.Type.heart:
                if (user == "player") {
                    //gameManager.playerCurrentHP += item.itemexp;
                }
                else if (user == "enemy") {
                    //gameManager.enemyCurrentHP -= item.itemexp
                }
                break;
        }
    }
}