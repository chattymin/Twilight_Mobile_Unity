using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButtonController : MonoBehaviour {
    public GameObject infoPanel;

    private void Start() { //������ �������ڸ��� ����
        infoPanel.SetActive(false); //Info Panel�� ��Ȱ��ȭ
    }

    public void InfoButton() { //Info ��ư�� Ŭ���ϸ�
        infoPanel.SetActive(true); //Info Panel�� ǥ��
    }

    public void InfoExit() { //X ��ư�� Ŭ���ϸ�
        infoPanel.SetActive(false); //Info Panel�� �ݱ�
    }
}
