using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyBattleController : MonoBehaviour {
    public GameObject enemyAttack; //����
    public GameObject enemyDefense; //���õ� �ൿ��
    public GameObject enemyRecovery; //�̹�����.

    public TextMeshProUGUI enemyAttackValueText; //����
    public TextMeshProUGUI enemyDefenseValueText; //���õ� 
    public TextMeshProUGUI enemyRecoveryValueText; //�ൿ�� �ൿ����.

    public int enemyMaxValue; //�ൿ���� �ִ밪.
    public int enemyActionValue; //�ൿ��
    public bool flag;

    public void Start() { //�⺻ ���� (��� ��Ȱ��ȭ)
        enemyAttack.SetActive(false); //�ൿ �̹���
        enemyDefense.SetActive(false); //����!!!
        enemyRecovery.SetActive(false); //����� ����.

        enemyAttackValueText.text = "";
        enemyDefenseValueText.text = "";
        enemyRecoveryValueText.text = "";
    }

    public int enemyRandomAction; //���� �ൿ: 1, 2, 3 �� ������� ����
    public void EnemyActionSelectRun() { //Ȯ�� ��ư�� ������ �� �޴��� �������� 
        if (StateSetting.CompareStates("BattleST"))
        {
            Start();                         //�ൿ ������ ���� �÷��̾�� ���ÿ� �޼ҵ� ����
            int enemyRandomAction = Random.Range(1, 4); //���� �ൿ: 1, 2, 3 �� �������� ����
            if (enemyRandomAction == 1)
            { //1�� ������ ����
                SelectAttackImg(); //���� �̹��� ǥ��
                ShowAttackValue(); //���� �ൿ�� ǥ��
            }
            else if (enemyRandomAction == 2)
            { //2�� ������ ����
                SelectDefenseImg(); //��� �̹��� ǥ��
                ShowDefenseValue(); //��� �ൿ�� ǥ��
            }
            else if (enemyRandomAction == 3)
            { //3�� ������ ����
                SelectRecoveryImg(); //ȸ�� �̹��� ǥ��
                ShowRecoveryValue(); //ȸ�� �ൿ�� ǥ��
            }
            GameObject.Find("EnemyBattleEffect").GetComponent<EnemyBattleEffect>().EffectOn(enemyRandomAction);
            GameObject.Find("BattleMechanism").GetComponent<BattleMechanism>().BattleRun(enemyRandomAction);
        }
    }


    public void SelectAttackImg() { //���� �̹��� ǥ��
        enemyAttack.SetActive(true); //�̹��� ǥ��
        enemyDefense.SetActive(false);
        enemyRecovery.SetActive(false);
    }

    public void SelectAttackVal() { //��� ���� �� ���ϱ�
        int attack = EnemySetting.attackLV; //��� �ɷ�ġ �ҷ����
        enemyMaxValue = attack * 2; //�ִ밪� ��� ������ 2��
        enemyActionValue = Random.Range(attack, enemyMaxValue + 1); //����
        enemyAttackValueText.text = enemyActionValue.ToString(); //��ݰ�� ���ڿ��� ��ȯ
    }
    public void ShowAttackValue() { //���� �ൿ�� ǥ��
        SelectAttackVal();
        enemyDefenseValueText.text = "";
        enemyRecoveryValueText.text = "";
    }

    public void SelectDefenseImg() { //��� �̹��� ǥ��
        enemyAttack.SetActive(false);
        enemyDefense.SetActive(true); //�̹��� ǥ��
        enemyRecovery.SetActive(false);
    }
    public void SelectDefenseVal() { //��� ���� �� ���ϱ�
        int defense = EnemySetting.defenseLV; //��� �ɷ�ġ �ҷ����
        enemyMaxValue = defense * 2; //�ִ밪� ��� ������ 2��
        enemyActionValue = Random.Range(defense, enemyMaxValue + 1); //����
        enemyDefenseValueText.text = enemyActionValue.ToString(); //��� ���ڿ��� ��ȯ
    }
    public void ShowDefenseValue() { //��� �ൿ�� ǥ��
        enemyAttackValueText.text = "";
        SelectDefenseVal();
        enemyRecoveryValueText.text = "";
    }

    public void SelectRecoveryImg() { //ȸ�� �̹��� ǥ��
        enemyAttack.SetActive(false);
        enemyDefense.SetActive(false);
        enemyRecovery.SetActive(true); //�̹��� ǥ��
    }
    public void SelectRecoveryVal() { //ȸ�� ���� �� ���ϱ�
        int recovery = EnemySetting.recoveryLV; //ȸ�� �ɷ�ġ �ҷ����
        enemyMaxValue = recovery * 2; //�ִ밪� ȸ�� ������ 2��
        enemyActionValue = Random.Range(recovery, enemyMaxValue + 1); //����
        enemyRecoveryValueText.text = enemyActionValue.ToString(); //��ݰ�� ���ڿ��� ��ȯ
    }
    public void ShowRecoveryValue() { //ȸ�� �ൿ�� ǥ��
        enemyAttackValueText.text = "";
        enemyDefenseValueText.text = "";
        SelectRecoveryVal();
    }
}

