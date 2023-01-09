using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultScript : MonoBehaviour
{
    GameObject WinPage;
    TextMeshProUGUI Hp;
    TextMeshProUGUI playerAttack;
    TextMeshProUGUI playerDefense;
    TextMeshProUGUI playerRecovery;
    TextMeshProUGUI playerMoney; 
    // Start is called before the first frame update
    void Start(){

        Hp = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();
        playerAttack = GameObject.Find("PlayerAttackLV").GetComponent<TextMeshProUGUI>();
        playerDefense = GameObject.Find("PlayerDefenseLV").GetComponent<TextMeshProUGUI>();
        Hp = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();

        Hp = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();



        WinPage = GameObject.Find("WinPopup");
        WinPage.SetActive(false);
    }

    void popupOn() {
        if (PlayerSetting.HP < 0 && EnemySetting.HP <= 0) {
            WinPage.SetActive(true);
        } 
    }

    void btnClick() {
        SceneManager.LoadScene("");
    }

    void showCurState() { 
    }
}
