using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/*
 * Ŭ���� ���� : �������� �������� ������, ���� ���� ������Ʈ, ���Ž� buyscript�� ����Ǵ� Ŭ����. 
 * �ܺ� ��ũ��Ʈ(buyScript)���� boughtUpdate �޼ҵ带 Ȱ���Ͽ� ���� ���� ������Ʈ��.  
 */

public class ItemManager : MonoBehaviour
{
    public List<Item> AllItemList = new List<Item>(12); //������ ����Ʈ
    public Image showImage; // �������� ���� �������� �����ִ� ����
    public GameObject itemdesc; // ������ ���� ����
    public Item exitItem; //player�� ������ �ִ� ������
    public int indexNumber; // ����Ʈ Ȱ�� ���� index number
     GameObject buy; // buy ��ư ã�� ���� ������Ʈ
    Image buyBtnImg; // ��ư �÷� �����ϱ� ���� ����
    GameObject inventoryItem; //inventoryitem ������Ʈ. player�� �κ��丮 ���¸� ������ 
    public GameObject popup; //�˾�â
    static TextMeshProUGUI itemPrice; //item������ �����ִ� text
    static TextMeshProUGUI attackPrice; //attack up ���� �����ִ� text
    static TextMeshProUGUI defensePrice; //defense up ���� �����ִ� text
    static TextMeshProUGUI recoveryPrice; //recovery up ���� �����ִ� text
    public static int aPrice = 100; // attack price �ʱⰪ 
    public static int dPrice = 100; // defense price �ʱⰪ 
    public static int rPrice = 100; // recovery price �ʱⰪ 

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

    /* changeImage �޼ҵ� 
     * ������ �� �ִ� �������� �������� �̾� �̹����� ������. �����ۿ� ���� ����, ���� ���. 
     * �κ��丮 �̹����� ���� ���� player�� ���� �ִ� �������� ������. 
     * player�� �κ��丮 �� �� �����ۿ� ���� ��ư ��� Ȱ��/��Ȱ��
     */

    public void changeImage()
    {
      
        inventoryItem.GetComponent<Image>().sprite = PlayerSetting.item.itemImage;
        
        
        indexNumber = Random.Range(1, 11); //random�� �̿��� ���� indexnumber�� Ȱ���� itemlist���� ������ ����
        
        //���� player�� �̹� ������ ��ǰ�� ���(PlayerSetting.bought[indexnumber]) ��ư ���� gray�� ����.item���� �κп� sold out�� ����.
        if (PlayerSetting.bought[indexNumber] == true)
        {
            showImage.sprite = PlayerSetting.item.itemImage;
            itemdesc.GetComponent<TextMeshProUGUI>().text = "SOLD OUT";
            buyBtnImg.color = Color.gray;
        }
        else
        {
            //�������� ���� �� ��ư ��� ��Ȱ��ȭ. ��Ʋ�� �� �ٽ� ������ �� ��쿣
            //��ư ����� Ȱ��ȭ�Ǿ���ϱ� ������ ���Ȱ��ȭ.
            buy.GetComponent<Button>().interactable = true;
            exitItem = AllItemList[indexNumber]; //exititem�� ���� �������� ������. -> ���� ���Ҽ��� �ֱ� ������ �ӽ÷� ����.
            showImage.sprite = exitItem.itemImage;
            itemdesc = GameObject.Find("desc"); // itemdesc ������ �����ۿ� ���� �������� ����.
            itemdesc.GetComponent<TextMeshProUGUI>().text = exitItem.itemdesc;
            itemPrice.text = exitItem.itemPrice.ToString(); //item���� text�� item�� �������� ����
        }
    }

    /* boughtUpdate �޼ҵ�
     * ���� ��ư Ŭ�� ��( buyscript�� buyItem �޼ҵ�� �����) bought �迭 true�� ����. 
     * indexNumberȰ���� �ش� �ε�����ȣ ���� ����. 
    */
    public void boughtUpdate()
    {
        buyBtnImg.color = Color.gray; // ���Ź�ư Ŭ�� �� ���Ÿ� ���� ���� ���� gray�� ���� 
        itemPrice.text = ""; // item�� ������ ǥ�����ִ� text�� ""�� ����. 

        PlayerSetting.bought[indexNumber] = true; // indexnumber�� Ȱ���� player�� ���� ���� ������Ʈ. 

        showImage.sprite = AllItemList[11].itemImage; // ������ �� �ִ� �������� �����ִ� �̹����� soldout���� ������. 
        itemdesc.GetComponent<TextMeshProUGUI>().text = AllItemList[11].itemdesc; // ������ soldout���� ����. 
        buy.GetComponent<Button>().interactable = false; // ������ �� ������ button ��� ��Ȱ��ȭ. 
    }


    /*setPrice �޼ҵ�
     * ������ �ɷ�ġ�� �̸��� ���� �ش� �ɷ�ġ�� ���� ������ ������Ʈ��.
     * ���� ��� �ɷ�ġ�� 1���� �ö� ������ 50���� ���. 
     * ��� �ɷ�ġ�� ���۰�(aPrice,dPrice,rPrice)�� 100.
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
     * buyScript�� ���Ź�ư�� ����� ���� �޼ҵ忡�� ����.  
     * �������� ��� player�� �����ݿ��� ������/�ɷ�ġ ����� �����µ� �̶� �� ������/�ɷ�ġ��
     * ������ ��ȯ�ϴ� �޼ҵ�
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
