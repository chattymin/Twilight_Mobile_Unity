using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleEffect : MonoBehaviour
{
    public GameObject AttackEffect;
    public GameObject DefenseEffect;
    public GameObject RecoveryEffect;

    public GameObject PlayerStay;
    public GameObject PlayerAttack;
    public GameObject PlayerDefense;
    public GameObject PlayerRecovery;

    // Start is called before the first frame update
    void Start()
    {
        EffectOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EffectOn(string str)
    {
        EffectOff();
        switch (str)
        {
            case "Attack":
                AttackEffect.SetActive(true);
                PlayerStay.SetActive(false);
                PlayerAttack.SetActive(true);
                break;
            case "Defense":
                DefenseEffect.SetActive(true);
                PlayerStay.SetActive(false);
                PlayerDefense.SetActive(true);
                break;
            case "Recovery":
                RecoveryEffect.SetActive(true);
                PlayerStay.SetActive(false);
                PlayerRecovery.SetActive(true);
                break;
        }
    }

    public void EffectOff()
    {
        AttackEffect.SetActive(false);
        DefenseEffect.SetActive(false);
        RecoveryEffect.SetActive(false);

        PlayerStay.SetActive(true);
        PlayerAttack.SetActive(false);
        PlayerDefense.SetActive(false);
        PlayerRecovery.SetActive(false);
    }

}