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


    public void Start() {
        playerHP.text = PlayerSetting.MaxHP + "";
        enemyHP.text = EnemySetting.MaxHP + "/" + EnemySetting.MaxHP;

        this.playerHPGauge = GameObject.Find("HPGauge");
        this.enemyHPGauge = GameObject.Find("HP_GaugeFront");

        this.playerHPGauge.GetComponent<Image>().fillAmount = 1;
        this.enemyHPGauge.GetComponent<Image>().fillAmount = 1;
    }

    public void HPUpdate() {
        playerHP.text = PlayerSetting.HP + "";
        enemyHP.text = EnemySetting.MaxHP + "/" + EnemySetting.HP;

        this.playerHPGauge.GetComponent<Image>().fillAmount = PlayerSetting.HP * 0.01f;
        this.enemyHPGauge.GetComponent<Image>().fillAmount = EnemySetting.HP * 0.01f * (100.0f / 30.0f);
    }
}