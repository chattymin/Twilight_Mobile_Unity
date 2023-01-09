using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/*
 * 클래스 설명 : 랜덤으로 아이템을 보여줌, 가격 정보 업데이트, 구매시 buyscript와 연결되는 클래스. 
 * 외부 스크립트(buyScript)에서 boughtUpdate 메소드를 활용하여 구매 정보 업데이트함.  
 */

public class ItemManager : MonoBehaviour
{
    public List<Item> AllItemList = new List<Item>(12); //아이템 리스트
    public Image showImage; // 랜덤으로 뽑힌 아이템을 보여주는 변수
    public GameObject itemdesc; // 아이템 설명 변수
    public Item exitItem; //player가 가질수 있는 아이템
    public int indexNumber; // 리스트 활용 위한 index number
     GameObject buy; // buy 버튼 찾기 위한 오브젝트
    Image buyBtnImg; // 버튼 컬러 변경하기 위한 변수
    GameObject inventoryItem; //inventoryitem 오브젝트. player의 인벤토리 상태를 보여줌 
    public GameObject popup; //팝업창
    static TextMeshProUGUI itemPrice; //item가격을 보여주는 text
    static TextMeshProUGUI attackPrice; //attack up 가격 보여주는 text
    static TextMeshProUGUI defensePrice; //defense up 가격 보여주는 text
    static TextMeshProUGUI recoveryPrice; //recovery up 가격 보여주는 text
    public static int aPrice = 100; // attack price 초기값 
    public static int dPrice = 100; // defense price 초기값 
    public static int rPrice = 100; // recovery price 초기값 

    private void Start()
    {
        PlayerSetting.bought[0] = true;
        itemPrice = GameObject.Find("itemPrice").GetComponent<TextMeshProUGUI>();

        attackPrice = GameObject.Find("attackPrice").GetComponent<TextMeshProUGUI>();
        attackPrice.text = aPrice.ToString();

        defensePrice = GameObject.Find("defensePrice").GetComponent<TextMeshProUGUI>();
        defensePrice.text = dPrice.ToString();

        recoveryPrice = GameObject.Find("recoveryPrice").GetComponent<TextMeshProUGUI>();
        recoveryPrice.text = rPrice.ToString();

        buy = GameObject.Find("buy");
        buyBtnImg = buy.GetComponent<Image>();
        popup = GameObject.Find("popup");

        inventoryItem = GameObject.Find("inventoryitem");
        itemdesc = GameObject.Find("desc");
        popup.SetActive(false);
        changeImage();
    }

    /* changeImage 메소드 
     * 구매할 수 있는 아이템을 랜덤으로 뽑아 이미지로 보여줌. 아이템에 따른 설명, 가격 띄움. 
     * 인벤토리 이미지를 통해 현재 player가 갖고 있는 아이템을 보여줌. 
     * player의 인벤토리 속 들어간 아이템에 따른 버튼 기능 활성/비활성
     */

    public void changeImage()
    {
      
        inventoryItem.GetComponent<Image>().sprite = PlayerSetting.item.itemImage;
        
        
        indexNumber = Random.Range(1, 11); //random을 이용해 나온 indexnumber을 활용해 itemlist에서 아이템 뽑음
        
        //만약 player가 이미 구매한 상품일 경우(PlayerSetting.bought[indexnumber]) 버튼 색을 gray로 변경.item설명 부분에 sold out로 변경.
        if (PlayerSetting.bought[indexNumber] == true)
        {
            showImage.sprite = PlayerSetting.item.itemImage;
            itemdesc.GetComponent<TextMeshProUGUI>().text = "SOLD OUT";
            buyBtnImg.color = Color.gray;
        }
        else
        {
            //상점에서 구매 후 버튼 기능 비활성화. 배틀씬 후 다시 상점에 올 경우엔
            //버튼 기능이 활성화되어야하기 때문에 기능활성화.
            buy.GetComponent<Button>().interactable = true;
            exitItem = AllItemList[indexNumber]; //exititem에 뽑힌 아이템을 저장함. -> 구매 안할수도 있기 때문에 임시로 저장.
            showImage.sprite = exitItem.itemImage;
            itemdesc = GameObject.Find("desc"); // itemdesc 내용을 아이템에 대한 설명으로 변경.
            itemdesc.GetComponent<TextMeshProUGUI>().text = exitItem.itemdesc;
            itemPrice.text = exitItem.itemPrice.ToString(); //item가격 text를 item의 가격으로 변경
        }
    }

    /* boughtUpdate 메소드
     * 구매 버튼 클릭 시( buyscript의 buyItem 메소드와 연결됨) bought 배열 true로 변경. 
     * indexNumber활용해 해당 인덱스번호 내용 수정. 
    */
    public void boughtUpdate()
    {
        buyBtnImg.color = Color.gray; // 구매버튼 클릭 시 구매를 막기 위해 색을 gray로 변경 
        itemPrice.text = ""; // item의 가격을 표시해주는 text를 ""로 변경. 

        PlayerSetting.bought[indexNumber] = true; // indexnumber을 활용해 player의 구매 정보 업데이트. 

        showImage.sprite = AllItemList[11].itemImage; // 구매할 수 있는 아이템을 보여주는 이미지를 soldout으로 변경함. 
        itemdesc.GetComponent<TextMeshProUGUI>().text = AllItemList[11].itemdesc; // 문구를 soldout으로 변경. 
        buy.GetComponent<Button>().interactable = false; // 구매할 수 없도록 button 기능 비활성화. 
    }


    /*setPrice 메소드
     * 구매한 능력치의 이름에 따라 해당 능력치의 가격 정보를 업데이트함.
     * 현재 모든 능력치가 1레벨 올라갈 때마다 50코인 상승. 
     * 모든 능력치의 시작값(aPrice,dPrice,rPrice)은 100.
     */
    public void setPrice(string expName) {

        switch (expName)
        {
            case "attack":
                aPrice += 50;
                attackPrice.text = aPrice.ToString();
                break;
            case "defense":
                dPrice += 50;
                defensePrice.text = dPrice.ToString();
                break;
            case "recovery":
                rPrice += 50;
                recoveryPrice.text = rPrice.ToString();
                break;
        }        
    }

    /*getPrice
     * buyScript의 구매버튼과 연결된 구매 메소드에서 사용됨.  
     * 구매했을 경우 player의 소지금에서 아이템/능력치 비용이 빠지는데 이때 각 아이템/능력치의
     * 가격을 반환하는 메소드
     */
    public int getPrice(string expName) {
        int returnPrice=0;

        switch (expName)
        {
            case "attack":
                returnPrice=aPrice;
                break;
            case "defense":
                returnPrice = dPrice;
                break;
            case "recovery":
                returnPrice = rPrice;
                break;
        }
        return returnPrice;
    }
}
