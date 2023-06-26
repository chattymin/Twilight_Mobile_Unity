using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    private UiController UIController;
    private GameManager gameManager = GameManager.instance;


    private void Start() {

        UIController = GameObject.Find("ScriptObject").GetComponent<UiController>();
    }


    public void BoughtExpBTN() {
        string expName = EventSystem.current.currentSelectedGameObject.name;//클릭한 오브젝트의 이름을 expName 변수에 저장함.
        UIController.BoughtExp(expName);
        expName ="";
    }

    public void exitBTN() {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        if (clickObject.name == "checkMoney") {
            UIController.checkMoneyPopup.SetActive(false);
        }
        else if (clickObject.name == "itemDescribe") {
            UIController.itemDescribePopup.SetActive(false);
        }
        
    }

    public void isTruePurchaseBTN() {
        string playerSelect = EventSystem.current.currentSelectedGameObject.name;
        UIController.isTruePurchasePopup.SetActive(false);

        UIController.isTruePurchase(playerSelect);
    }

    public void itemDescribeBTN() {
            UIController.itemDescribePopup.SetActive(true);
    }

    public void BoughtItemBTN() {

        UIController.BoughtItem();
    }
}
