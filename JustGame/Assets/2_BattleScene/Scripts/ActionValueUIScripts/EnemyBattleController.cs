using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyBattleController : MonoBehaviour {
    GameObject enemyAttack;
    GameObject enemyDefense;
    GameObject enemyRecovery;

    TextMeshProUGUI enemyAttackValueText;
    TextMeshProUGUI enemyDefenseValueText;
    TextMeshProUGUI enemyRecoveryValueText;

    public float enemyActionValue;
    private const float VALUE_INCREASE_RATE = 2.0f; //레벨 * 행동값 증가 비율 = 최대 행동값


    // *** Enemy Battle Run ***
    public void EnemyActionSelectRun() {
        if (StateSetting.CompareStates("BattleST")) {
            int enemyRandomAction = Random.Range(1, 4); //공격 = 1, 방어 = 2, 회복 = 3
            switch (enemyRandomAction) {
                case 1:
                    ShowAttack(); break;
                case 2:
                    ShowDefense(); break;
                case 3:
                    ShowRecovery(); break;
                default: break;
            }
            GameObject.Find("EnemyBattleEffect").GetComponent<EnemyBattleEffect>().EffectOn(enemyRandomAction);
            GameObject.Find("BattleMechanism").GetComponent<BattleMechanism>().BattleRun(enemyRandomAction);
        }
    }


    // *** Action Image, Text Initialization(Reset) ***
    private void Reset() {
        enemyAttack.SetActive(false);
        enemyDefense.SetActive(false);
        enemyRecovery.SetActive(false);

        enemyAttackValueText.text = "";
        enemyDefenseValueText.text = "";
        enemyRecoveryValueText.text = "";
    }


    // *** Action Value Calculation ***
    private string ValueCalc(int action) {
        float maxValue = action * VALUE_INCREASE_RATE;
        enemyActionValue = Random.Range(action, maxValue + 1);
        return enemyActionValue.ToString();
    }


    // *** Attack Controller ***
    private void ShowAttack() {
        Reset();
        enemyAttack.SetActive(true);
        AttackValue();
    }

    private void AttackValue() {
        int attack = GameManager.instance.playerAttackLV;
        enemyAttackValueText.text = ValueCalc(attack);
    }


    // *** Defense Controller ***
    private void ShowDefense() {
        Reset();
        enemyDefense.SetActive(true);
        DefenseValue();
    }

    private void DefenseValue() {
        int defense = GameManager.instance.playerDefenseLV;
        enemyDefenseValueText.text = ValueCalc(defense);
    }


    // *** Recovery Controller ***
    private void ShowRecovery() {
        Reset();
        enemyRecovery.SetActive(true);
        RecoveryValue();
    }

    private void RecoveryValue() {
        int recovery = GameManager.instance.playerRecoveryLV;
        enemyRecoveryValueText.text = ValueCalc(recovery);
    }
}