using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraButton : MonoBehaviour {
    public GameObject startParenthese;
    public GameObject settingParenthese;
    public GameObject extraParenthese;
    public GameObject exitParenthese;

    public void OnMouseEnter() {
        startParenthese.SetActive(false);
        settingParenthese.SetActive(false);
        extraParenthese.SetActive(true);
        exitParenthese.SetActive(false);
        BTNManager.button = 3;
    }
}
