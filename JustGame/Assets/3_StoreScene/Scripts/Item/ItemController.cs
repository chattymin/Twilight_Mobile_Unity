using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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

    private TextMeshProUGUI attackPriceText; //attack 가격
    private TextMeshProUGUI defensePriceText;//defense 가격
    private TextMeshProUGUI recoveryPriceText; //recovery 가격

    void Start() {
        attackPriceText = GameObject.Find("attackPrice").GetComponent<TextMeshProUGUI>();
        defensePriceText = GameObject.Find("defensePrice").GetComponent<TextMeshProUGUI>();
        recoveryPriceText = GameObject.Find("recoveryPrice").GetComponent<TextMeshProUGUI>();
    }

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

    public void uiItemPrice() {
        attackPriceText.text = attackPrice.ToString();
        defensePriceText.text = defensePrice.ToString();
        recoveryPriceText.text = recoveryPrice.ToString();
    }
}