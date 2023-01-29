using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerItem : MonoBehaviour {
    public GameObject inventoryItem;

    void Start() {
        if(GameManager.instance.playerInventoryItem != null)
            inventoryItem.GetComponent<Image>().sprite = GameManager.instance.playerInventoryItem.itemImage;
    }
}
