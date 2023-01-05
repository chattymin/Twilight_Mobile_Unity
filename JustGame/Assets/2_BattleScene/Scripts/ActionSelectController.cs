using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionSelectController : MonoBehaviour {
    public GameObject attackEffect;
    public GameObject defenseEffect;
    public GameObject recoveryEffect;
    public string Action;

    public void Start() {
        attackEffect.SetActive(false);
        defenseEffect.SetActive(false);
        recoveryEffect.SetActive(false);
    }

    public void SelectAttack() {
        attackEffect.SetActive(true);
        defenseEffect.SetActive(false);
        recoveryEffect.SetActive(false);
        Action = "Attack";
    }
    public void SelectDefense() {
        attackEffect.SetActive(false);
        defenseEffect.SetActive(true);
        recoveryEffect.SetActive(false);
        Action = "Defense";
    }
    public void SelectRecovery() {
        attackEffect.SetActive(false);
        defenseEffect.SetActive(false);
        recoveryEffect.SetActive(true);
        Action = "Recovery";
    }
}
