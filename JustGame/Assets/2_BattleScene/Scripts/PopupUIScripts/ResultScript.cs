using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultScript : MonoBehaviour {
    GameObject WinPage;

    TextMeshProUGUI playerHp;
    TextMeshProUGUI playerAttack;
    TextMeshProUGUI playerDefense;
    TextMeshProUGUI playerRecovery;
    TextMeshProUGUI playerMoney;

    public int enemyDropMoney = 0;


    private void Start() {
        playerHp.text = GameManager.instance.playerCurrentHP.ToString();
        playerAttack.text = GameManager.instance.playerAttackLV.ToString();
        playerDefense.text = GameManager.instance.playerDefenseLV.ToString();
        playerRecovery.text = GameManager.instance.playerRecoveryLV.ToString();
        playerMoney.text = GameManager.instance.playerMoney.ToString() + " + " + enemyDropMoney.ToString();
        GameManager.instance.playerMoney += enemyDropMoney;
    }


    // *** Info Pannel Buttons ***
    public void ResultMainButton() {
        SceneManager.LoadScene("MainScene");
    }

    public void ResultExitButton() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}