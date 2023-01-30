using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BTNManager : MonoBehaviour {
    public Image image;
    public GameObject Fade;
    public GameObject startButton;
    public GameObject exitButton;

    // *** Start Button Click ***
    public void StartButton() {
        startButton.SetActive(false);
        exitButton.SetActive(false);
        StartCoroutine(Fade.GetComponent<FadeManager>().FadeOutCoroutine("SelectST", "BattleScene"));
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
