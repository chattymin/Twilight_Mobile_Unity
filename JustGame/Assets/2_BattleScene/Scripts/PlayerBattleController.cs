using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerBattleController : MonoBehaviour {
    public GameObject selectAttack; //플레이어가
    public GameObject selectDefense; //선택한 행동의
    public GameObject selectRecovery; //이미지들.

    public TextMeshProUGUI attackValueText;
    public TextMeshProUGUI defenseValueText;
    public TextMeshProUGUI recoveryValueText;

    public int maxValue; //행동값의 최대값.
    public string playerSelected; //플레이어가 선택한 행동 종류 반환.


    public void Start() { //기본 설정 (요소 비활성화)
        selectAttack.SetActive(false); //행동 이미지
        selectDefense.SetActive(false); //전부!!!
        selectRecovery.SetActive(false); //숨기고 시작.

        attackValueText.text = "";
        defenseValueText.text = "";
        recoveryValueText.text = "";

        playerSelected = GameObject.Find("ActionManager") //행동 가져오기
            .GetComponent<ActionSelectController>().Action;
    }

    
    public void ActionSelectRun() { //확인 버튼을 눌렀을 때 메뉴가 내려가고 
        Start();                    //행동 종류에 따라 메소드 실행
        if (playerSelected == "Attack") { //공격을 눌렀을 경우
            SelectAttackImg(); //공격 이미지 표시
            ShowAttackValue(); //공격 행동값 표시
        }
        else if (playerSelected == "Defense") { //방어를 눌렀을 경우
            SelectDefenseImg(); //방어 이미지 표시
            ShowDefenseValue(); //방어 행동값 표시
        }
        else if (playerSelected == "Recovery") { //회복을 눌렀을 경우
            SelectRecoveryImg(); //회복 이미지 표시
            ShowRecoveryValue(); //회복 행동값 표시
        }
        //else ~
    }


    public void SelectAttackImg() { //공격 이미지 표시
        selectAttack.SetActive(true); //이미지 표시
        selectDefense.SetActive(false);
        selectRecovery.SetActive(false);
    }
    public void SelectAttackVal() { //공격 랜덤 값 구하기
        int attack = PlayerSetting.attackLV; //공격 능력치 불러오기
        maxValue = attack * 2; //최대값은 공격 레벨의 2배
        int attackValue = Random.Range(attack, maxValue + 1); //랜덤
        attackValueText.text = attackValue.ToString(); //공격값을 문자열로 변환
    }
    public void ShowAttackValue() { //공격 행동값 표시
        SelectAttackVal();
        defenseValueText.text = "";
        recoveryValueText.text = "";
    }


    public void SelectDefenseImg() { //방어 이미지 표시
        selectAttack.SetActive(false);
        selectDefense.SetActive(true); //이미지 표시
        selectRecovery.SetActive(false);
    }
    public void SelectDefenseVal() { //방어 랜덤 값 구하기
        int defense = PlayerSetting.defenseLV; //방어 능력치 불러오기
        maxValue = defense * 2; //최대값은 방어 레벨의 2배
        int defenseValue = Random.Range(defense, maxValue + 1); //랜덤
        defenseValueText.text = defenseValue.ToString(); //방어값을 문자열로 변환
    }
    public void ShowDefenseValue() { //방어 행동값 표시
        attackValueText.text = "";
        SelectDefenseVal();
        recoveryValueText.text = "";
    }


    public void SelectRecoveryImg() { //회복 이미지 표시
        selectAttack.SetActive(false); 
        selectDefense.SetActive(false);
        selectRecovery.SetActive(true); //이미지 표시
    }
    public void SelectRecoveryVal() { //회복 랜덤 값 구하기
        int recovery = PlayerSetting.recoveryLV; //회복 능력치 불러오기
        maxValue = recovery * 2; //최대값은 회복 레벨의 2배
        int recoveryValue = Random.Range(recovery, maxValue + 1); //랜덤
        recoveryValueText.text = recoveryValue.ToString(); //공격값을 문자열로 변환
    }
    public void ShowRecoveryValue() { //회복 행동값 표시
        attackValueText.text = "";
        defenseValueText.text = "";
        SelectRecoveryVal();
    }
}