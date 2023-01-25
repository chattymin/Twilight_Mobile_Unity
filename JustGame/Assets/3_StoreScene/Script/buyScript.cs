using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class buyScript : MonoBehaviour
{
    Item myItem;
    public Image myItemImg;
    TextMeshProUGUI curmoney;
    TextMeshProUGUI attackexp;
    TextMeshProUGUI defenseexp;
    TextMeshProUGUI recoveryexp;
    ItemManager itemD;
    playerInfoUpdate playerInfo;
   

    private void Start()
    {

        itemD = GameObject.Find("GameObject").GetComponent<ItemManager>();
        myItem = itemD.exitItem;

        curmoney = GameObject.Find("curmoney").GetComponent<TextMeshProUGUI>();
        curmoney.text = PlayerSetting.money.ToString();

        attackexp = GameObject.Find("attackexp").GetComponent<TextMeshProUGUI>();
        attackexp.text = PlayerSetting.attackLV.ToString();

        defenseexp = GameObject.Find("defenseexp").GetComponent<TextMeshProUGUI>();
        defenseexp.text = PlayerSetting.defenseLV.ToString();

        recoveryexp = GameObject.Find("recoveryexp").GetComponent<TextMeshProUGUI>();
        recoveryexp.text = PlayerSetting.recoveryLV.ToString();

        playerInfo = GameObject.Find("GameObject").GetComponent<playerInfoUpdate>();
        
    }

    /* buyItem �޼ҵ�
     * ������ ���� ��ư�� Ŭ������ ��� �۵��ϴ� �޼ҵ�
     */
    public void buyItem(){
        if (checkMoney(myItem.itemPrice)) // ���� �������� ������ �� �ִ��� Ȯ��
        { 
            itemD.popup.SetActive(true) ; //������ �� ���� ��� popup�� ���
        }
        else {
            if (PlayerSetting.bought[itemD.indexNumber] == true) // �̹� player�� ������ ��ǰ�� ���
            {
                Debug.Log("�̹� ������ ������");
            }
            else 
            {
                myItemImg.sprite = myItem.itemImage; // inventroy ������ �̹����� ������ ������ �̹����� ����
                itemD.boughtUpdate(); // player�� ���� ������Ʈ. ���� ��ư ������Ʈ
                PlayerSetting.item = myItem; // player�� �������� ������ ���������� ����

                PlayerSetting.money -= myItem.itemPrice; // player ������ ����
                curmoney.text = PlayerSetting.money.ToString(); // ���� ������ ����
            }    
        }
    }


    /* buyExpAttack �޼ҵ�
     * defense ������ ������ ��� �۵��ϴ� �޼ҵ� 
     */
    public void buyExpAttack(){
        if (checkMoney(ItemManager.aPrice)) // ���� attack �������� �� �� �ִ��� Ȯ��
        {
            itemD.popup.SetActive(true); // ������ �� ���� ��� popup�� ���
        }
        else { //������ �� �ִ� ���
            PlayerSetting.attackLV += 1; // player�� LV 1 ����
            PlayerSetting.money -= itemD.getPrice("attack"); // player ������ ����
            itemD.setPrice("attack"); //������ ���� ������Ʈ

            // player�� ���� ǥ��
            attackexp.text = PlayerSetting.attackLV.ToString();
            curmoney.text = PlayerSetting.money.ToString();
        }
    }

    /* buyExpDefense �޼ҵ�
     * defense ������ ������ ��� �۵��ϴ� �޼ҵ� 
     */

    public void buyExpDefense(){
        if (checkMoney(ItemManager.dPrice)) // ���� defense �������� �� �� �ִ��� Ȯ��
        {
            itemD.popup.SetActive(true); // ������ �� ���� ��� popup�� ���
        }
        else // ������ �� �ִ� ���
        {
            PlayerSetting.defenseLV += 1;//player�� LV 1 ����
            PlayerSetting.money -= itemD.getPrice("defense");  //player�� ������ ����
            itemD.setPrice("defense"); //������ ���� ������Ʈ

            // player�� ���� ǥ��
            defenseexp.text = PlayerSetting.defenseLV.ToString();
            curmoney.text = PlayerSetting.money.ToString();
        } 
    }

    /* buyExpRecovery �޼ҵ�
     * recovery ������ ������ ��� �۵��ϴ� �޼ҵ� 
     */

    public void buyExpRecovery(){
        if (checkMoney(ItemManager.rPrice)) // ���� recovery �������� �� �� �ִ��� Ȯ��
        { 
            itemD.popup.SetActive(true); // ������ �� ���� ��� popup�� ���
        }
        else // ������ �� �ִ� ���
        {
            PlayerSetting.recoveryLV += 1; //player�� LV 1 ����
            PlayerSetting.money -= itemD.getPrice("recovery"); //player�� ������ ����
            itemD.setPrice("recovery"); //������ ���� ������Ʈ

            // player�� ���� ǥ��
            recoveryexp.text = PlayerSetting.recoveryLV.ToString(); 
            curmoney.text = PlayerSetting.money.ToString();
        }
    }

    /* checkMoney �޼ҵ�
     * Player�� ������-������ ���� ������� 0���� ���� ��� true�� ��ȯ��
     * ������ �� ������ ��. 
     */

    bool checkMoney(int money){
        if ((PlayerSetting.money-money) < 0) {
            return true;
        }
        return false;        
    }

    /* popup �޼ҵ�
     * player�� �������� ������ �� popupâ�� ���� �޼ҵ�
     */
    public void popup() {
        GameObject.Find("popup").SetActive(false);
    }
}
