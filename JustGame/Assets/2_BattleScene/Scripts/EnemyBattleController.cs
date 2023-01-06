using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyBattleController : MonoBehaviour {
    public GameObject enemyAttack; //적의
    public GameObject enemyDefense; //선택된 행동의
    public GameObject enemyRecovery; //이미지들.

    public TextMeshProUGUI enemyAttackValueText; //적의
    public TextMeshProUGUI enemyDefenseValueText; //선택된 
    public TextMeshProUGUI enemyRecoveryValueText; //행동의 행동값들.

    public int enemyMaxValue; //행동값의 최대값.


    public void Start() { //기본 설정 (요소 비활성화)
        enemyAttack.SetActive(false); //행동 이미지
        enemyDefense.SetActive(false); //전부!!!
        enemyRecovery.SetActive(false); //숨기고 시작.

        enemyAttackValueText.text = "";
        enemyDefenseValueText.text = "";
        enemyRecoveryValueText.text = "";
    }


    public void EnemyActionSelectRun() { //확인 버튼을 눌렀을 때 메뉴가 내려가고 
        Start();                         //행동 종류에 따라 플레이어와 동시에 메소드 실행
        int enemyRandomAction = Random.Range(1, 4); //적의 행동: 1, 2, 3 중 랜덤으로 선택
        if (enemyRandomAction == 1) { //1이 나오면 공격
            SelectAttackImg(); //공격 이미지 표시
            ShowAttackValue(); //공격 행동값 표시
        }
        else if (enemyRandomAction == 2) { //2가 나오면 공격
            SelectDefenseImg(); //방어 이미지 표시
            ShowDefenseValue(); //방어 행동값 표시
        }
        else if (enemyRandomAction == 3) { //3이 나오면 공격
            SelectRecoveryImg(); //회복 이미지 표시
            ShowRecoveryValue(); //회복 행동값 표시
        }
    }


    public void SelectAttackImg() { //공격 이미지 표시
        enemyAttack.SetActive(true); //이미지 표시
        enemyDefense.SetActive(false);
        enemyRecovery.SetActive(false);
    }
    public void SelectAttackVal() { //공격 랜덤 값 구하기
        int attack = EnemySetting.attackLV; //공격 능력치 불러오기
        enemyMaxValue = attack * 2; //최대값은 공격 레벨의 2배
        int attackValue = Random.Range(attack, enemyMaxValue + 1); //랜덤
        enemyAttackValueText.text = attackValue.ToString(); //공격값을 문자열로 변환
    }
    public void ShowAttackValue() { //공격 행동값 표시
        SelectAttackVal();
        enemyDefenseValueText.text = "";
        enemyRecoveryValueText.text = "";
    }


    public void SelectDefenseImg() { //방어 이미지 표시
        enemyAttack.SetActive(false);
        enemyDefense.SetActive(true); //이미지 표시
        enemyRecovery.SetActive(false);
    }
    public void SelectDefenseVal() { //방어 랜덤 값 구하기
        int defense = EnemySetting.defenseLV; //방어 능력치 불러오기
        enemyMaxValue = defense * 2; //최대값은 방어 레벨의 2배
        int defenseValue = Random.Range(defense, enemyMaxValue + 1); //랜덤
        enemyDefenseValueText.text = defenseValue.ToString(); //방어값을 문자열로 변환
    }
    public void ShowDefenseValue() { //방어 행동값 표시
        enemyAttackValueText.text = "";
        SelectDefenseVal();
        enemyRecoveryValueText.text = "";
    }


    public void SelectRecoveryImg() { //회복 이미지 표시
        enemyAttack.SetActive(false);
        enemyDefense.SetActive(false);
        enemyRecovery.SetActive(true); //이미지 표시
    }
    public void SelectRecoveryVal() { //회복 랜덤 값 구하기
        int recovery = EnemySetting.recoveryLV; //회복 능력치 불러오기
        enemyMaxValue = recovery * 2; //최대값은 회복 레벨의 2배
        int recoveryValue = Random.Range(recovery, enemyMaxValue + 1); //랜덤
        enemyRecoveryValueText.text = recoveryValue.ToString(); //공격값을 문자열로 변환
    }
    public void ShowRecoveryValue() { //회복 행동값 표시
        enemyAttackValueText.text = "";
        enemyDefenseValueText.text = "";
        SelectRecoveryVal();
    }
}

