using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSetting : MonoBehaviour
{
    public List<Item> AllItemList = new List<Item>(12); //아이템 리스트
    // Start is called before the first frame update
    
    public void Start()
    {
        PlayerSetting.item = AllItemList[0];
    }

}
