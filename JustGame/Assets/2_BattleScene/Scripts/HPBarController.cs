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
<<<<<<< Updated upstream:JustGame/Assets/2_BattleScene/Scripts/HPBarController.cs
        playerHP.text = PlayerSetting.HP + "";
        enemyHP.text = EnemySetting.HP + "/" + EnemySetting.MaxHP;

        this.playerHPGauge.GetComponent<Image>().fillAmount = PlayerSetting.HP * 0.01f;
        this.enemyHPGauge.GetComponent<Image>().fillAmount 
            = EnemySetting.HP * (0.01f * ((float)PlayerSetting.MaxHP / (float)EnemySetting.MaxHP));
=======
        setHP();
        this.playerHPGauge.GetComponent<Image>().fillAmount = GameManager.instance.playerCurrentHP * FILL;
        this.enemyHPGauge.GetComponent<Image>().fillAmount 
            = GameManager.instance.enemyCurrentHP * (FILL * (100.0f / (float)GameManager.instance.enemyMaxHP));
    }

    private void setHP(){
        playerHP.text = GameManager.instance.playerCurrentHP + "";
        enemyHP.text = GameManager.instance.enemyCurrentHP + "/" + GameManager.instance.enemyMaxHP;
>>>>>>> Stashed changes:JustGame/Assets/2_BattleScene/Scripts/StatusUIScripts/HPBarController.cs
    }
}