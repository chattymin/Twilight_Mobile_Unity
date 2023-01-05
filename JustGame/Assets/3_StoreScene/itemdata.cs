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
public class ItemData : MonoBehaviour
{
    public List<Item> AllItemList = new List<Item>(10);
    public Image showImage;
    public GameObject itemdesc;
    public Item exitItem;
    int indexNumber;
    public bool[] bought = new bool[10];

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
    public void changeImage() {
        indexNumber = Random.Range(0, 10);
        while (bought[indexNumber] == true) {
            indexNumber= Random.Range(0, 10);
        }
        exitItem = AllItemList[indexNumber];
        showImage.sprite = exitItem.itemImage;
        itemdesc = GameObject.Find("desc");
        itemdesc.GetComponent<TextMeshProUGUI>().text = exitItem.itemdesc;
    }

    /* ���� ��ư Ŭ�� �� bought �迭 true�� ����. 
     * indexNumberȰ���� �ش� �ε�����ȣ ���� ����. 
    */
    public void boughtUpdate() {
       bought[indexNumber] = true;
    }
}
