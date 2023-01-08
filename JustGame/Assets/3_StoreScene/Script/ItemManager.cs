using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/*
 * 클래스 설명 : 랜덤으로 아이템을 보여주고 구매하는 클래스. 
 * start버튼, 구매버튼과 연결됨. 
 * 외부 스크립트(buyScript)에서 boughtUpdate 메소드를 활용하여 구매 정보 업데이트함.  
 */

public class ItemManager : MonoBehaviour
{
    public List<Item> AllItemList = new List<Item>(10);
    public Image showImage;
    public GameObject itemdesc;
    public Item exitItem;
    public int indexNumber;
    
    //public  bool[] bought = new bool[10];
    GameObject buy;
    Image buyBtnImg;
    GameObject inventoryItem;
    public GameObject popup;
    static TextMeshProUGUI itemPrice;
    static TextMeshProUGUI attackPrice;
    static TextMeshProUGUI defensePrice;
    static TextMeshProUGUI recoveryPrice;
    static int aPrice = 100;
    static int dPrice = 100;
    static int rPrice = 100;



    /* start 버튼 클릭시 작동되는 메소드 
     * indexNumber : AllItemList에 저장된 Item 요소 활용 위해 indexnumber 활용. 
     indexNumber은 0~10 중 랜덤으로 숫자 추출. 단, bought 배열을 활용해 이전에 구매했는지 확인.
     구매했으면 while문에 의해 다시 랜덤 숫자 추출. 이를 통해 구매한 아이템 다시 구매 못하도록 함. 
     * exitItem : indexnumber을 이용해 AllItemList 요소를 가져와 저장함. 
     * 
     * showImage : exitItem의 itemImage를 저장하는 변수  itemImage를 showImage의 
     sprite 컴포넌트에 저장함.
     *itemdesc : exitItem 의 itemdesc를 저장함. 
    */

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

    public void changeImage()
    {
        if (PlayerSetting.item == null)
        {
            inventoryItem.SetActive(false);
        }else {
            inventoryItem.GetComponent<Image>().sprite = PlayerSetting.item.itemImage;
        }
        
        indexNumber = Random.Range(0, 10);
        if (PlayerSetting.bought[indexNumber] == true)
        {
            showImage.sprite = PlayerSetting.item.itemImage;
            itemdesc.GetComponent<TextMeshProUGUI>().text = "SOLD OUT";
            buyBtnImg.color = Color.gray;
        }
        else
        {
            buy.GetComponent<Button>().interactable = true;
            exitItem = AllItemList[indexNumber];
            showImage.sprite = exitItem.itemImage;
            itemdesc = GameObject.Find("desc");
            itemdesc.GetComponent<TextMeshProUGUI>().text = exitItem.itemdesc;
            itemPrice.text = exitItem.itemPrice.ToString();
        }
    }

    /* 구매 버튼 클릭 시 bought 배열 true로 변경. 
     * indexNumber활용해 해당 인덱스번호 내용 수정. 
    */
    public void boughtUpdate()
    {
        buyBtnImg.color = Color.gray;
        itemPrice.text = "";
        inventoryItem.SetActive(true);

        PlayerSetting.bought[indexNumber] = true;

        showImage.sprite = AllItemList[10].itemImage;
        itemdesc.GetComponent<TextMeshProUGUI>().text = AllItemList[10].itemdesc;
        buy.GetComponent<Button>().interactable = false;
    }

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
