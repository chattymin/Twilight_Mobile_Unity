using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

/*
 * PlayerController : player의 동작 제어 스크립트
 */
public class PlayerController : MonoBehaviour{
    private GameManager gameManager = GameManager.instance;
    private ItemController itemController;
    private TextMeshProUGUI curMoney;
    private TextMeshProUGUI attackexp;
    private TextMeshProUGUI defenseexp;
    private TextMeshProUGUI recoveryexp;
    private TextMeshProUGUI curMoneyText;
    private TextMeshProUGUI playerCurrentHP;
    private Slider HPslider;

    private Transform itemDescribePopup;

    void Start() {

        itemController = GameObject.Find("ScriptObject").GetComponent<ItemController>();
        curMoney = GameObject.Find("curmoney").GetComponent<TextMeshProUGUI>();
        attackexp = GameObject.Find("attackexp").GetComponent<TextMeshProUGUI>();
        defenseexp = GameObject.Find("defenseexp").GetComponent<TextMeshProUGUI>();
        recoveryexp = GameObject.Find("recoveryexp").GetComponent<TextMeshProUGUI>();
        curMoneyText = GameObject.Find("curmoneyText").GetComponent<TextMeshProUGUI>();
        playerCurrentHP = GameObject.Find("playerCurrentHP").GetComponent<TextMeshProUGUI>();
        HPslider = GameObject.Find("Slider").GetComponent<Slider>();
        itemDescribePopup = GameObject.Find("Canvas").transform.Find("itemDescribePopup");

        GameObject.Find("ScriptObject").GetComponent<UiController>().UiSetting();
    }

    /***buyItem 메소드***/
    public void BuyItem(Item itemBePurchased) {

        gameManager.playerInventoryItem = itemBePurchased; //player의 인벤토리 아이템 변수에 item 저장
        gameManager.playerMoney -= itemBePurchased.itemPrice; //player의 소지금 차감

        useItem(itemBePurchased);
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

    private void useItem(Item itemBePurchased) {

        /*
         * itemCode = 1000~1004 : player 관련  1005~1009 : enemy 관련
         */
        switch (itemBePurchased.itemType) {

            case Item.Type.playerExp:
                    gameManager.playerAttackLV += int.Parse(itemBePurchased.itemexp);
                    break;
            case Item.Type.playerHP:
                    gameManager.playerCurrentHP += int.Parse(itemBePurchased.itemexp);
                    //MAXHP도 증가시켜야함.
                    break;
            case Item.Type.enemyExp:
                    gameManager.enemyAttackLV -= int.Parse(itemBePurchased.itemexp);
                    break;
            case Item.Type.enemyHP:
                    gameManager.enemyCurrentHP -= int.Parse(itemBePurchased.itemexp);
                    gameManager.enemyMaxHP-= int.Parse(itemBePurchased.itemexp);
                    break;
        }
    }

    public void UImodifyVariable() {

        curMoney.text = gameManager.playerMoney.ToString();
        attackexp.text = gameManager.playerAttackLV.ToString();
        defenseexp.text = gameManager.playerDefenseLV.ToString();
        recoveryexp.text = gameManager.playerRecoveryLV.ToString();
        int hp = gameManager.playerCurrentHP;
        HPslider.value = (float)hp / 100;
        playerCurrentHP.text = hp.ToString() + "/100";
        //player info 표시
    }

    public void UImodifyInventory() {
        GameObject.Find("inventory").transform.Find("inventoryitem").gameObject.SetActive(true);
        GameObject.Find("inventoryitem").GetComponent<Image>().sprite = gameManager.playerInventoryItem.itemImage;

        itemDescribePopup.transform.Find("playerItemName").GetComponent<TextMeshProUGUI>().text = gameManager.playerInventoryItem.itemName;
        itemDescribePopup.transform.Find("describeSection").transform.Find("playerItemDescribe").GetComponent<TextMeshProUGUI>().text = gameManager.playerInventoryItem.itemdesc;
    }
}



