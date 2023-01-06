using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerInfo : MonoBehaviour
{
    private GameObject curmoney;

    void Start() {
       GameObject.Find("curmoney").GetComponent<TextMeshProUGUI> ().text = PlayerSetting.money.ToString();
    }

    public static void updateMoney() {
        GameObject.Find("curmoney").GetComponent<TextMeshProUGUI>().text = PlayerSetting.money.ToString();

    }




}
