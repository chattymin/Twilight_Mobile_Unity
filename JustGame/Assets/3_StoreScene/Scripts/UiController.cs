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
    private RectTransform rect;

    private GameObject buyButton;// 구매버튼

    private TextMeshProUGUI attackPrice; //attack 가격
    private TextMeshProUGUI defensePrice;//defense 가격
    private TextMeshProUGUI recoveryPrice; //recovery 가격
    
    public GameObject checkMoneyPopup;//소지금 부족으로 구매할 수 없는 경우 뜨는 팝업창
    public GameObject isTruePurchasePopup;//구매 여부를 묻는 팝업창
    private Transform itemDescribePopup;


    public Item selectedItem;//itemController의 SelectItem 메소드를 통해 선택된 아이템
    TextMeshProUGUI curMoney;
    TextMeshProUGUI attackexp;
    TextMeshProUGUI defenseexp;
    TextMeshProUGUI recoveryexp;
    TextMeshProUGUI curMoneyText;
    private string expName;
    private string playerSelect;
    public Animation animation;
    

    private void Start() {
       
        itemController = GameObject.Find("ScriptObject").GetComponent<ItemController>();
        playerController = GameObject.Find("ScriptObject").GetComponent<PlayerController>();

        itemPrice = GameObject.Find("itemPrice").GetComponent<TextMeshProUGUI>();
        itemDesc = GameObject.Find("desc").GetComponent<TextMeshProUGUI>();
        itemImage = GameObject.Find("item").GetComponent<Image>();
        rect = (RectTransform)itemImage.transform;

        attackPrice = GameObject.Find("attackPrice").GetComponent<TextMeshProUGUI>();
        defensePrice = GameObject.Find("defensePrice").GetComponent<TextMeshProUGUI>();
        recoveryPrice = GameObject.Find("recoveryPrice").GetComponent<TextMeshProUGUI>();

        buyButton = GameObject.Find("buy");

        curMoney = GameObject.Find("curmoney").GetComponent<TextMeshProUGUI>();
        attackexp = GameObject.Find("attackexp").GetComponent<TextMeshProUGUI>();
        defenseexp =  GameObject.Find("defenseexp").GetComponent<TextMeshProUGUI>();
        recoveryexp = GameObject.Find("recoveryexp").GetComponent<TextMeshProUGUI>();
        curMoneyText = GameObject.Find("curmoneyText").GetComponent<TextMeshProUGUI>();

        checkMoneyPopup = GameObject.Find("checkMoneyPopup");
        isTruePurchasePopup = GameObject.Find("isTruePurchasePopup");
        itemDescribePopup = GameObject.Find("Canvas").transform.Find("itemDescribePopup");

        GameObject.Find("inventoryitem").SetActive(false);
        checkMoneyPopup.SetActive(false);//storescene 시작시 팝업 비활성화
        isTruePurchasePopup.SetActive(false);//storescene 시작시 팝업 비활성화
        curMoneyText.enabled = false;
        expName = "not selected";
        playerSelect = "false";
        UiSetting();
    }

     /*** UiSetting 메소드 ***/
    private void UiSetting() {

        if (gameManager.playerInventoryItem.itemName.Equals("")) {
            UImodifyInventory();
        }

        selectedItem = itemController.SelectItem(); //구매할 수 있는 아이템을 리스트에서 랜덤으로 선택

        itemImage.sprite = selectedItem.itemImage;
        rect.sizeDelta = new Vector2(250, 240);
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
            curMoneyText.text = "-" + selectedItem.itemPrice.ToString();
            playerController.BuyItem(selectedItem);
            curMoneyText.enabled = true;
            StartCoroutine(FadeMoneyText());
            StartCoroutine(CountingMoney());
            itemPrice.text = ""; // item의 가격을 표시해주는 text를 ""로
            itemDesc.text = "";

            itemImage.sprite = Resources.Load<Sprite>("Images/Icons/SoldOut");
            RectTransform rect = (RectTransform)itemImage.transform;
            rect.sizeDelta = new Vector2(500, 280);
            rect.anchoredPosition = new Vector3(0,7);

            buyButton.GetComponent<Image>().color = Color.gray; // 구매버튼 클릭 시 동작. 구매를 막기 위해 색을 gray로 변경 
            buyButton.GetComponent<Button>().interactable = false; // 구매할 수 없도록 button 기능 비활성화. 
            
            selectedItem = null;
            UImodifyInventory();
        }
        else {
            curMoneyText.text = "-" + itemController.GetPrice(expName).ToString();
            playerController.BuyExpRun(expName);
            curMoneyText.enabled = true;
            StartCoroutine(FadeMoneyText());
            StartCoroutine(CountingMoney());
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
 
        itemDescribePopup.transform.Find("playerItemName").GetComponent<TextMeshProUGUI>().text = gameManager.playerInventoryItem.itemName;
        itemDescribePopup.transform.Find("describeSection").transform.Find("playerItemDescribe").GetComponent<TextMeshProUGUI>().text = gameManager.playerInventoryItem.itemdesc;
    }

    IEnumerator FadeMoneyText() {

        curMoneyText.color = new Color(curMoneyText.color.r, curMoneyText.color.g, curMoneyText.color.b, 1);
        RectTransform rect2 = (RectTransform)curMoneyText.transform;
        rect2.anchoredPosition = new Vector3(100, 124);
        Vector3 dir = new Vector3(0, 30f, 0);

        while (curMoneyText.color.a >=0.0f) {
            float colorA = curMoneyText.color.a - 0.005f;
            curMoneyText.color = new Color(curMoneyText.color.r, curMoneyText.color.g, curMoneyText.color.b, colorA);
            rect2.transform.Translate(dir*0.03f);
            yield return null;
        }
    }

    IEnumerator CountingMoney() {
        
        float max = gameManager.playerMoney - int.Parse(curMoneyText.text);

        while (max >= gameManager.playerMoney) {
            if ((-int.Parse(curMoneyText.text)) < 10) {
                max -= 0.05f;
            }
            else if ((-int.Parse(curMoneyText.text)) < 200) {
                max -= 1.0f;
            }
            else if ((-int.Parse(curMoneyText.text)) < 400) {
                max -= 2.0f;
            }
            else {
                max -= 10.0f;
            }      
            curMoney.text = ((int)max).ToString();
            yield return null;
        }
    }
}
