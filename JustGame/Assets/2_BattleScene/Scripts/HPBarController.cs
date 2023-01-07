using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPBarController : MonoBehaviour
{
    public TextMeshProUGUI playerHP;
    public TextMeshProUGUI enemyHP;

    int intPlayerHP = PlayerSetting.HP;
    int intEnemyHP = EnemySetting.HP;

    public void HPUpdate()
    {
        playerHP.text = "100/" + intPlayerHP.ToString();
        enemyHP.text = intEnemyHP.ToString();
    }
}