using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BTNManager : MonoBehaviour {
    public Image image;
    public GameObject startButton;
    public GameObject exitButton;

    // *** Start Button Click ***
    public void StartButtonRun() {
        StartClick();
        //SceneChange();
    }

    public void StartClick() {
        //GameObject.Find("Fade")
        startButton.SetActive(false);
        exitButton.SetActive(false);
        StartCoroutine(GameObject.Find("FadeController").GetComponent<FadeManager>().FadeOutCoroutine("SelectST", "EndingScene"));
        //FadeOut 코루틴 실행
    }

    public void SceneChange() {
        StateSetting.states = "SelectST";
        SceneManager.LoadScene("EndingScene");
    }


    // *** Exit Button Click ***
    public void ExitButtonRun() {
        ExitClick();
    }

    public void ExitClick() { // 게임 종료 버튼 클릭
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; //프로그램 종료
        #else
            Application.Quit();
        #endif
    }
}
