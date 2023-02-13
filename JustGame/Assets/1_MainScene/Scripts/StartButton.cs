using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {
    public GameObject startParenthese;
    public GameObject settingParenthese;
    public GameObject extraParenthese;
    public GameObject exitParenthese;

    public void OnMouseEnter() {
        startParenthese.SetActive(true);
        settingParenthese.SetActive(false);
        extraParenthese.SetActive(false);
        exitParenthese.SetActive(false);
        BTNManager.button = 1;
    }
}
