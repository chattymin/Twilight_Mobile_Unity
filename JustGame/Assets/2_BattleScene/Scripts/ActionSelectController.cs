using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionSelectController : MonoBehaviour {
    public GameObject attackEffect;
    public GameObject defenceEffect;
    public GameObject healEffect;

    public void Start() {
        attackEffect.SetActive(false);
        defenceEffect.SetActive(false);
        healEffect.SetActive(false);
    }

    public void SelectAttack() {
        attackEffect.SetActive(true);
        defenceEffect.SetActive(false);
        healEffect.SetActive(false);
    }
    public void SelectDefence() {
        attackEffect.SetActive(false);
        defenceEffect.SetActive(true);
        healEffect.SetActive(false);
    }
    public void SelectHeal() {
        attackEffect.SetActive(false);
        defenceEffect.SetActive(false);
        healEffect.SetActive(true);
    }
}
