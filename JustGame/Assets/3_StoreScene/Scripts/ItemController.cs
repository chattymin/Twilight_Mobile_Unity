using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ItemController :Item 관리하는 스크립트
 */
public class ItemController {
    private const int EXP_PRICE= 100;//능력치 가격 기본값
    private GameManager gameManager = GameManager.instance;
    private List<Item> shopList;//아이템 리스트

    private int attackPrice = EXP_PRICE; // attack price  
    private int defensePrice = EXP_PRICE; // defense price 
    private int recoveryPrice = EXP_PRICE; // recovery price

    public void Start() {
        gameManager = GameManager.instance;
        shopList = gameManager.ShopItemList;
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

    /***SelectItem 메소드***/
    public Item SelectItem() {
        int indexNumber = Random.Range(0, shopList.Count);//리스트 길이를 이용해 랜덤으로 인덱스 번호 추출
        return shopList[indexNumber];//랜덤으로 아이템 반환
    }

    /***ItemDelete 메소드***/
    public void ItemDelete(string itemName) {
        for (int i = 0; i < shopList.Count; i++) {//for문 이용해 아이템 삭제
            if (shopList[i].itemName.Equals(itemName)) {//만약 itemName이 일치할 경우
                shopList.RemoveAt(i);// 해당 아이템 삭제
            }
            else {//일치하지 않을 경우 Log 기록
                Debug.Log("ERROR \n 해당 아이템은 리스트에 존재하지 않습니다. ");
            }
        }
    }

    /***SetPrice 메소드***/
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
}
