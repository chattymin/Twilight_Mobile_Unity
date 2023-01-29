using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionSelectController : MonoBehaviour {
    public GameObject attackEffect;
    public GameObject defenseEffect;
    public GameObject recoveryEffect;

    public string Action;


    // *** Effect Initialization(Reset) ***
    private void Reset() {
        Action = null;
        attackEffect.SetActive(false);
        defenseEffect.SetActive(false);
        recoveryEffect.SetActive(false);
    }


    // *** Attack Action Selected ***
    public void SelectAttack() {
        Reset();
        attackEffect.SetActive(true);
        Action = "Attack";
    }


    // *** Defense Action Selected ***
    public void SelectDefense() {
        Reset();
        defenseEffect.SetActive(true);
        Action = "Defense";
    }


    // *** Recovery Action Selected ***
    public void SelectRecovery() {
        Reset();
        recoveryEffect.SetActive(true);
        Action = "Recovery";
    }
}
