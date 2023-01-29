using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerBattleController : MonoBehaviour {
    GameObject selectAttack;
    GameObject selectDefense;
    GameObject selectRecovery;

    TextMeshProUGUI attackValueText;
    TextMeshProUGUI defenseValueText;
    TextMeshProUGUI recoveryValueText;

    public string playerSelected;
    public float playerActionValue;
    private const string BATTLEST = "BattleST";
    private const float VALUE_INCREASE_RATE = 2.0f; //레벨 * 행동값 증가 비율 = 최대 행동값


    // *** Player Battle Run ***
    public void ActionSelectRun() {
        playerSelected = GameObject.Find("ActionManager").GetComponent<ActionSelectController>().Action;
        switch (playerSelected) {
            case "Attack":
                ShowAttack(); break;
            case "Defense":
                ShowDefense(); break;
            case "Recovery":
                ShowRecovery(); break;
            default:
                StateSetting.SetStates(BATTLEST); break;
        }
        GameObject.Find("PlayerBattleEffect").GetComponent<PlayerBattleEffect>().EffectOn(playerSelected);
        GameObject.Find("EnemyBattleManager").GetComponent<EnemyBattleController>().EnemyActionSelectRun();
    }


    // *** Action Image, Text Initialization(Reset) ***
    private void Reset() {
        selectAttack.SetActive(false);
        selectDefense.SetActive(false);
        selectRecovery.SetActive(false);

        attackValueText.text = "";
        defenseValueText.text = "";
        recoveryValueText.text = "";
    }


    // *** Action Value Calculation ***
    private string ValueCalc(int action) {
        float maxValue = action * VALUE_INCREASE_RATE;
        playerActionValue = Random.Range(action, maxValue + 1);
        return playerActionValue.ToString();
    }


    // *** Attack Controller ***
    private void ShowAttack() {
        Reset();
        selectAttack.SetActive(true);
        AttackValue();
    }

    private void AttackValue() {
        int attack = GameManager.instance.playerAttackLV;
        attackValueText.text = ValueCalc(attack);
    }


    // *** Defense Controller ***
    private void ShowDefense() {
        Reset();
        selectDefense.SetActive(true);
        DefenseValue();
    }

    private void DefenseValue() {
        int defense = GameManager.instance.playerDefenseLV;
        defenseValueText.text = ValueCalc(defense);
    }



    // *** Recovery Controller ***
    private void ShowRecovery() {
        Reset();
        selectRecovery.SetActive(true);
        RecoveryValue();
    }

    private void RecoveryValue() {
        int recovery = GameManager.instance.playerRecoveryLV;
        recoveryValueText.text = ValueCalc(recovery);
    }
}