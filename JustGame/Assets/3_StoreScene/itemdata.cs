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
public class ItemData : MonoBehaviour
{
    public List<Item> AllItemList = new List<Item>(10);
    public Image showImage;
    public GameObject itemdesc;
    public Item exitItem;
    int indexNumber;
    public bool[] bought = new bool[10];

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

    /* 구매 버튼 클릭 시 bought 배열 true로 변경. 
     * indexNumber활용해 해당 인덱스번호 내용 수정. 
    */
    public void boughtUpdate() {
       bought[indexNumber] = true;
    }
}
