using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class BTNManager : MonoBehaviour {
    public GameObject startButton;
    public GameObject exitButton;
    public GameObject settingButton;
    public GameObject extraButton;
    public GameObject startParenthese;
    public GameObject settingParenthese;
    public GameObject extraParenthese;
    public GameObject exitParenthese;
    public GameObject settingPanelAll;
    public GameObject settingPanel;

    public static int button;
    
    public void Start() {
        button=1;
        startParenthese.SetActive(true);
        settingParenthese.SetActive(false);
        extraParenthese.SetActive(false);
        exitParenthese.SetActive(false);
        settingPanelAll.SetActive(false);
        settingPanel.SetActive(false);
    }

    public void Update() {
        KeyboardController();
    }

    // *** Start Button Click ***
    public void StartButtonRun() {
        StartClick();
    }

    public void StartClick() {
        startButton.SetActive(false);
        exitButton.SetActive(false);
        settingButton.SetActive(false);
        extraButton.SetActive(false);
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

    // *** Setting Button Click ***
    public void SettingButtonRun() {
        SettingButton();
    }

    public void SettingButton() {
        settingPanelAll.SetActive(true);
        settingPanel.SetActive(true);
    }

    public void SettingExit() {
        settingPanelAll.SetActive(false);
    }

    // *** Extra Button Click ***
    public void ExtraButtonRun() {
        StartClick();
        SceneManager.LoadScene("EndingScene");
    }

    //*** Keyboard Controller ***
    public void KeyboardController() {
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            ++button;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            --button;
        }
        switch (button) {
            case 0:
                button = 4;
                break;
            case 1:
                startParenthese.SetActive(true);
                settingParenthese.SetActive(false);
                extraParenthese.SetActive(false);
                exitParenthese.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Return)) {
                    StartButtonRun();
                }
                break;
            case 2:
                startParenthese.SetActive(false);
                settingParenthese.SetActive(true);
                extraParenthese.SetActive(false);
                exitParenthese.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Return)) {
                    SettingButtonRun();
                }
                break;
            case 3:
                startParenthese.SetActive(false);
                settingParenthese.SetActive(false);
                extraParenthese.SetActive(true);
                exitParenthese.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Return)) {
                    ExtraButtonRun();
                }
                break;
            case 4:
                startParenthese.SetActive(false);
                settingParenthese.SetActive(false);
                extraParenthese.SetActive(false);
                exitParenthese.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return)) {
                    ExitButtonRun();
                }
                break;
            case 5:
                button = 1;
                break;
        }
    }
}
