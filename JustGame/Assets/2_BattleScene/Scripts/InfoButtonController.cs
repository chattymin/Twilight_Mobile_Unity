using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButtonController : MonoBehaviour {
    public GameObject infoPanelAll;
    public GameObject infoPanel1;
    public GameObject infoPanel2;
    public GameObject infoPanel3;
    public GameObject infoPanel4;

    static int num = 1;

    private void Start() { //게임이 시작하자마자 실행
        infoPanelAll.SetActive(false); //Info Panel을 비활성화
        infoPanel2.SetActive(false);
        infoPanel3.SetActive(false);
        infoPanel4.SetActive(false);
    }

    public void InfoButton() { //Info 버튼을 클릭하면
        infoPanelAll.SetActive(true);
        infoPanel1.SetActive(true); //Info Panel 1을 표시
    }

    public void InfoExit() { //X 버튼을 클릭하면
        infoPanelAll.SetActive(false); //Info Panel을 닫기
    }

    public void PannelNum() {
        switch(num) {
            case 1:
                infoPanel1.SetActive(true);
                infoPanel2.SetActive(false);
                break;
            case 2:
                infoPanel1.SetActive(false);
                infoPanel2.SetActive(true);
                infoPanel3.SetActive(false);
                break;
            case 3:
                infoPanel2.SetActive(false);
                infoPanel3.SetActive(true);
                infoPanel4.SetActive(false);
                break;
            case 4:
                infoPanel3.SetActive(false);
                infoPanel4.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void NextButton() {
        ++num;
        PannelNum();
    }

    public void PrevButton() {
        --num;
        PannelNum();
    }
}
