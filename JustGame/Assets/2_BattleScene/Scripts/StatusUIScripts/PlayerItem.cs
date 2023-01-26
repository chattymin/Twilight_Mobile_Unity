using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerItem : MonoBehaviour {
    public GameObject inventoryItem;

    void Start() {
        inventoryItem.GetComponent<Image>().sprite = PlayerSetting.item.itemImage;
    }
}
