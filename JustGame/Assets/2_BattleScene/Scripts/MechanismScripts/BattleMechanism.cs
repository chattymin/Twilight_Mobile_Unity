using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class BattleMechanism : MonoBehaviour {
    public string playerSelected; //플레이어가 선택한 행동의 종류
    public int enemySelected; //적이 선택한 행동의 종류

    public float playerValue; //플레이어 행동값
    public float enemyValue; //적 행동값

    private int playerHP = GameManager.instance.playerCurrentHP;
    private const int PLAYER_MAX_HP = GameManager.PLAYER_MAX_HP;

    private int enemyHP = GameManager.instance.enemyCurrentHP;
    private int enemyMaxHP = GameManager.instance.enemyMaxHP;


    // *** Battle Run ***
    public void BattleRun(int enemySelected) { //배틀 시작
        playerSelected = GameObject.Find("PlayerBattleManager") //플레이어 행동
            .GetComponent<PlayerBattleController>().playerSelected;

        playerValue = GameObject.Find("PlayerBattleManager") //플레이어 행동값
            .GetComponent<PlayerBattleController>().playerActionValue;
        enemyValue = GameObject.Find("EnemyBattleManager") //적 행동값
            .GetComponent<EnemyBattleController>().enemyActionValue;

        Mechanism();
    }


    // *** Battle Mechanism ***
    private void Mechanism() {
        switch (playerSelected) {
            case "Attack":
                if (enemySelected == 1) { //p공 VS e공
                    PlayerHPDown(enemyValue);
                    EnemyHPDown(playerValue);
                }
                else if (enemySelected == 2) { //p공 VS e방
                    if (playerValue > enemyValue) { //p공 > e방
                        EnemyHPDown(playerValue - enemyValue);
                    }
                    else if (playerValue < enemyValue) { //p공 < e방
                        PlayerHPDown(enemyValue - playerValue);
                    }
                }
                else { //p공 VS e회
                    EnemyHPDown(playerValue);
                    EnemyHPUP(enemyValue);
                }
                break;

            case "Defense":
                if (enemySelected == 1) { //p방 VS e공
                    if (playerValue > enemyValue) { //p방 > e공
                        EnemyHPDown(playerValue - enemyValue);
                    }
                    else if (playerValue < enemyValue) { //p방 < e공
                        PlayerHPDown(enemyValue - playerValue);
                    }
                }
                else if (enemySelected == 2) { //p방 VS e방
                    PlayerHPDown(playerValue);
                    EnemyHPDown(enemyValue);
                }
                else { //p방 VS e회
                    EnemyHPUP(enemyValue);
                }
                break;

            case "Recovery":
                if (enemySelected == 1) { //p회 VS e공
                    PlayerHPDown(enemyValue);
                    PlayerHPUP(playerValue);
                }
                else if (enemySelected == 2) { //p회 VS e방
                    PlayerHPUP(playerValue);
                }
                else { //p회 VS e회
                    PlayerHPUP(playerValue);
                    EnemyHPUP(enemyValue);
                }
                break;

            default: break;
        }
    }


    // *** Battle Mechanism - Player HP ***
    private void PlayerHPUP(float value) {
        playerHP += ((int)value);

        if (playerHP > PLAYER_MAX_HP) //최대 체력 초과 시
            playerHP = PLAYER_MAX_HP;
    }

    private void PlayerHPDown(float value) {
        playerHP -= ((int)value);

        if (playerHP <= 0) { //체력 소진 시
            playerHP = 0;
        }
    }


    // *** Battle Mechanism - Enemy HP ***
    private void EnemyHPUP(float value) {
        enemyHP += (int)value;

        if (enemyHP > enemyMaxHP) //최대 체력 초과 시
            enemyHP = enemyMaxHP;
    }

    private void EnemyHPDown(float value) {
        enemyHP -= (int)value;

        if (enemyHP <= 0) {  //체력 소진 시
            enemyHP = enemyMaxHP;
        }
    }
    public string StateCheck() {
        if (GameManager.instance.playerCurrentHP <= 0) {
            return "LoseST";
        }

        if (GameManager.instance.enemyCurrentHP <= 0){
            GameManager.instance.enemyCurrentHP = GameManager.instance.enemyMaxHP;
            return "WinST";
        }

        return "SelectST";
    }
}