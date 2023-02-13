using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour {
    public GameObject startParenthese;
    public GameObject settingParenthese;
    public GameObject extraParenthese;
    public GameObject exitParenthese;

    public void OnMouseEnter() {
        startParenthese.SetActive(false);
        settingParenthese.SetActive(false);
        extraParenthese.SetActive(false);
        exitParenthese.SetActive(true);
        BTNManager.button = 4;
    }
}
