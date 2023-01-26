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
        AttackEffect.SetActive(false);
        DefenseEffect.SetActive(false);
        RecoveryEffect.SetActive(false);

        PlayerStay.SetActive(true);
        PlayerAttack.SetActive(false);
        PlayerDefense.SetActive(false);
        PlayerRecovery.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EffectOn(string str)
    {
        switch (str)
        {
            case "Attack":
                AttackEffect.SetActive(true);
                DefenseEffect.SetActive(false);
                RecoveryEffect.SetActive(false);

                PlayerStay.SetActive(false);
                PlayerAttack.SetActive(true);
                PlayerDefense.SetActive(false);
                PlayerRecovery.SetActive(false);
                break;
            case "Defense":
                AttackEffect.SetActive(false);
                DefenseEffect.SetActive(true);
                RecoveryEffect.SetActive(false);

                PlayerStay.SetActive(false);
                PlayerAttack.SetActive(false);
                PlayerDefense.SetActive(true);
                PlayerRecovery.SetActive(false);
                break;
            case "Recovery":
                AttackEffect.SetActive(false);
                DefenseEffect.SetActive(false);
                RecoveryEffect.SetActive(true);

                PlayerStay.SetActive(false);
                PlayerAttack.SetActive(false);
                PlayerDefense.SetActive(false);
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
