using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleController : MonoBehaviour {
    public GameObject selectAttack; //�÷��̾
    public GameObject selectDefense; //������ �ൿ��
    public GameObject selectRecovery; //�̹�����.

    public GameObject attackValue; //�÷��̾
    public GameObject defenseValue; //������ �ൿ��
    public GameObject recoveryValue; //�ൿ�� �ؽ�Ʈ.

    public int maxValue; //�ൿ���� �ִ밪.
    public string playerSelected; //�÷��̾ ������ �ൿ ���� ��ȯ.

    public const string BATTLEST = "BattleST";

    public void Start() { //�⺻ ����
        selectAttack.SetActive(false); //�ൿ �̹���
        selectDefense.SetActive(false); //����!!!
        selectRecovery.SetActive(false); //����� ����
        playerSelected = GameObject.Find("ActionManager") //�ൿ ��������
            .GetComponent<ActionSelectController>().Action;
    }

    
    public void ActionSelectRun() { //Ȯ�� ��ư�� ������ �� �޴��� �������� 
        Start();                    //�ൿ ������ ���� �޼ҵ� ����
        if (playerSelected == "Attack") { //������ ������ ���
            SelectAttackImg(); //���� �̹��� ǥ��
            SelectAttackValue(); //���� �ൿ�� ǥ��
            StateSetting.SetStates(BATTLEST);
        }
        else if (playerSelected == "Defense") { //�� ������ ���
            SelectDefenseImg(); //��� �̹��� ǥ��
            SelectDefenseValue(); //��� �ൿ�� ǥ��
            StateSetting.SetStates(BATTLEST);
        }
        else if (playerSelected == "Recovery") { //ȸ���� ������ ���
            SelectRecoveryImg(); //ȸ�� �̹��� ǥ��
            SelectRecoveryValue(); //ȸ�� �ൿ�� ǥ��
            StateSetting.SetStates(BATTLEST);
        }
        //else ~
    }


    public void SelectAttackImg() { //���� �̹��� ǥ��
        selectAttack.SetActive(true); //�̹��� ǥ��
        selectDefense.SetActive(false);
        selectRecovery.SetActive(false);
    }
    public int SelectAttackVal() { //���� ���� �� ���ϱ�
        int attack = PlayerSetting.attackLV; //���� �ɷ�ġ �ҷ�����
        maxValue = attack * 2; //�ִ밪�� ���� ������ 2��
        int attackValue = Random.Range(attack, maxValue + 1); //����
        return attackValue; //���ݰ� ��ȯ
    }
    public void SelectAttackValue() { //���� �ൿ�� ǥ��
        attackValue.SetActive(true); //�ؽ�Ʈ ǥ��
        defenseValue.SetActive(false);
        recoveryValue.SetActive(false);
    }


    public void SelectDefenseImg() { //��� �̹��� ǥ��
        selectAttack.SetActive(false);
        selectDefense.SetActive(true); //�̹��� ǥ��
        selectRecovery.SetActive(false);
    }
    public int SelectADefenseVal() { //��� ���� �� ���ϱ�
        int defense = PlayerSetting.defenseLV; //��� �ɷ�ġ �ҷ�����
        maxValue = defense * 2; //�ִ밪�� ��� ������ 2��
        int defenseValue = Random.Range(defense, maxValue + 1); //����
        return defenseValue; //�� ��ȯ
    }
    public void SelectDefenseValue() { //��� �ൿ�� ǥ��
        attackValue.SetActive(false);
        defenseValue.SetActive(true); //�ؽ�Ʈ ǥ��
        recoveryValue.SetActive(false);
    }


    public void SelectRecoveryImg() { //ȸ�� �̹��� ǥ��
        selectAttack.SetActive(false); 
        selectDefense.SetActive(false);
        selectRecovery.SetActive(true); //�̹��� ǥ��
    }
    public int SelectRecoveryVal() { //ȸ�� ���� �� ���ϱ�
        int recovery = PlayerSetting.recoveryLV; //ȸ�� �ɷ�ġ �ҷ�����
        maxValue = recovery * 2; //�ִ밪�� ȸ�� ������ 2��
        int recoveryValue = Random.Range(recovery, maxValue + 1); //����
        return recoveryValue; //ȸ���� ��ȯ
    }
    public void SelectRecoveryValue() { //ȸ�� �ൿ�� ǥ��
        attackValue.SetActive(false);
        defenseValue.SetActive(false);
        recoveryValue.SetActive(true); //�ؽ�Ʈ ǥ��
    }
}