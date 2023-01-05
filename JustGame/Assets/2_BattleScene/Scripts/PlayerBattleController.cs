using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleController : MonoBehaviour {
    public GameObject selectAttack; //�����
    public GameObject selectDefense; //���� ����
    public GameObject selectRecovery; //�׵θ� 
    public int maxValue; //�ൿ���� �ִ밪
    public string playerSelected; //�÷��̾ ������ �ൿ ���� ��ȯ


    public void Start() { //�⺻ ����
        selectAttack.SetActive(false); //�ൿ �̹���
        selectDefense.SetActive(false); //����!!!
        selectRecovery.SetActive(false); //����� ����
        playerSelected = GameObject.Find("ActionManager") //�ൿ ��������
            .GetComponent<ActionSelectController>().Action;
    }

    
    public void ActionSelectRun() { //�ൿ ������ ���� �޼ҵ� ����
        Start();
        if (playerSelected == "Attack")
            SelectAttackImg(); //������ ������ ���
        else if (playerSelected == "Defense")
            SelectDefenseImg(); //�� ������ ���
        else
            SelectRecoveryImg(); //ȸ���� ������ ���
    }


    public void SelectAttackImg() { //���� �̹��� ǥ��
        selectAttack.SetActive(true); //�̹��� ǥ��
        selectDefense.SetActive(false);
        selectRecovery.SetActive(false);
    }
    public int SelectAttackVal() { //���� ���� �� ǥ��
        int attack = PlayerSetting.attackLV; //���� �ɷ�ġ �ҷ�����
        maxValue = attack * 2; //�ִ밪�� ���� ������ 2��
        int attackValue = Random.Range(attack, maxValue + 1); //����
        return attackValue; //���ݰ� ��ȯ
    }


    public void SelectDefenseImg() { //��� �̹��� ǥ��
        selectAttack.SetActive(false);
        selectDefense.SetActive(true); //�̹��� ǥ��
        selectRecovery.SetActive(false);
    }
    public int SelectADefenseVal() { //��� ���� �� ǥ��
        int defense = PlayerSetting.defenseLV; //��� �ɷ�ġ �ҷ�����
        maxValue = defense * 2; //�ִ밪�� ��� ������ 2��
        int defenseValue = Random.Range(defense, maxValue + 1); //����
        return defenseValue; //�� ��ȯ
    }


    public void SelectRecoveryImg() { //ȸ�� �̹��� ǥ��
        selectAttack.SetActive(false); 
        selectDefense.SetActive(false);
        selectRecovery.SetActive(true); //�̹��� ǥ��
    }
    public int SelectRecoveryVal() { //��� ���� �� ǥ��
        int recovery = PlayerSetting.recoveryLV; //ȸ�� �ɷ�ġ �ҷ�����
        maxValue = recovery * 2; //�ִ밪�� ȸ�� ������ 2��
        int recoveryValue = Random.Range(recovery, maxValue + 1); //����
        return recoveryValue; //ȸ���� ��ȯ
    }
}