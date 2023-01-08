using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerBattleController : MonoBehaviour {
    public GameObject selectAttack; //�÷��̾
    public GameObject selectDefense; //������ �ൿ��
    public GameObject selectRecovery; //�̹�����.


    public TextMeshProUGUI attackValueText;
    public TextMeshProUGUI defenseValueText;
    public TextMeshProUGUI recoveryValueText;

    public int maxValue; //�ൿ���� �ִ밪.
    public string playerSelected; //�÷��̾ ������ �ൿ ���� ��ȯ.
    public int playerActionValue; //행동값

    public const string BATTLEST = "BattleST";


    public void Start() { //�⺻ ��� (��� ��Ȱ��ȭ)
        selectAttack.SetActive(false); //�ൿ �̹���
        selectDefense.SetActive(false); //���!!!
        selectRecovery.SetActive(false); //���� ����.

        attackValueText.text = "";
        defenseValueText.text = "";
        recoveryValueText.text = "";

        playerSelected = GameObject.Find("ActionManager") //�ൿ ������
            .GetComponent<ActionSelectController>().Action;
    }

    
    public void ActionSelectRun() { //Ȯ�� ��ư�� ������ �� �޴��� �������� 
        Start();                    //�ൿ ������ ���� �޼ҵ� ����
        if (playerSelected == "Attack") { //������ ������ ���
            SelectAttackImg(); //���� �̹��� ǥ��
            ShowAttackValue(); //���� �ൿ�� ǥ��
            }
        else if (playerSelected == "Defense") { //�� ������ ���
            SelectDefenseImg(); //��� �̹��� ǥ��
            ShowDefenseValue(); //��� �ൿ�� ǥ��
        }
        else if (playerSelected == "Recovery") { //ȸ���� ������ ���
            SelectRecoveryImg(); //ȸ�� �̹��� ǥ��
            ShowRecoveryValue(); //ȸ�� �ൿ�� ǥ��
        }
        StateSetting.SetStates(BATTLEST);
        GameObject.Find("EnemyBattleManager").GetComponent<EnemyBattleController>().EnemyActionSelectRun();
    }


    public void SelectAttackImg() { //���� �̹��� ǥ��
        selectAttack.SetActive(true); //�̹��� ǥ��
        selectDefense.SetActive(false);
        selectRecovery.SetActive(false);
    }
    public void SelectAttackVal() { //��� ���� �� ���ϱ�
        int attack = PlayerSetting.attackLV; //��� �ɷ�ġ �ҷ����
        maxValue = attack * 2; //�ִ밪� ��� ������ 2��
        playerActionValue = Random.Range(attack, maxValue + 1); //����
        attackValueText.text = playerActionValue.ToString(); //��ݰ�� ���ڿ��� ��ȯ
    }
    public void ShowAttackValue() { //��� �ൿ�� ǥ��
        SelectAttackVal();
        defenseValueText.text = "";
        recoveryValueText.text = "";
    }


    public void SelectDefenseImg() { //��� �̹��� ǥ��
        selectAttack.SetActive(false);
        selectDefense.SetActive(true); //�̹��� ǥ��
        selectRecovery.SetActive(false);
    }
    public void SelectDefenseVal() { //��� ���� �� ���ϱ�
        int defense = PlayerSetting.defenseLV; //��� �ɷ�ġ �ҷ����
        maxValue = defense * 2; //�ִ밪� ��� ������ 2��
        playerActionValue = Random.Range(defense, maxValue + 1); //����
        defenseValueText.text = playerActionValue.ToString(); //��� ���ڿ��� ��ȯ
    }
    public void ShowDefenseValue() { //��� �ൿ�� ǥ��
        attackValueText.text = "";
        SelectDefenseVal();
        recoveryValueText.text = "";
    }


    public void SelectRecoveryImg() { //ȸ�� �̹��� ǥ��
        selectAttack.SetActive(false); 
        selectDefense.SetActive(false);
        selectRecovery.SetActive(true); //�̹��� ǥ��
    }
    public void SelectRecoveryVal() { //ȸ�� ���� �� ���ϱ�
        int recovery = PlayerSetting.recoveryLV; //ȸ�� �ɷ�ġ �ҷ����
        maxValue = recovery * 2; //�ִ밪� ȸ�� ������ 2��
        playerActionValue = Random.Range(recovery, maxValue + 1); //����
        recoveryValueText.text = playerActionValue.ToString(); //��ݰ�� ���ڿ��� ��ȯ
    }
    public void ShowRecoveryValue() { //ȸ�� �ൿ�� ǥ��
        attackValueText.text = "";
        defenseValueText.text = "";
        SelectRecoveryVal();
    }
}