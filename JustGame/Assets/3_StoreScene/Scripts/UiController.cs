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

    private GameManager gameManager = GameManager.instance;
    private ItemController itemController;
    private PlayerController playerController;

    private TextMeshProUGUI itemPrice; //아이템 가격
    private TextMeshProUGUI itemDesc;
    private Image itemImage;

    private GameObject buyButton;// 구매버튼

    private TextMeshProUGUI attackPrice; //attack 가격
    private TextMeshProUGUI defensePrice;//defense 가격
    private TextMeshProUGUI recoveryPrice; //recovery 가격
    
    public GameObject checkMoneyPopup;//소지금 부족으로 구매할 수 없는 경우 뜨는 팝업창
    public GameObject isTruePurchasePopup;//구매 여부를 묻는 팝업창
    
    
    public Item selectedItem;//itemController의 SelectItem 메소드를 통해 선택된 아이템
    TextMeshProUGUI curMoney;
    TextMeshProUGUI attackexp;
    TextMeshProUGUI defenseexp;
    TextMeshProUGUI recoveryexp;
    private string expName;
    private string playerSelect;

    private void Start() {
        itemController = GameObject.Find("ScriptObject").GetComponent<ItemController>();
        playerController = GameObject.Find("ScriptObject").GetComponent<PlayerController>();

        itemPrice = GameObject.Find("itemPrice").GetComponent<TextMeshProUGUI>();
        itemDesc = GameObject.Find("desc").GetComponent<TextMeshProUGUI>();
        itemImage = GameObject.Find("item").GetComponent<Image>();

        attackPrice = GameObject.Find("attackPrice").GetComponent<TextMeshProUGUI>();
        defensePrice = GameObject.Find("defensePrice").GetComponent<TextMeshProUGUI>();
        recoveryPrice = GameObject.Find("recoveryPrice").GetComponent<TextMeshProUGUI>();

        buyButton = GameObject.Find("buy");

        curMoney = GameObject.Find("curmoney").GetComponent<TextMeshProUGUI>();
        attackexp = GameObject.Find("attackexp").GetComponent<TextMeshProUGUI>();
        defenseexp =  GameObject.Find("defenseexp").GetComponent<TextMeshProUGUI>();
        recoveryexp = GameObject.Find("recoveryexp").GetComponent<TextMeshProUGUI>();

        checkMoneyPopup = GameObject.Find("checkMoneyPopup");
        isTruePurchasePopup = GameObject.Find("isTruePurchasePopup");

        GameObject.Find("inventoryitem").SetActive(false);
        checkMoneyPopup.SetActive(false);//storescene 시작시 팝업 비활성화
        isTruePurchasePopup.SetActive(false);//storescene 시작시 팝업 비활성화
        expName = "not selected";
        playerSelect = "false";
        UiSetting();
    }

     /*** UiSetting 메소드 ***/
    private void UiSetting() {

        if (gameManager.playerInventoryItem.itemName.Equals("Item")) {
            UImodifyInventory();
        }
     
        selectedItem = itemController.SelectItem(); //구매할 수 있는 아이템을 리스트에서 랜덤으로 선택

        itemImage.sprite = selectedItem.itemImage;
        itemDesc.text = selectedItem.itemdesc;
        itemPrice.text = selectedItem.itemPrice.ToString();
        UImodifyVariable();

        buyButton.GetComponent<Button>().interactable = true; //버튼 기능 활성화. storescene로 전환되면 항상 버튼은 활성화됨      
    }

    /***BougntItem 메소드***/
    public void BoughtItem() {

        if (itemController.CheckMoney(selectedItem.itemPrice)) {//Player의 소지금을 확인해 구매할 수 있는지 판단        
            checkMoneyPopup.SetActive(true);//구매할 수 없을 경우 구매할 수 없다는 팝업창 활성화
        }
        else {
            isTruePurchasePopup.SetActive(true);
        }
    }

    /***BoughtExp 메소드***/
    public void BoughtExp() {
       GameObject clickObject = EventSystem.current.currentSelectedGameObject; //최근 클릭한 오브젝트를 반환함
       expName = clickObject.name;//클릭한 오브젝트의 이름을 expName 변수에 저장함.

        if (itemController.CheckMoney(itemController.GetPrice(expName))) {//Player의 소지금을 확인해 구매할 수 있는지 판단        
            checkMoneyPopup.SetActive(true); //구매할 수 없을 경우 구매할 수 없다는 팝업창 활성화
        }
        else {
            isTruePurchasePopup.SetActive(true);
        }
    }
  
    public void exitBTN() {
        checkMoneyPopup.SetActive(false);
    }

    public void isTruePurchaseBTN() {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        playerSelect = clickObject.name;
        isTruePurchasePopup.SetActive(false);

        if (playerSelect.Equals("false")) {
            Debug.Log("아무것도 구매 안함 상태 안바뀜. ");
        }
        else if (playerSelect.Equals("true") && expName.Equals("not selected")) {
            playerController.BuyItem(selectedItem);
            
            buyButton.GetComponent<Image>().color = Color.gray; // 구매버튼 클릭 시 동작. 구매를 막기 위해 색을 gray로 변경 
            itemPrice.text = ""; // item의 가격을 표시해주는 text를 ""로 
            itemImage.sprite = Resources.Load<Sprite>("Images/Icons/SoldOut");
            itemDesc.text = "";

            buyButton.GetComponent<Button>().interactable = false; // 구매할 수 없도록 button 기능 비활성화. 
            
            selectedItem = null;
            UImodifyInventory();
        }
        else {
            playerController.BuyExpRun(expName);
        }
        UImodifyVariable();
    }

    private void UImodifyVariable() {
        curMoney.text = gameManager.playerMoney.ToString();
        attackexp.text = gameManager.playerAttackLV.ToString();
        defenseexp.text = gameManager.playerDefenseLV.ToString();
        recoveryexp.text = gameManager.playerRecoveryLV.ToString();
        //player info 표시

        attackPrice.text = itemController.GetPrice("attack").ToString();
        defensePrice.text = itemController.GetPrice("defense").ToString();
        recoveryPrice.text = itemController.GetPrice("recovery").ToString();

        expName = "not selected";
        //exp 아이템 가격 표시
    }

    private void UImodifyInventory() {
        GameObject.Find("inventory").transform.Find("inventoryitem").gameObject.SetActive(true);
        GameObject.Find("inventoryitem").GetComponent<Image>().sprite = gameManager.playerInventoryItem.itemImage;
    }   
}
