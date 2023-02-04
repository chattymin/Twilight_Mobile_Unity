using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPBarController : MonoBehaviour {
    public TextMeshProUGUI playerHPText;
    public TextMeshProUGUI enemyHPText;

    public GameObject playerHPGauge;
    public GameObject enemyHPGauge;

    private const float FILL = 0.01f;


    void Start() {
        playerHPText.text = GameManager.PLAYER_MAX_HP + "";
        enemyHPText.text = GameManager.instance.enemyMaxHP + "/" + GameManager.instance.enemyMaxHP;

        this.playerHPGauge = GameObject.Find("HPGauge");
        this.enemyHPGauge = GameObject.Find("HP_GaugeFront");

        this.playerHPGauge.GetComponent<Image>().fillAmount = 1;
        this.enemyHPGauge.GetComponent<Image>().fillAmount = 1;
    }

    public void HPUpdate() {
        playerHPText.text = GameManager.instance.playerCurrentHP + "";
        enemyHPText.text = GameManager.instance.enemyCurrentHP + "/" + GameManager.instance.enemyMaxHP;

        this.playerHPGauge.GetComponent<Image>().fillAmount = GameManager.instance.playerCurrentHP * FILL;
        this.enemyHPGauge.GetComponent<Image>().fillAmount
            = GameManager.instance.enemyCurrentHP * (FILL * (100.0f / GameManager.instance.enemyMaxHP));
    }
}