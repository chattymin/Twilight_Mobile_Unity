using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject AttackEffect;
    public GameObject DefenseEffect;
    public GameObject RecoveryEffect;

    public GameObject EnemyStay;
    public GameObject EnemyAttack;
    public GameObject EnemyDefense;
    public GameObject EnemyRecovery;

    // Start is called before the first frame update
    void Start()
    {
        AttackEffect.SetActive(false);
        DefenseEffect.SetActive(false);
        RecoveryEffect.SetActive(false);

        EnemyStay.SetActive(true);
        EnemyAttack.SetActive(false);
        EnemyDefense.SetActive(false);
        EnemyRecovery.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EffectOn(int num)
    {
        switch (num)
        {
            case 1:
                AttackEffect.SetActive(true);
                DefenseEffect.SetActive(false);
                RecoveryEffect.SetActive(false);

                EnemyStay.SetActive(false);
                EnemyAttack.SetActive(true);
                EnemyDefense.SetActive(false);
                EnemyRecovery.SetActive(false);
                break;
            case 2:
                AttackEffect.SetActive(false);
                DefenseEffect.SetActive(true);
                RecoveryEffect.SetActive(false);

                EnemyStay.SetActive(false);
                EnemyAttack.SetActive(false);
                EnemyDefense.SetActive(true);
                EnemyRecovery.SetActive(false);
                break;
            case 3:
                AttackEffect.SetActive(false);
                DefenseEffect.SetActive(false);
                RecoveryEffect.SetActive(true);

                EnemyStay.SetActive(false);
                EnemyAttack.SetActive(false);
                EnemyDefense.SetActive(false);
                EnemyRecovery.SetActive(true);
                break;
        }
    }

    public void EffectOff()
    {
        AttackEffect.SetActive(false);
        DefenseEffect.SetActive(false);
        RecoveryEffect.SetActive(false);

        EnemyStay.SetActive(true);
        EnemyAttack.SetActive(false);
        EnemyDefense.SetActive(false);
        EnemyRecovery.SetActive(false);
    }

}
