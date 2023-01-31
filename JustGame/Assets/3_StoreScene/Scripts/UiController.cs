using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

/* 
 * UiController : StoreScene UI를 관리하는 스크립트
 */
public class UiController : MonoBehaviour {
    //private Image showImage; //구매할 수 있는 아이템의 이미지
    //private GameObject itemDesc;//아이템 설명
    private TextMeshProUGUI itemPrice; //아이템 가격
    private GameObject buyButton;// 구매버튼
    public Image inventoryItem;//player 인벤토리 아이템
    private TextMeshProUGUI attackPrice; //attack 가격
    private TextMeshProUGUI defensePrice;//defense 가격
    private TextMeshProUGUI recoveryPrice; //recovery 가격
    public GameObject checkMoneyPopup;//소지금 부족으로 구매할 수 없는 경우 뜨는 팝업창
    public GameObject isTruePurchasePopup;//구매 여부를 묻는 팝업창
    private GameManager gameManager = GameManager.instance;
    private ItemController itemController;
    private PlayerController playerController;
    public Item selectedItem;//itemController의 SelectItem 메소드를 통해 선택된 아이템
    TextMeshProUGUI curMoney;
    TextMeshProUGUI attackexp;
    TextMeshProUGUI defenseexp;
    TextMeshProUGUI recoveryexp;
    public string expName;

    private void Start() {
        itemController = GameObject.Find("ScriptObject").GetComponent<ItemController>();
        playerController = GameObject.Find("ScriptObject").GetComponent<PlayerController>();

        //showImage = GameObject.Find("item").GetComponent<Image>();
        itemPrice = GameObject.Find("itemPrice").GetComponent<TextMeshProUGUI>();

        attackPrice = GameObject.Find("attackPrice").GetComponent<TextMeshProUGUI>();
        attackPrice.text = itemController.GetPrice("attack").ToString();

        defensePrice = GameObject.Find("defensePrice").GetComponent<TextMeshProUGUI>();
        defensePrice.text = itemController.GetPrice("defense").ToString();

        recoveryPrice = GameObject.Find("recoveryPrice").GetComponent<TextMeshProUGUI>();
        recoveryPrice.text = itemController.GetPrice("recovery").ToString();

        buyButton = GameObject.Find("buy");

        curMoney = GameObject.Find("curmoney").GetComponent<TextMeshProUGUI>();
        curMoney.text = gameManager.playerMoney.ToString();

        attackexp = GameObject.Find("attackexp").GetComponent<TextMeshProUGUI>();
        attackexp.text = gameManager.playerAttackLV.ToString();

        defenseexp =  GameObject.Find("defenseexp").GetComponent<TextMeshProUGUI>();
        defenseexp.text = gameManager.playerDefenseLV.ToString();

        recoveryexp = GameObject.Find("recoveryexp").GetComponent<TextMeshProUGUI>();
        recoveryexp.text = gameManager.playerRecoveryLV.ToString();

        checkMoneyPopup = GameObject.Find("checkMoneyPopup");
        isTruePurchasePopup = GameObject.Find("checkMoneyPopup");
      
        //itemDesc = GameObject.Find("desc");
        checkMoneyPopup.SetActive(false);//storescene 시작시 팝업 비활성화
        isTruePurchasePopup.SetActive(false);//storescene 시작시 팝업 비활성화
        UiSetting();
    }

     /*** UiSetting 메소드 ***/
    private void UiSetting() {
        GameObject.Find("inventoryitem").SetActive(true);
        if (gameManager.playerInventoryItem != null) {
            GameObject.Find("inventoryitem").SetActive(false);
        }else {
            inventoryItem.sprite = gameManager.playerInventoryItem.itemImage;
        }
        
        selectedItem = itemController.SelectItem(); //구매할 수 있는 아이템을 리스트에서 랜덤으로 선택
        
        GameObject.Find("item").GetComponent<Image>().sprite = selectedItem.itemImage;
        GameObject.Find("desc").GetComponent<TextMeshProUGUI>().text = selectedItem.itemdesc;
        itemPrice.text = selectedItem.itemPrice.ToString();
        // 뽑힌 아이템의 이미지,가격 설명을 보여줌

        buyButton.GetComponent<Button>().interactable = true; //버튼 기능 활성화. storescene로 전환되면 항상 버튼은 활성화됨
    }

    /***BougntItem 메소드***/
    public void BoughtItem() {
        playerController.BuyItem(selectedItem);
        buyButton.GetComponent<Image>().color = Color.gray; // 구매버튼 클릭 시 동작. 구매를 막기 위해 색을 gray로 변경 
        itemPrice.text = ""; // item의 가격을 표시해주는 text를 ""로 변경.    
        inventoryItem.sprite = gameManager.playerInventoryItem.itemImage;
        buyButton.GetComponent<Button>().interactable = false; // 구매할 수 없도록 button 기능 비활성화. 
        UImodifyVariable();
    }

    /***BoughtExp 메소드***/
    public void BoughtExp() {
       GameObject clickObject = EventSystem.current.currentSelectedGameObject; //최근 클릭한 오브젝트를 반환함
       expName = clickObject.name;//클릭한 오브젝트의 이름을 expName 변수에 저장함.
       playerController.BuyExpRun(expName);
       UImodifyVariable();
    }

    public void exitBTN() {
        checkMoneyPopup.SetActive(false);
    }

    public bool isTruePurchaseBTN(string playerSelect) {
        isTruePurchasePopup.SetActive(false);   
        if (playerSelect == "true") {
            return true;
        }else {
            return false; 
        }
    }



    private void UImodifyVariable() {
        curMoney.text = gameManager.playerMoney.ToString();
        attackexp.text = gameManager.playerAttackLV.ToString();
        defenseexp.text = gameManager.playerDefenseLV.ToString();
        recoveryexp.text = gameManager.playerRecoveryLV.ToString();

        attackPrice.text = itemController.GetPrice("attack").ToString();
        defensePrice.text = itemController.GetPrice("defense").ToString();
        recoveryPrice.text = itemController.GetPrice("recovery").ToString();

    }    
}
