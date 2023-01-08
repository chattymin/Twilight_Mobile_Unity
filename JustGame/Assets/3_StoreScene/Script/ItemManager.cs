using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/*
 * Ŭ���� ���� : �������� �������� �����ְ� �����ϴ� Ŭ����. 
 * start��ư, ���Ź�ư�� �����. 
 * �ܺ� ��ũ��Ʈ(buyScript)���� boughtUpdate �޼ҵ带 Ȱ���Ͽ� ���� ���� ������Ʈ��.  
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



    /* start ��ư Ŭ���� �۵��Ǵ� �޼ҵ� 
     * indexNumber : AllItemList�� ����� Item ��� Ȱ�� ���� indexnumber Ȱ��. 
     indexNumber�� 0~10 �� �������� ���� ����. ��, bought �迭�� Ȱ���� ������ �����ߴ��� Ȯ��.
     ���������� while���� ���� �ٽ� ���� ���� ����. �̸� ���� ������ ������ �ٽ� ���� ���ϵ��� ��. 
     * exitItem : indexnumber�� �̿��� AllItemList ��Ҹ� ������ ������. 
     * 
     * showImage : exitItem�� itemImage�� �����ϴ� ����  itemImage�� showImage�� 
     sprite ������Ʈ�� ������.
     *itemdesc : exitItem �� itemdesc�� ������. 
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

    /* ���� ��ư Ŭ�� �� bought �迭 true�� ����. 
     * indexNumberȰ���� �ش� �ε�����ȣ ���� ����. 
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
