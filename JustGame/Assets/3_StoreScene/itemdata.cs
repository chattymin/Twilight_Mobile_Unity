using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Item
{
    public Item(string type, string itemName, string itemexp, string itemdesc, string itemPrice,string itemImagestr)
    {
        this.type = type;
        this.itemName = itemName;
        this.itemexp = itemexp;
        this.itemdesc = itemdesc;
        this.itemPrice = itemPrice;
        this.itemImage = Resources.Load<Sprite>(""+itemImagestr+"");
    }

    public string type;
    public string itemName;
    public string itemexp;
    public string itemdesc;
    public string itemPrice;
    public Sprite itemImage; 
}
public class itemdata : MonoBehaviour
{
    public TextAsset ItemDatabase;
    public List<Item> AllItemList;
   
    Item myItem;
    GameObject itemdesc;
    Image itemimagee;

    public GameObject prefab;
    GameObject atc;


    void Start()
    {

        string[] line = ItemDatabase.text.Substring(0, ItemDatabase.text.Length - 1).Split('\n');
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');
            AllItemList.Add(new Item(row[0], row[1], row[2], row[3], row[4],row[5]));
        }

        //atc = Instantiate(prefab);
        set();
    }

    void set()
    {
        itemdesc = GameObject.Find("desc");
        //itemimagee = GameObject.Find("itemimagee");
        itemdesc.GetComponent<TextMeshProUGUI>().text = AllItemList[5].itemdesc;
        itemimagee=GetComponent<Image>();
        itemimagee.sprite = Resources.Load<Sprite>("Sprite Assets/gold");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {

        }

        
     
    }

    /* public void changeMaterial()
     {
         gameObject.GetComponent<Sprite>() = 
     }*/
}
