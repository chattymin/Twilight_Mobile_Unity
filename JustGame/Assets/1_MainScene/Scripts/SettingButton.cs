using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour {
    public GameObject startParenthese;
    public GameObject settingParenthese;
    public GameObject extraParenthese;
    public GameObject exitParenthese;

    public void OnMouseEnter() {
        startParenthese.SetActive(false);
        settingParenthese.SetActive(true);
        extraParenthese.SetActive(false);
        exitParenthese.SetActive(false);
        BTNManager.button = 2;
    }
}
