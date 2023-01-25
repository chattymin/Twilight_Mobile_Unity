using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSetting : MonoBehaviour {
    //int ItemNumbers;
    public List<Item> AllItemList = new List<Item>(12);
    
    public void Start() {
        DontDestroyOnLoad(gameObject);
        PlayerSetting.item = AllItemList[0];
    }
}
