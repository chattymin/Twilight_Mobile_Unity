using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleController : MonoBehaviour {
    public GameObject selectAttack; //플레이어가
    public GameObject selectDefense; //선택한 행동의
    public GameObject selectRecovery; //이미지들.

    public GameObject attackValue; //플레이어가
    public GameObject defenseValue; //선택한 행동의
    public GameObject recoveryValue; //행동값 텍스트.

    public int maxValue; //행동값의 최대값.
    public string playerSelected; //플레이어가 선택한 행동 종류 반환.


    public void Start() { //기본 설정
        selectAttack.SetActive(false); //행동 이미지
        selectDefense.SetActive(false); //전부!!!
        selectRecovery.SetActive(false); //숨기고 시작
        playerSelected = GameObject.Find("ActionManager") //행동 가져오기
            .GetComponent<ActionSelectController>().Action;
    }

    
    public void ActionSelectRun() { //확인 버튼을 눌렀을 때 메뉴가 내려가고 
        Start();                    //행동 종류에 따라 메소드 실행
        if (playerSelected == "Attack") { //공격을 눌렀을 경우
            SelectAttackImg(); //공격 이미지 표시
            SelectAttackValue(); //공격 행동값 표시
        }
        else if (playerSelected == "Defense") { //방어를 눌렀을 경우
            SelectDefenseImg(); //방어 이미지 표시
            SelectDefenseValue(); //방어 행동값 표시
        }
        else if (playerSelected == "Recovery") { //회복을 눌렀을 경우
            SelectRecoveryImg(); //회복 이미지 표시
            SelectRecoveryValue(); //회복 행동값 표시
        }
        //else ~
    }


    public void SelectAttackImg() { //공격 이미지 표시
        selectAttack.SetActive(true); //이미지 표시
        selectDefense.SetActive(false);
        selectRecovery.SetActive(false);
    }
    public int SelectAttackVal() { //공격 랜덤 값 구하기
        int attack = PlayerSetting.attackLV; //공격 능력치 불러오기
        maxValue = attack * 2; //최대값은 공격 레벨의 2배
        int attackValue = Random.Range(attack, maxValue + 1); //랜덤
        return attackValue; //공격값 반환
    }
    public void SelectAttackValue() { //공격 행동값 표시
        attackValue.SetActive(true); //텍스트 표시
        defenseValue.SetActive(false);
        recoveryValue.SetActive(false);
    }


    public void SelectDefenseImg() { //방어 이미지 표시
        selectAttack.SetActive(false);
        selectDefense.SetActive(true); //이미지 표시
        selectRecovery.SetActive(false);
    }
    public int SelectADefenseVal() { //방어 랜덤 값 구하기
        int defense = PlayerSetting.defenseLV; //방어 능력치 불러오기
        maxValue = defense * 2; //최대값은 방어 레벨의 2배
        int defenseValue = Random.Range(defense, maxValue + 1); //랜덤
        return defenseValue; //방어값 반환
    }
    public void SelectDefenseValue() { //방어 행동값 표시
        attackValue.SetActive(false);
        defenseValue.SetActive(true); //텍스트 표시
        recoveryValue.SetActive(false);
    }


    public void SelectRecoveryImg() { //회복 이미지 표시
        selectAttack.SetActive(false); 
        selectDefense.SetActive(false);
        selectRecovery.SetActive(true); //이미지 표시
    }
    public int SelectRecoveryVal() { //회복 랜덤 값 구하기
        int recovery = PlayerSetting.recoveryLV; //회복 능력치 불러오기
        maxValue = recovery * 2; //최대값은 회복 레벨의 2배
        int recoveryValue = Random.Range(recovery, maxValue + 1); //랜덤
        return recoveryValue; //회복값 반환
    }
    public void SelectRecoveryValue() { //회복 행동값 표시
        attackValue.SetActive(false);
        defenseValue.SetActive(false);
        recoveryValue.SetActive(true); //텍스트 표시
    }
}