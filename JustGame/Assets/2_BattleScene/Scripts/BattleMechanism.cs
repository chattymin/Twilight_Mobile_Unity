using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using static UnityEditor.PlayerSettings;
using System;

public class BattleMechanism : MonoBehaviour {
    public string playerSelected; //플레이어가 선택한 행동의 종류
    public int enemySelected; //적이 선택한 행동의 종류

    public int playerValue; //플레이어 행동값
    public int enemyValue; //적 행동값


    public void Start() {
        
    }


    public void BattleRun(int enemySelected) { //배틀 시작
        playerSelected = GameObject.Find("PlayerBattleManager") //플레이어 행동
            .GetComponent<PlayerBattleController>().playerSelected;

        playerValue = GameObject.Find("PlayerBattleManager") //플레이어 행동값
            .GetComponent<PlayerBattleController>().playerActionValue;
        enemyValue = GameObject.Find("EnemyBattleManager") //적 행동값
            .GetComponent<EnemyBattleController>().enemyActionValue;

        switch (playerSelected) {
            case "Attack":
                if (enemySelected == 1) { //p공 VS e공
                    PlayerSetting.HP -= enemyValue;
                    EnemySetting.HP -= playerValue;
                }
                else if (enemySelected == 2) { //p공 VS e방
                    if (playerValue > enemyValue) { //p공 > e방
                        EnemySetting.HP -= (playerValue - enemyValue);
                    }
                    else if (playerValue < enemyValue) { //p공 < e방
                        PlayerSetting.HP -= (enemyValue - playerValue);
                    }
                }
                else { //p공 VS e회
                    EnemySetting.HP -= playerValue;
                    EnemySetting.HP += enemyValue;
                    if (EnemySetting.HP > EnemySetting.MaxHP)
                        EnemySetting.HP = EnemySetting.MaxHP;                        
                }
                break;

            case "Defense":
                if (enemySelected == 1) { //p방 VS e공
                    if (playerValue > enemyValue) { //p방 > e공
                        EnemySetting.HP -= (playerValue - enemyValue);
                    }
                    else if (playerValue < enemyValue) { //p방 < e공
                        PlayerSetting.HP -= (enemyValue - playerValue);
                    }
                }
                else if (enemySelected == 2) { //p방 VS e방
                    PlayerSetting.HP -= playerValue;
                    EnemySetting.HP -= enemyValue;
                }
                else { //p방 VS e회
                    EnemySetting.HP += enemyValue;
                    if (EnemySetting.HP > EnemySetting.MaxHP)
                        EnemySetting.HP = EnemySetting.MaxHP;
                }
                break;

            case "Recovery":
                if (enemySelected == 1) { //p회 VS e공
                    PlayerSetting.HP -= enemyValue;
                    PlayerSetting.HP += playerValue;
                    if (PlayerSetting.HP > PlayerSetting.MaxHP)
                        PlayerSetting.HP = PlayerSetting.MaxHP;
                }
                else if (enemySelected == 2) { //p회 VS e방
                    PlayerSetting.HP += playerValue;
                    if (PlayerSetting.HP > PlayerSetting.MaxHP)
                        PlayerSetting.HP = PlayerSetting.MaxHP;
                }
                else { //p회 VS e회
                    PlayerSetting.HP += playerValue;
                    if (PlayerSetting.HP > PlayerSetting.MaxHP)
                        PlayerSetting.HP = PlayerSetting.MaxHP;

                    EnemySetting.HP += enemyValue;
                    if (EnemySetting.HP > EnemySetting.MaxHP)
                        EnemySetting.HP = EnemySetting.MaxHP;
                }
                break;

            default:
                break;
        }
    }

    public string StateCheck()
    {
        if (PlayerSetting.HP <= 0)
        {
            return "LoseST";
            //StateSetting.SetStates("LoseST");
        }
        if (EnemySetting.HP <= 0)
        {
            EnemySetting.HP = EnemySetting.MaxHP;
            return "WinST";
            //StateSetting.SetStates("WinST");
        }
        return "SelectST";
    }
}
