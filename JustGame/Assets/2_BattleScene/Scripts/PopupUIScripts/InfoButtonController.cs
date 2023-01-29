using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButtonController : MonoBehaviour {
    public GameObject infoPanelAll; //기반 패널

    public GameObject infoPanel1;
    public GameObject infoPanel2;
    public GameObject infoPanel3;
    public GameObject infoPanel4;

    private int num = 1;


    private void Start() {
        infoPanelAll.SetActive(false); //Info Panel 비활성화
    }


    // *** Info Pannel Initialization(Reset) ***
    private void Reset() {
        infoPanel2.SetActive(false);
        infoPanel3.SetActive(false);
        infoPanel4.SetActive(false);
    }


    // *** Info Pannel Buttons ***
    public void InfoRunButton() { //Info 버튼 클랙
        infoPanelAll.SetActive(true);
        infoPanel1.SetActive(true); //Info Panel 1 표시
    }

    public void InfoExitButton() { //X 버튼(나가기) 클릭하면
        Start();
    }

    public void InfoNextButton() {
        ++num;
        PannelNum();
    }

    public void InfoPrevButton() {
        --num;
        PannelNum();
    }


    // *** Info Pannel Button Mechanism ***
    private void PannelNum() {
        switch (num) {
            case 1:
                Reset();
                infoPanel1.SetActive(true); break;
            case 2:
                Reset();
                infoPanel2.SetActive(true); break;
            case 3:
                Reset();
                infoPanel3.SetActive(true); break;
            case 4:
                Reset();
                infoPanel4.SetActive(true); break;
            default: break;
        }
    }
}