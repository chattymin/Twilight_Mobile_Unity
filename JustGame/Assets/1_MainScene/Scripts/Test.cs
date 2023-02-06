using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Test : MonoBehaviour {
    public TextMeshProUGUI buttonText;
    public string button = "START"; // 하나만! 한번만 생성되는 스크립트에 넣어서 어디서 참조하더라도 같은 값이도록 만들기

    public void OnMouseEnter() {
        Remove(button);
        Draw(Calc());
    }

    public void Remove(string target) {
        GameObject.Find(target + "Par").SetActive(false); // 괄호에 해당되는 오브젝트 만들고, 해당 변수명 맞추기
    }

    //StartPar


    public string Calc() {
        switch (buttonText.ToString()) { // toString이 아니라 해당 텍스트매시프로가 가지고 있는 텍스트 값을 가져오는걸로 바꾸기
            case "START":
                return "START";
            case "SETTING":
                return "SETTING";
            case "EXTRA":
                return "EXTRA";
            case "EXIT":
                return "EXIT";
        }
        return "";
    }

    public void Draw(string target) {
        button = target;
        GameObject.Find("Button" + target.ToString()).SetActive(true);
    }

}
