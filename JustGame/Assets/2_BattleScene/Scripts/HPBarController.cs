using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPBarController : MonoBehaviour {
    public TextMeshProUGUI playerHP;
    public TextMeshProUGUI enemyHP;

    public void Start() {
        playerHP.text = PlayerSetting.HP.ToString();
        enemyHP.text = "50/" + EnemySetting.HP.ToString();
    }

    public void HPUpdate() {
        playerHP.text = PlayerSetting.HP.ToString();
        enemyHP.text = "50/" + EnemySetting.HP.ToString();
    }
}