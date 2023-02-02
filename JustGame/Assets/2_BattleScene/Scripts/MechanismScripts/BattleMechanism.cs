using UnityEngine;

public class BattleMechanism : MonoBehaviour {
    public string playerSelected; //플레이어가 선택한 행동의 종류

    public float playerValue; //플레이어 행동값
    public float enemyValue; //적 행동값


    // *** Battle Run ***
    public void BattleRun(int enemySelected) { //배틀 시작
        playerSelected = GameObject.Find("BattleManager") //플레이어 행동
            .GetComponent<PlayerBattleController>().playerSelected;

        playerValue = GameObject.Find("BattleManager") //플레이어 행동값
            .GetComponent<PlayerBattleController>().playerActionValue;
        enemyValue = GameObject.Find("BattleManager") //적 행동값
            .GetComponent<EnemyBattleController>().enemyActionValue;

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
        GameManager.instance.playerCurrentHP += (int)value;

        if (GameManager.instance.playerCurrentHP > GameManager.PLAYER_MAX_HP) //최대 체력 초과 시
            GameManager.instance.playerCurrentHP = GameManager.PLAYER_MAX_HP;
    }

    private void PlayerHPDown(float value) {
        GameManager.instance.playerCurrentHP -= (int)value;
        StateCheck();

        if (GameManager.instance.playerCurrentHP <= 0) { //체력 소진 시
            GameManager.instance.playerCurrentHP = 0;
        }
    }


    // *** Battle Mechanism - Enemy HP ***
    private void EnemyHPUP(float value) {
        GameManager.instance.enemyCurrentHP += (int)value;

        if (GameManager.instance.enemyCurrentHP > GameManager.instance.enemyMaxHP) //최대 체력 초과 시
            GameManager.instance.enemyCurrentHP = GameManager.instance.enemyMaxHP;
    }

    private void EnemyHPDown(float value) {
        GameManager.instance.enemyCurrentHP -= (int)value;
        StateCheck();

        if (GameManager.instance.enemyCurrentHP <= 0) {  //체력 소진 시
            GameManager.instance.enemyCurrentHP = GameManager.instance.enemyMaxHP;
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