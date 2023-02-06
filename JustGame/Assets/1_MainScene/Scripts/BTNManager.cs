using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class BTNManager : MonoBehaviour {
    public Image image;
    public GameObject startButton;
    public GameObject exitButton;
    public GameObject settingButton;
    public GameObject extraButton;
    //public TextMeshProUGUI buttonText1;
    public TextMeshProUGUI buttonText;
    public string button = "Start"; // 하나만! 한번만 생성되는 스크립트에 넣어서 어디서 참조하더라도 같은 값이도록 만들기

    /*public void OnMouseOver() {
        Debug.Log("1");
        buttonText1.GetComponent<TextMeshProUGUI>().text = "<   START   >";
    }*/

    // *** 초기화 ***
    public void Init() {
        GameObject.Find("StartParenthese").SetActive(true);
        GameObject.Find("SettingParenthese").SetActive(false);
        GameObject.Find("ExtraParenthese").SetActive(false);
        GameObject.Find("ExitParenthese").SetActive(false);
    }

    // *** On Mouse Enter ***
    public void OnMouseEnter() {
        Remove(button);
        Draw(Calc());
    }

    public void Remove(string target) {
        GameObject.Find(target + "Parentheses").SetActive(false); // 괄호에 해당되는 오브젝트 만들고, 해당 변수명 맞추기
    }

    //StartPar


    public string Calc() {
        switch (buttonText.GetComponent<TextMeshProUGUI>().text) { // toString이 아니라 해당 텍스트매시프로가 가지고 있는 텍스트 값을 가져오는걸로 바꾸기
            case "START":
                return "Start";
            case "SETTING":
                return "Setting";
            case "EXTRA":
                return "Extra";
            case "EXIT":
                return "Exit";
        }
        return "";
    }

    public void Draw(string target) {
        button = target;
        //GameObject.Find("Button" + target.ToString()).SetActive(true);
        GameObject.Find(target + "Parentheses").SetActive(true);
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
        StartClick();
        SceneManager.LoadScene("EndingScene");
    }

    // *** Extra Button Click ***
    public void ExtraButtonRun() {
        StartClick();
        SceneManager.LoadScene("EndingScene");
    }
}
