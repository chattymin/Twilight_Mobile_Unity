using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButtonController : MonoBehaviour {
    public GameObject infoPanel;

    private void Start() { //게임이 시작하자마자 실행
        infoPanel.SetActive(false); //Info Panel을 비활성화
    }

    public void InfoButton() { //Info 버튼을 클릭하면
        infoPanel.SetActive(true); //Info Panel을 표시
    }

    public void InfoExit() { //X 버튼을 클릭하면
        infoPanel.SetActive(false); //Info Panel을 닫기
    }
}
