using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPBarController : MonoBehaviour {
    public TextMeshProUGUI playerHP;
    public TextMeshProUGUI enemyHP;

    GameObject playerHPGauge;
    GameObject enemyHPGauge;

    const float FILL = 0.01f;

    public void Start() {
        setHP();

        this.playerHPGauge = GameObject.Find("HPGauge");
        this.enemyHPGauge = GameObject.Find("HP_GaugeFront");

        this.playerHPGauge.GetComponent<Image>().fillAmount = 1;
        this.enemyHPGauge.GetComponent<Image>().fillAmount = 1;
    }

    public void HPUpdate() {
        setHP();
        this.playerHPGauge.GetComponent<Image>().fillAmount = GameManager.instance.playerCurrentHP * FILL;
        this.enemyHPGauge.GetComponent<Image>().fillAmount 
            = GameManager.instance.enemyCurrentHP * (FILL * (100.0f * (float)GameManager.instance.enemyMaxHP));
    }

    private void setHP(){
        playerHP.text = GameManager.instance.playerCurrentHP + "";
        enemyHP.text = GameManager.instance.enemyMaxHP + "/" + GameManager.instance.enemyCurrentHP;
    }
}