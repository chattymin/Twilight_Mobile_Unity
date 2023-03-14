using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    private UiController UIController;

    private void Start() {

        UIController = GameObject.Find("ScriptObject").GetComponent<UiController>();
    }


    public void BoughtExpBTN() {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject; //최근 클릭한 오브젝트를 반환함
        string expName = clickObject.name;//클릭한 오브젝트의 이름을 expName 변수에 저장함.
        
        UIController.BoughtExp(expName);
    }

    public void exitBTN() {
        UIController.checkMoneyPopup.SetActive(false);
    }

    public void isTruePurchaseBTN() {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        string playerSelect = clickObject.name;
        UIController.isTruePurchasePopup.SetActive(false);

        UIController.isTruePurchase(playerSelect);
    }

    public void BoughtItemBTN() {

        UIController.BoughtItem();
    }
}
