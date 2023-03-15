using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

/* 
 * UiController : StoreScene UI를 관리하는 스크립트
 */
public class UiController : MonoBehaviour
    {

    private GameManager gameManager = GameManager.instance;
    private ItemController itemController;
    private PlayerController playerController;
    private ParticleController ParticleController;
    private CoroutineController coroutineController;

    private TextMeshProUGUI itemPrice; //아이템 가격
    private TextMeshProUGUI itemDesc;
    private Image itemImage;
    private RectTransform rect;

    private GameObject buyButton;// 구매버튼
    
    public GameObject checkMoneyPopup;//소지금 부족으로 구매할 수 없는 경우 뜨는 팝업창
    public GameObject isTruePurchasePopup;//구매 여부를 묻는 팝업창


    public Item selectedItem;//itemController의 SelectItem 메소드를 통해 선택된 아이템
    TextMeshProUGUI curMoney;
    TextMeshProUGUI curMoneyText;
    private string expName;

    //private TextMeshProUGUI attackPrice; //attack 가격
    // private TextMeshProUGUI defensePrice;//defense 가격
    //private TextMeshProUGUI recoveryPrice; //recovery 가격
    //TextMeshProUGUI attackexp;
    // TextMeshProUGUI defenseexp;
    //TextMeshProUGUI recoveryexp;
    // private Transform itemDescribePopup;

    private void Start() {
        itemController = GameObject.Find("ScriptObject").GetComponent<ItemController>();
        playerController = GameObject.Find("ScriptObject").GetComponent<PlayerController>();
        ParticleController = GameObject.Find("ScriptObject").GetComponent<ParticleController>();
        coroutineController = GameObject.Find("ScriptObject").GetComponent<CoroutineController>();

        itemPrice = GameObject.Find("itemPrice").GetComponent<TextMeshProUGUI>();
        itemDesc = GameObject.Find("desc").GetComponent<TextMeshProUGUI>();
        itemImage = GameObject.Find("item").GetComponent<Image>();
        rect = (RectTransform)itemImage.transform;

        buyButton = GameObject.Find("buy");

        //curMoney = GameObject.Find("curmoney").GetComponent<TextMeshProUGUI>();
        curMoneyText = GameObject.Find("curmoneyText").GetComponent<TextMeshProUGUI>();

        checkMoneyPopup = GameObject.Find("checkMoneyPopup");
        isTruePurchasePopup = GameObject.Find("isTruePurchasePopup");

        GameObject.Find("inventoryitem").SetActive(false);
        checkMoneyPopup.SetActive(false);//storescene 시작시 팝업 비활성화
        isTruePurchasePopup.SetActive(false);//storescene 시작시 팝업 비활성화
        curMoneyText.enabled = false;
        expName = "not selected";
    
    }

    /*** UiSetting 메소드 ***/
    public void UiSetting() {

        if (!gameManager.playerInventoryItem.itemName.Equals("")) {
            playerController.UImodifyInventory();
        }

        selectedItem = itemController.SelectItem(); //구매할 수 있는 아이템을 리스트에서 랜덤으로 선택

        itemImage.sprite = selectedItem.itemImage;
        rect.sizeDelta = new Vector2(250, 240);
        itemDesc.text = selectedItem.itemdesc;
        itemPrice.text = selectedItem.itemPrice.ToString();

        playerController.UImodifyVariable();
        itemController.uiItemPrice();

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
    public void BoughtExp(string expBTNName) {
        expName = expBTNName;

        if (itemController.CheckMoney(itemController.GetPrice(expName))) {//Player의 소지금을 확인해 구매할 수 있는지 판단        
            checkMoneyPopup.SetActive(true); //구매할 수 없을 경우 구매할 수 없다는 팝업창 활성화
        }
        else {
            isTruePurchasePopup.SetActive(true);
        }
    }

    public void isTruePurchase(string playerSelect) {

        if (playerSelect.Equals("false")) {
            Debug.Log("아무것도 구매 안함 상태 안바뀜. ");
        }
        else if (playerSelect.Equals("true") && expName.Equals("not selected")) {
            curMoneyText.text = "-" + selectedItem.itemPrice.ToString();
            curMoneyText.enabled = true;
            
            playerController.BuyItem(selectedItem);
            ParticleController.particleObject1.Play();
            StartCoroutine(coroutineController.FadeMoneyText(curMoneyText));
            StartCoroutine(coroutineController.CountingMoney(curMoneyText,curMoney));
            
            itemPrice.text = ""; // item의 가격을 표시해주는 text를 ""로
            itemDesc.text = "";
            
            itemImage.sprite = Resources.Load<Sprite>("Images/Icons/SoldOut");
            RectTransform rect = (RectTransform)itemImage.transform;
            rect.sizeDelta = new Vector2(500, 280);
            rect.anchoredPosition = new Vector3(0,7);

            buyButton.GetComponent<Image>().color = Color.gray; // 구매버튼 클릭 시 동작. 구매를 막기 위해 색을 gray로 변경 
            buyButton.GetComponent<Button>().interactable = false; // 구매할 수 없도록 button 기능 비활성화. 
            
            selectedItem = null;
            playerController.UImodifyInventory();
        }
        else {
            curMoneyText.text = "-" + itemController.GetPrice(expName).ToString();
            curMoneyText.enabled = true;

            playerController.BuyExpRun(expName);
            ParticleController.particleON(expName);
            StartCoroutine(coroutineController.FadeMoneyText(curMoneyText));
            StartCoroutine(coroutineController.CountingMoney(curMoneyText, curMoney));
            StartCoroutine(coroutineController.FadeIcon(GameObject.Find(expName + "Icon").GetComponent<Image>()));
        }
        playerController.UImodifyVariable();
        itemController.uiItemPrice();

        expName = "not selected";
    }
}
