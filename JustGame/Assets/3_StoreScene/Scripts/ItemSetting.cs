using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSetting : MonoBehaviour
{
    public List<Item> AllItemList = new List<Item>(12); //������ ����Ʈ
    // Start is called before the first frame update
    
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        PlayerSetting.item = AllItemList[0];
    }

}
