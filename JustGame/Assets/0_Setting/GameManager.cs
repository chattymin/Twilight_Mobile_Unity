using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    private void Awake() {
        if (instance == null) { //instance�� �������� �ʴ´ٸ�
            instance = this; //�ڽ��� instance�� �־� ��.
            DontDestroyOnLoad(gameObject); //�� �ε� �� ������ ����
        }
        else {
            if (instance != this) //�̹� instance�� ������ ��
                Destroy(this.gameObject);
            //������ ��ü�̹Ƿ� ���� Awake�� �ڽ� ����
        }
    }

    /*public static GameManager Instance {
        //Instance�� static���� ����. �ٸ� Ŭ�������� ȣ�� ����
        get {
            if (null == instance)
                return null;
            return instance;
        }
    }*/


    // *** ���� ***
    // GameManager.instance.(�޼��� or ����);


    // *** PlayerSetting ***
    public int playerCurrentHP = 100; //�÷��̾� ���� ü��
    public int playerMoney = 0; //�÷��̾� ���� ������
    public int playerAttackLV = 1; //�÷��̾� ���� ����
    public int playerDefenseLV = 1; //���
    public int playerRecoveryLV = 1; //ȸ��
    public Item playerInventoryItem = null; //�÷��̾� ���� ������


    // *** EnemySetting ***
    public int EnemyBaseNumber = 1; //�� ���� ��� ����


    // *** ShopSetting ***
    private const int NUMBER_OF_ITEMS = 10; //���� ������ ������(�⺻��)
    public List<Item> ShopItemList = new List<Item>(NUMBER_OF_ITEMS);
    //���� ������ ����Ʈ


    // *** GameManagement ***
    public void StartGame() { //���� �� -> �� ���� ����

    }
    public void ContinueGame() { //���� �� -> �̾��ϱ�

    }
    public void PauseGame() { //Esc ���� ����

    }
}